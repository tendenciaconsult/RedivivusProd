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
using Simir.Domain.Enuns;

namespace Simir.Application
{
    public class RegiaoAdministrativaApp : AppServiceBase<SimirContext>, IRegiaoAdministrativaApp
    {
        private readonly IRegiaoAdministrativaService _RegiaoAdministrativaService;


        public RegiaoAdministrativaApp(IRegiaoAdministrativaService RegiaoAdministrativaService)
        {
            _RegiaoAdministrativaService = RegiaoAdministrativaService;
        }

        public object[][] GetHashRegiaoAdministrativa(int prefeituraID)
        {
            var lista = _RegiaoAdministrativaService.GetHashRegiaoAdministrativa(prefeituraID).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }

        public object[][] GetBairrosByRegiaoAdministrativa(int idRegiaoAdministrativa)
        {
            var lista = _RegiaoAdministrativaService.GetBairrosByRegiaoAdministrativa(idRegiaoAdministrativa).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }

        public object[][] GetLogradouroByRegiaoAdministrativaANDBairro(int idRegiaoAdministrativa, int idBairro)
        {
            var lista =
                _RegiaoAdministrativaService.GetLogradouroByRegiaoAdministrativaANDBairro(idRegiaoAdministrativa,
                    idBairro).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }

        public RegiaoAdministrativaVM CarregaRegiaoAdministrativa(int? id, int prefeituraID)
        {
            RegiaoAdministrativaVM retorno;
            if (id == null || id == 0)
            {
                retorno = new RegiaoAdministrativaVM();
                retorno.PrefeituraID = prefeituraID;
            }
            else
            {
                var reg = _RegiaoAdministrativaService.ReturnRegiaoAdministrativaByID((int)id).Result;
                if (prefeituraID != reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (!reg.bAtivo)
                {
                    throw new Exception("Região Administrativa não existe mais");
                }

                retorno = RegiaoAdministrativaVM.ToView(reg);


            }
            
            return retorno;
        }
        public List<RegioesAdministrativasCadastradasVM> BuscaProgramacao(int idPrefeitura)
        {
            List<RegioesAdministrativasCadastradasVM> retorno;

            retorno = new List<RegioesAdministrativasCadastradasVM>();

            retorno =
                _RegiaoAdministrativaService.GetAllRegioesAdministrativasByPrefeituraID(idPrefeitura)
                    .Select(x => new RegioesAdministrativasCadastradasVM(x)).ToList();


            return retorno;
        }
        public async Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, RegiaoAdministrativaVM model)
        {
            //------------------------salva a programação------------------------
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBRegiaoAdministrativa item;


            if (model.RegiaoAdministrativaID == 0)
            {
                item = new TBRegiaoAdministrativa();
            }
            else
            {
                item = await _RegiaoAdministrativaService.ReturnRegiaoAdministrativaByID(model.RegiaoAdministrativaID);
            }

            item.PrefeituraID = model.PrefeituraID;
            item.nmRegiaoAdministrativa = model.nmRegiaoAdministrativa;
            item.PrefeituraID = model.PrefeituraID;
            item.bAtivo = true;
            

            BeginTransaction();

            try
            {
                if (model.RegiaoAdministrativaID == 0)
                    tudoCerto = await _RegiaoAdministrativaService.AddRegiaoAdministrativaAsync(user, item);
                else
                    tudoCerto = await _RegiaoAdministrativaService.UpdateRegiaoAdministrativaAsync(user, item);

                if (tudoCerto)
                {
                    Commit();

                    var ProgramacaoID = item.RegiaoAdministrativaID;
                    //------------------------SALVA OS EQUIPAMENTOS DESTA PROGRAMACAO------------------------
                    var Result = false;

                    foreach (var i in model.Logradouros)
                    {
                        Result = false;
                        if (i.Status == (int)TipoPermissao.Excluir)
                        {
                            if (i.RegiaoAdministrativaLogradouroID != 0)
                            {
                                Result =
                                    await _RegiaoAdministrativaService.ExcluirLogradouroAsync(user, i.RegiaoAdministrativaLogradouroID);
                            }
                        }
                        else
                        {
                            TBRegiaoAdministrativaLogradouro Logradouro;

                            if (i.Status == (int)TipoPermissao.Incluir)
                            {
                                Logradouro = new TBRegiaoAdministrativaLogradouro();

                                Logradouro.EnderecoLogradouroID = Convert.ToInt32(i.EnderecoBairroID);
                                Logradouro.EnderecoBairroID = Convert.ToInt32(i.EnderecoBairroID);

                                Logradouro.nmOutroPavimento = i.nmOutroPavimento;
                                Logradouro.RegiaoAdministrativaID = ProgramacaoID;
                                Logradouro.qtSargetas = (i.qtSargetas == null) ? 0 : Convert.ToInt32(i.qtSargetas.Replace(".", ""));
                                Logradouro.qtArvores = (i.qtArvores == null) ? 0 : Convert.ToInt32(i.qtArvores.Replace(".", ""));
                                Logradouro.qtSemPavimento = (i.qtSemPavimento == null) ? 0 : Convert.ToInt32(i.qtSemPavimento.Replace(".", "")); 
                                Logradouro.qtAsfalto = (i.qtAsfalto == null) ? 0 : Convert.ToInt32(i.qtAsfalto.Replace(".", "")); 
                                Logradouro.qtBloco = (i.qtBloco == null) ? 0 : Convert.ToInt32(i.qtBloco.Replace(".", "")); 
                                Logradouro.qtOutroPavimento = (i.qtOutroPavimento == null) ? 0 : Convert.ToInt32(i.qtOutroPavimento.Replace(".", ""));
                                Logradouro.qtExtensaoTotal = (i.qtExtensaoTotal == null) ? 0 : Convert.ToInt32(i.qtExtensaoTotal.Replace(".", "")); 
                                Logradouro.qtBocaLobo = (i.qtBocaLobo == null) ? 0 : Convert.ToInt32(i.qtBocaLobo.Replace(".", "")); 
                                Logradouro.qtLarguraVia = (i.qtLarguraVia == null) ? 0 : Convert.ToInt32(i.qtLarguraVia.Replace(".", "")); 

                                Logradouro.bRealizaLimpezaMecanica = Convert.ToBoolean(i.bRealizaLimpezaMecanica);
                                Logradouro.bRealizaLavagem = Convert.ToBoolean(i.bRealizaLavagem);
                                Logradouro.bPossuiAreaVerde = Convert.ToBoolean(i.bPossuiAreaVerde);
                                Logradouro.bLogradouroArborizado = Convert.ToBoolean(i.bLogradouroArborizado);
                                Logradouro.bPraca = Convert.ToBoolean(i.bPraca);
                                Logradouro.bParque = Convert.ToBoolean(i.bParque);
                                Logradouro.bTotalmenteAsfaltado = Convert.ToBoolean(i.bTotalmenteAsfaltado);
                                Logradouro.bAtivo = true;

                                Result =
                                    await _RegiaoAdministrativaService.AddRegiaoAdministrativaLogradouroAsync(user, Logradouro);
                            }
                            else if (i.Status != (int)TipoPermissao.Consultar && i.Status != (int)TipoPermissao.Print)
                            {
                                Logradouro = await _RegiaoAdministrativaService.GetRegiaoAdministrativaLogradouroByID(i.RegiaoAdministrativaLogradouroID);

                                Logradouro.RegiaoAdministrativaID = ProgramacaoID;
                                Logradouro.EnderecoLogradouroID = Convert.ToInt32(i.EnderecoBairroID);
                                Logradouro.EnderecoBairroID = Convert.ToInt32(i.EnderecoBairroID);

                                Logradouro.nmOutroPavimento = i.nmOutroPavimento;

                                Logradouro.qtSargetas = (i.qtSargetas == null) ? 0 : Convert.ToInt32(i.qtSargetas.Replace(".", ""));
                                Logradouro.qtArvores = (i.qtArvores == null) ? 0 : Convert.ToInt32(i.qtArvores.Replace(".", ""));
                                Logradouro.qtSemPavimento = (i.qtSemPavimento == null) ? 0 : Convert.ToInt32(i.qtSemPavimento.Replace(".", ""));
                                Logradouro.qtAsfalto = (i.qtAsfalto == null) ? 0 : Convert.ToInt32(i.qtAsfalto.Replace(".", ""));
                                Logradouro.qtBloco = (i.qtBloco == null) ? 0 : Convert.ToInt32(i.qtBloco.Replace(".", ""));
                                Logradouro.qtOutroPavimento = (i.qtOutroPavimento == null) ? 0 : Convert.ToInt32(i.qtOutroPavimento.Replace(".", ""));
                                Logradouro.qtExtensaoTotal = (i.qtExtensaoTotal == null) ? 0 : Convert.ToInt32(i.qtExtensaoTotal.Replace(".", ""));
                                Logradouro.qtBocaLobo = (i.qtBocaLobo == null) ? 0 : Convert.ToInt32(i.qtBocaLobo.Replace(".", ""));
                                Logradouro.qtLarguraVia = (i.qtLarguraVia == null) ? 0 : Convert.ToInt32(i.qtLarguraVia.Replace(".", ""));

                                Logradouro.bRealizaLimpezaMecanica = Convert.ToBoolean(i.bRealizaLimpezaMecanica);
                                Logradouro.bRealizaLavagem = Convert.ToBoolean(i.bRealizaLavagem);
                                Logradouro.bPossuiAreaVerde = Convert.ToBoolean(i.bPossuiAreaVerde);
                                Logradouro.bLogradouroArborizado = Convert.ToBoolean(i.bLogradouroArborizado);
                                Logradouro.bPraca = Convert.ToBoolean(i.bPraca);
                                Logradouro.bParque = Convert.ToBoolean(i.bParque);
                                Logradouro.bTotalmenteAsfaltado = Convert.ToBoolean(i.bTotalmenteAsfaltado);
                                Logradouro.bAtivo = true;

                                Result =
                                    await _RegiaoAdministrativaService.UpdateRegiaoAdministrativaLogradouroAsync(user, Logradouro);
                            }
                        }
                        if (Result) Commit();
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


        public async Task<IDictionary<string, ModelState>> Excluir(AspNetUser user, RegiaoAdministrativaVM model)
        {
            var resultado = new Dictionary<string, ModelState>();

            TBRegiaoAdministrativa item;
            item = await _RegiaoAdministrativaService.ReturnRegiaoAdministrativaByID(model.RegiaoAdministrativaID);

            item.bAtivo = false;

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto =
                    await _RegiaoAdministrativaService.UpdateRegiaoAdministrativaAsync(user, item);
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