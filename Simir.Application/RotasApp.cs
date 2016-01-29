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
    public class RotasApp : AppServiceBase<SimirContext>, IRotasApp
    {
        private readonly IRotaService _Rota;
        private readonly IRotasDescricaoService _RotaDescricao;

        public RotasApp(IRotaService Rota,
            IRotasDescricaoService RotaDescricao)
        {
            _Rota = Rota;
            _RotaDescricao = RotaDescricao;
        }

        public object[][] GetRotasByPrefeitura(int prefeituraID)
        {
            var lista = _Rota.GetRotasByPrefeitura(prefeituraID).ToList();
            lista.Insert(0, new object[] { "0", " " });

            return lista.ToArray();
        }
        public List<ListaRotasVM> CarregaGrid(int PrefeituraID)
        {
            List<ListaRotasVM> retorno;

            retorno = new List<ListaRotasVM>();

            retorno =
                _Rota.CarregaGrid(PrefeituraID)
                    .Select(x => new ListaRotasVM(x)).ToList();


            return retorno;
        }
        public object[][] DestinoResiduos()
        {
            var lista = new[]
            {
                new object[] {"0", "Aterros"},
                new object[] {"1", "Transbordos"},
                new object[] {"2", "Associação de Catadores"},
            };

            return lista.ToArray();
        }
        public RotasVM GetProgramacaoByID(int? id, int prefeituraID)
        {
            RotasVM retorno;

            if (id == null || id == 0)
            {
                retorno = new RotasVM();
            }
            else
            {
                var Reg = _Rota.ReturnProgramacaoByID((int)id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = RotasVM.ToView(Reg);
            }


            return retorno;
        }
        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, RotasVM model)
        {
            //------------------------salva a programação------------------------
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBRota Dados;


            if (model.RotasID == 0)
            {
                Dados = new TBRota();
            }
            else
            {
                Dados = await _Rota.ReturnProgramacaoByID(model.RotasID);
            }

            Dados.nmRota = model.nmRota;
            Dados.PrefeituraID = model.PrefeituraID;
            Dados.DistanciaGaragemRota = (model.DistanciaGaragemRota == null) ? 0 : Convert.ToInt32(model.DistanciaGaragemRota.Replace(".", ""));
            Dados.DistanciaRotaDescarregamento = (model.DistanciaRotaDescarregamento == null) ? 0 : Convert.ToInt32(model.DistanciaRotaDescarregamento.Replace(".", ""));
            Dados.ExtensaoRota = (model.ExtensaoRota == null) ? 0 : Convert.ToInt32(model.ExtensaoRota.Replace(".", ""));
            Dados.qtPopulacaoAtendida = (model.qtPopulacaoAtendida == null) ? 0 : Convert.ToInt32(model.qtPopulacaoAtendida.Replace(".", ""));
            Dados.LocalDestinoID = Convert.ToInt32(model.LocalDestinoID);
            Dados.nmLocalDestino = model.nmLocalDestino;
            Dados.bAtivo = true;


            BeginTransaction();

            try
            {
                if (model.RotasID == 0)
                    tudoCerto = await _Rota.AddNovaProgramacaoAsync(user, Dados);
                else
                    tudoCerto = await _Rota.UpdateProgramacaoAsync(user, Dados);

                if (tudoCerto)
                {
                    Commit();

                    var ProgramacaoID = Dados.RotasID;
                    //------------------------SALVA OS DESCRIÇÃO DA ROTA (LOGRADOUROS)------------------------
                    var Result = false;

                    foreach (var i in model.RotasDescricao)
                    {
                        Result = false;
                        if (i.Status == (int)TipoPermissao.Excluir)
                        {
                            if (i.RotasDescricaoID != 0)
                            {
                                Result =
                                    await _RotaDescricao.RemoverDadosByIDAsync(user, i.RotasDescricaoID);
                            }
                        }
                        else
                        {
                            TBRotasDescricao vDescricao;

                            if (i.Status == (int)TipoPermissao.Incluir)
                            {
                                vDescricao = new TBRotasDescricao();
                               
                                vDescricao.RotasID = ProgramacaoID;
                                vDescricao.ExtensaoPercorrida = (i.ExtensaoPercorrida == null)
                                                                    ? 0
                                                                    : Convert.ToInt32(i.ExtensaoPercorrida.Replace(".", ""));
                                vDescricao.nmDirecionamento = i.nmDirecionamento;
                                vDescricao.PEV = (i.PossuiPevs == "Sim") ? true : false;
                                vDescricao.EnderecoBairroID = Convert.ToInt32(i.BairroID);
                                vDescricao.EnderecoLogradouroID = Convert.ToInt32(i.LogradouroID);
                                vDescricao.RegiaoAdministrativaID = Convert.ToInt32(i.RegiaoAdministrativaID);
                                vDescricao.bAtivo = true;
                                


                                Result =
                                    await _RotaDescricao.AddDadosAsync(user, vDescricao);
                            }
                            else if (i.Status != (int)TipoPermissao.Consultar && i.Status != (int)TipoPermissao.Print)
                            {
                                vDescricao = await _RotaDescricao.ReturnDadosByID(i.RotasDescricaoID);
                                
                                vDescricao.RotasID = ProgramacaoID;
                                vDescricao.ExtensaoPercorrida = (i.ExtensaoPercorrida == null)
                                                                    ? 0
                                                                    : Convert.ToInt32(i.ExtensaoPercorrida.Replace(".", ""));
                                vDescricao.nmDirecionamento = i.nmDirecionamento;
                                vDescricao.PEV = (i.PossuiPevs == "Sim") ? true : false;
                                vDescricao.EnderecoBairroID = Convert.ToInt32(i.BairroID);
                                vDescricao.EnderecoLogradouroID = Convert.ToInt32(i.LogradouroID);
                                vDescricao.RegiaoAdministrativaID = Convert.ToInt32(i.RegiaoAdministrativaID);
                                vDescricao.bAtivo = true;

                                Result =
                                    await _RotaDescricao.UpdateDadosAsync(user, vDescricao);
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

        public async Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int id)
        {
            var resultado = new Dictionary<string, ModelState>();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _Rota.ExcluirProgramacaoAsync(user, id);
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