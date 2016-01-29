using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class SecretariaApp : AppServiceBase<SimirContext>, ISecretariaApp
    {
        private readonly IEnderecoService _enderecoService;
        private readonly ISecretariaService _secretariaService;

        public SecretariaApp(
            IEnderecoService enderecoService,
            ISecretariaService secretariaService
            )
        {
            _secretariaService = secretariaService;
            _enderecoService = enderecoService;
        }
        public List<SecretariaBasicoVM> BuscaProgramacao(int idPrefeitura)
        {
            List<SecretariaBasicoVM> retorno;

            retorno = new List<SecretariaBasicoVM>();

            retorno =
                _secretariaService.GetAllByPrefeitura(idPrefeitura)
                    .Select(x => new SecretariaBasicoVM(x)).ToList();


            return retorno;
        }

        public SecretariaVM GetSecretaria(int? id, int prefeituraID)
        {
            SecretariaVM retorno;
            var allResp = _secretariaService.GetAllResponsabilidades();
            if (id == null || id == 0)
            {
                retorno = new SecretariaVM();
            }
            else
            {
                var secr = _secretariaService.GetById((int) id);
                if (prefeituraID != secr.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (!secr.bAtivo)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = SecretariaVM.ToView(secr);
                //if(secr.TBSecretariasResponsabilidades !=)

                var respPadrao =
                    secr.TBSecretariasResponsabilidades.Where(
                        x => x.ResponsabilidadesID != null && x.ResponsabilidadesID != 0)
                        .Select(x => x.TBResponsabilidade);
                allResp = allResp.Where(x => !respPadrao.Contains(x));

                retorno.ResponsabilidadesSuas =
                    secr.TBSecretariasResponsabilidades.Select(
                        x => new SelectListItem {Value = x.SecretariasResponsabilidadesID.ToString(), Text = x.nmOutros});
            }
            retorno.ResponsabilidadesTodas =
                allResp.Select(x => new SelectListItem {Value = x.nmResponsabilidades, Text = x.nmResponsabilidades});

            //retorno.Secretarias =
            //    _secretariaService.GetAllByPrefeitura(prefeituraID).Select(x => new SecretariaBasicoVM(x)).ToList();

            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, SecretariaVM model)
        {
            var resultado = new Dictionary<string, ModelState>();
            var prefeitura = user.TBUsuario.TBPrefeitura;
            //var endereco = prefeitura.TBEndereco;

            TBSecretaria secretaria;

            if (model.SecretariaID == 0)
            {
                secretaria = new TBSecretaria();
            }
            else
            {
                secretaria = _secretariaService.GetById(model.SecretariaID);
            }
            secretaria.PrefeituraID = prefeitura.PrefeituraID;
            secretaria.nmSecretaria = model.NomeSecretaria;
            secretaria.nmSecretario = model.NomeSecretario;
            secretaria.Site = model.SiteSecretaria;
            secretaria.Telefone1 = model.Telefone1;
            secretaria.Telefone2 = model.Telefone2;
            secretaria.Email = model.Email;
            secretaria.TBEndereco = EnderecoVM.ToModel(model.Endereco);

            if (model.SecretariaID != 0)
            {
                secretaria.TBEndereco.EnderecoID = (int) secretaria.EnderecoID;
            }

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = _enderecoService.ValidaEndereco(secretaria.TBEndereco);
                if (tudoCerto)
                {
                    if (model.SecretariaID == 0)
                        tudoCerto =
                            await
                                _secretariaService.AddSecretariaAsync(user, secretaria, model.ResponsabilidadesSuasIDs);
                    else
                        tudoCerto =
                            await
                                _secretariaService.UpdateSecretariaAsync(user, secretaria,
                                    model.ResponsabilidadesSuasIDs);
                }

                if (tudoCerto) Commit();
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

        public async Task<IDictionary<string, ModelState>> Excluir(AspNetUser user, int secretariaId)
        {
            var resultado = new Dictionary<string, ModelState>();

            TBSecretaria secretaria;


            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _secretariaService.ExcluirSecretariaAsync(user, secretariaId);
                if (tudoCerto) Commit();
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