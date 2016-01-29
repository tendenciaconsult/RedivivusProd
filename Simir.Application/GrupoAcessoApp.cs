using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class GrupoAcessoApp : AppServiceBase<SimirContext>, IGrupoAcessoApp
    {
        private readonly IStoredProceduresService _proc;
        private readonly IAspNetPerfilService _PerffilService;
        private readonly IAspNetPermissaoService _permissaoService;

        public GrupoAcessoApp(IStoredProceduresService procReturnListaMenu,
            IAspNetPerfilService PerffilService,
            IAspNetPermissaoService permissaoService)
        {
            _proc = procReturnListaMenu;
            _PerffilService = PerffilService;
            _permissaoService = permissaoService;

        }
        public GrupoAcessoVM ReturnPerfilByID(int? id, int PrefeituraID)
        {
            GrupoAcessoVM retorno;
            if (id == null)
            {
                id = 0;
            }
            List<ListaGrupoAcessoVM> CarregaGrid;

            CarregaGrid = ListaGrupoAcessoVM.ToView(_proc.GetMenus((int)id)).ToList();
   

            if (id == 0)
            {
                retorno = new GrupoAcessoVM();

            }
            else
            {
                var Reg = _PerffilService.GetPerfilByID((int)id).Result;
                if (PrefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = GrupoAcessoVM.ToView(Reg);
            }

            retorno.ListaAcesso = CarregaGrid;
            return retorno;
        }
        public List<BuscaPerfilVM> BuscaProgramacao(int idPrefeitura)
        {
            List<BuscaPerfilVM> retorno;

            retorno = new List<BuscaPerfilVM>();

            retorno = _PerffilService.GetByPrefeituraID(idPrefeitura)
                .Select(x => new BuscaPerfilVM(x)).ToList();


            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, GrupoAcessoVM model)
        {
            //------------------------salva a programação------------------------
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            AspNetPerfil Item;
            bool Incluir;


            if (model.GrupoAcessoID == 0)
            {
                Item = new AspNetPerfil();
                Incluir = true;
            }
            else
            {
                Item = await _PerffilService.GetPerfilByID(model.GrupoAcessoID);
                Incluir = false;
            }

            Item.PrefeituraID = model.PrefeituraID;
            Item.Nome = Convert.ToString(model.nmProgramacao);
            Item.Descricao = Convert.ToString(model.Descricao);

            Item.bAtivo = true;


            BeginTransaction();

            try
            {
                if (model.GrupoAcessoID == 0)
                    tudoCerto = await _PerffilService.addPerfilAsync(user, Item);
                else
                    tudoCerto = await _PerffilService.UpdatePerfilAsync(user, Item);

                if (tudoCerto)
                {
                    Commit();

                    var PerfilID = Item.AspNetPerfilId;
                    //------------------------SALVA OS EQUIPAMENTOS DESTA PROGRAMACAO------------------------
                    var Result_Equipamentos = false;
                    var valor = 0;

                    foreach (var i in model.ListaAcesso)
                    {
                        if (i.PermissaoId != 0)
                        {
                            Result_Equipamentos = false;
                            valor = 0;
                            if (i.Consultar == true)
                                valor = 1;

                            if (i.Incluir == true)
                                valor = valor + 4;

                            if (i.Alterar == true)
                                valor = valor + 2;

                            if (i.Excluir == true)
                                valor = valor + 8;

                            if (i.Imprimir == true)
                                valor = valor + 16;

                            AspNetPermissao Permissao;

                            if (Incluir)
                            {

                                Permissao = new AspNetPermissao();

                                Permissao.AspNetPerfilId = PerfilID;
                                Permissao.AspNetModuloId = i.idModulo;
                                Permissao.AspNetTipoPermissaoId = (TipoPermissao) valor;


                                Result_Equipamentos =
                                    await _permissaoService.addPermissao(user, Permissao);
                            }
                            else
                            {
                                Permissao = await _permissaoService.GetPermissaoById(i.PermissaoId);

                                Permissao.AspNetTipoPermissaoId = (TipoPermissao) valor;

                                Result_Equipamentos =
                                    await _permissaoService.UpdatePermissaoAsync(user, Permissao);
                            }

                            if (Result_Equipamentos) Commit();
                        }
                    }

                }
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            return resultado;
        }

        public async Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int Id)
        {
            var resultado = new Dictionary<string, ModelState>();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _PerffilService.ExcluirPerfilAsync(user, Id);
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
