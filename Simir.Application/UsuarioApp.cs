using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class UsuarioApp : AppServiceBase<SimirContext>, IUsuarioApp
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IUsuarioService _service;
        private readonly IAspNetPerfilService _PerfilService;
        private readonly IAspNetFuncaoService _simirFuncaoService;

        public UsuarioApp(
            IAspNetFuncaoService simirFuncaoService,
            IEnderecoService enderecoService,
            IAspNetPerfilService PerfilService,
            IUsuarioService usuarioService
            )
        {
            _service = usuarioService;
            _simirFuncaoService = simirFuncaoService;
            _enderecoService = enderecoService;
            _PerfilService = PerfilService;
        }

        public ICollection<UsuarioBasicoVM> GetAllUsuarios(ApplicationUserManager userManager)
        {
            var listUser = userManager.Users.ToList();

            return UsuarioBasicoVM.ToDomain(listUser);
        }

        public UsuarioVM GetUsuarioByNome(ApplicationUserManager UserManager, string userName)
        {
            var usuario = UserManager.FindByNameAsync(userName).Result;

            if (usuario == null) throw new ArgumentException("Usuário não existe.", "userName");

            return UsuarioVM.ToDomain(usuario);
        }
        public List<UsuarioBasicoVM> BuscaProgramacao(int idPrefeitura)
        {
            List<UsuarioBasicoVM> retorno;

            retorno = new List<UsuarioBasicoVM>();

            retorno =
                _service.GetAllByPrefeitura(idPrefeitura)
                    .Select(x => new UsuarioBasicoVM(x)).ToList();


            return retorno;
        }

        public UsuarioVM GetUsuarioById(ApplicationUserManager UserManager, int? id, int prefeituraID)
        {
            UsuarioVM retorno;
            var allPerfil = _service.GetAllperfilByPrefeitura(prefeituraID);
            if (id == null || id == 0)
            {
                retorno = new UsuarioVM();
            }
            else
            {
                var user = _service.GetById(prefeituraID, (int) id);
                var usuario = UserManager.FindByNameAsync(user.Email).Result;

                retorno = new UsuarioVM(user);

                var userPerfil = usuario.Perfis;
                    allPerfil = allPerfil.Where(x => !userPerfil.Contains(x));

                retorno.PerfilAcessoVinculados =
                    usuario.Perfis.Select(
                        x => new SelectListItem { Value = x.AspNetPerfilId.ToString(), Text = x.Nome });
            }


            retorno.PerfilAcessoTodos =
                    allPerfil.Select(x => new SelectListItem { Value = x.AspNetPerfilId.ToString(), Text = x.Nome });

            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarAsync(ApplicationUserManager UserManager,
            AspNetUser userLogado, UsuarioVM model)
        {
            var resultado = new Dictionary<string, ModelState>();
            try
            {
                TBUsuario usuario = null;
                if (model.Id != 0)
                {
                    usuario = _service.GetById((int) userLogado.TBUsuario.PrefeituraID, model.Id);
                }

                UsuarioVM.ToModel(ref usuario, model);

                BeginTransaction();

                var tudoCerto = false;

                tudoCerto = _enderecoService.ValidaEndereco(usuario.TBEndereco);
                if (tudoCerto)
                {
                    if (model.Id == 0)
                        tudoCerto = await _service.AddAsync(userLogado, usuario);
                    else
                        tudoCerto = await _service.UpdateAsync(userLogado, usuario);
                }
                if (tudoCerto) await CommitAsync();

                if (model.Id == 0)
                {
                    var user = new AspNetUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        UsuarioID = usuario.usuarioID,
                        EmailConfirmed = true
                    };

                    //user.Perfis.Add(_perfilService.GetPerfilByNome("externoGerador"));

                    var senha = Guid.NewGuid().ToString().Substring(0, 8);
                    var result = await UserManager.CreateAsync(user, senha);
                    if (result.Succeeded)
                    {
                        await
                            UserManager.SendEmailAsync(user.Id, "Confirme sua Conta",
                                string.Format("Seu login é: {0} Sua senha é: {1}", model.Email, senha));
                    }
                    else
                    {
                        var errors = string.Join(", ", result.Errors);

                        if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());

                        resultado[""].Errors.Add(errors);
                    }
                }
                if (tudoCerto)
                {
                    var Result_Perfil = false;
                    var User = UserManager.FindByNameAsync(model.Email).Result;

                    User.Perfis.Clear();

                    for (int i = 0; i < model.PerfilAcessoVinculadoIDs.Length; i++)
                    {
                        User.Perfis.Add(_PerfilService.GetById(Convert.ToInt32(model.PerfilAcessoVinculadoIDs[i])));
                    }


                    await UserManager.UpdateAsync(User);

                }
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());

                resultado[""].Errors.Add(ex);
            }
            return resultado;
        }

        public async Task<IDictionary<string, ModelState>> Excluir(ApplicationUserManager UserManager,
            AspNetUser userLogado, int id)
        {
            var resultado = new Dictionary<string, ModelState>();


            try
            {
                TBUsuario usuario;
                usuario = _service.GetById((int) userLogado.TBUsuario.PrefeituraID, id);

                BeginTransaction();

                var tudoCerto = true;

                if (tudoCerto)
                {
                    tudoCerto = await _service.DeleteAsync(userLogado, usuario);
                }

                if (tudoCerto) await CommitAsync();


                var user = await UserManager.FindByUsuarioAsync(id);

                await UserManager.DesativarAsync(user);
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());
                resultado[""].Errors.Add(ex);
            }

            return resultado;
        }

        public UsuarioAutoEditVM GetUsuarioByUser(AspNetUser user)
        {
            return new UsuarioAutoEditVM(user.TBUsuario);
        }

        public async Task<IDictionary<string, ModelState>> SalvarAsync(AspNetUser user, UsuarioAutoEditVM model)
        {
            var resultado = new Dictionary<string, ModelState>();
            try
            {
                var usuario = user.TBUsuario;

                UsuarioAutoEditVM.ToModel(ref usuario, model);


                BeginTransaction();

                var tudoCerto = false;

                tudoCerto = _enderecoService.ValidaEndereco(usuario.TBEndereco);
                if (tudoCerto)
                {
                    tudoCerto = await _service.UpdateAsync(user, usuario);
                }
                if (tudoCerto) await CommitAsync();
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());

                resultado[""].Errors.Add(ex);
            }
            return resultado;
        }
    }
}