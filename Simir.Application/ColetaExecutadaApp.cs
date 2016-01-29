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
    public class ColetaExecutadaApp : AppServiceBase<SimirContext>, IColetaExecutadaApp
    {
        private readonly IColetaExecutadaDetalhadaService _ColetaDetalhada;
        private readonly IColetaEventualService _ColetaEventual;
        private readonly IColetaExecutadaService _ColetaExecutada;

        public ColetaExecutadaApp(IColetaExecutadaService ColetaExecutada,
            IColetaEventualService ColetaEventual,
            IColetaExecutadaDetalhadaService ColetaDetalhada)
        {
            _ColetaExecutada = ColetaExecutada;
            _ColetaEventual = ColetaEventual;
            _ColetaDetalhada = ColetaDetalhada;
        }

        public object[][] RetornaResiduoColetado()
        {
            var lista = new[]
            {
                new object[] {"0", ""},
                new object[] {"1", "Resíduos Domiciliares"},
                new object[] {"2", "Resíduos Públicos"},
                new object[] {"3", "Resíduos Industriais"},
                new object[] {"4", "Resíduos de Indústria de Mineração"},
                new object[] {"5", "Resíduos de Construção Civil"},
                new object[] {"6", "Resíduos Hospitalares"},
                new object[] {"7", "Resíduos de Comercio e Serviços"},
                new object[] {"8", "Resíduos de Atividades Agropecuárias e Silviculturais"}
                
            };

            return lista.ToArray();
        }

        public ColetaExecutadaVM GetProgramacaoColetaEventual(int? id, int prefeituraID)
        {
            ColetaExecutadaVM retorno;

            if (id == null || id == 0)
            {
                retorno = new ColetaExecutadaVM();
                retorno.dtReferencia = Convert.ToString(DateTime.Now).Substring(0, 10);
            }
            else
            {
                var Reg = _ColetaEventual.RetornaColetaEventualByID((int) id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = ColetaExecutadaVM.ToView(Reg);
            }


            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, ColetaExecutadaVM model)
        {
            //------------------------salva a programação------------------------
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBColetaExecutada Item;


            if (model.ColetaExecutadaID == 0)
            {
                Item = new TBColetaExecutada();
            }
            else
            {
                Item = await _ColetaExecutada.RetornaColetaExecutadaByID(model.ColetaExecutadaID);
            }


            Item.PrefeituraID = model.PrefeituraID;
            Item.dtReferencia = Convert.ToDateTime(model.dtReferencia);
            Item.ColetaExecutadaID = Convert.ToInt32(model.ColetaEventualID);
            Item.bColetaRealizada = model.bColetaRealizada;
            Item.nmProgramacao = model.nmProgramacao;

            if (model.bColetaRealizada)
            {
                Item.HoraSaidaGaragem = model.HoraSaidaGaragem;
                Item.HoraChegadaGaragem = model.HoraChegadaGaragem;
                Item.qtGaris = (model.qtGaris == null) ? 0 : Convert.ToInt32(model.qtGaris.Replace(".", ""));
                Item.ExtensaoPercorridaInicio = (model.ExtensaoPercorridaInicio == null)
                    ? 0
                    : Convert.ToInt32(model.ExtensaoPercorridaInicio.Replace(".", ""));
                Item.DistanciaDescargaGaragem = (model.DistanciaDescargaGaragem == null)
                    ? 0
                    : Convert.ToInt32(model.DistanciaDescargaGaragem.Replace(".", ""));
                
            }
            else
            {
                Item.Motivo = model.Motivo;
            }

            Item.ColetaConvencional = model.ColetaConvencional;
            if (model.ColetaConvencional)
            {
                Item.TipoColetaConvencional = model.TipoColetaConvencional;

                if (model.TipoColetaConvencional == TipoColeta.Outros)
                    Item.TipoColetaEspecifica = model.TipoColetaEspecifica;

            }

            Item.RealizaTransbordo = model.RealizaTransbordo;
            if (model.RealizaTransbordo)
            {
                Item.TransbordoID = int.Parse( model.TransbordoUtilizadoValor);
            }


            Item.RealizaAterro = model.RealizaAterro;
            if (model.RealizaAterro)
            {
                Item.AterroID = int.Parse(model.AterroUtilizadoValor);
            }
            else
            {
                Item.DestinadorID = int.Parse(model.DestinadoraValor);
            }


            Item.Observacao = model.Observacao;
            Item.bAtivo = true;


            BeginTransaction();

            try
            {
                if (model.ColetaExecutadaID == 0)
                    tudoCerto = await _ColetaExecutada.AddNovaProgramacaoAsync(user, Item);
                else
                    tudoCerto = await _ColetaExecutada.UpdateProgramacaoAsync(user, Item);

                if (tudoCerto)
                {
                    Commit();

                    var ProgramacaoID = Item.ColetaExecutadaID;
                    //------------------------SALVA OS EQUIPAMENTOS DESTA PROGRAMACAO------------------------
                    var Result = false;

                    foreach (var i in model.ListaDetalhamentoColeta)
                    {
                        Result = false;
                        if (i.Status == (int) TipoPermissao.Excluir)
                        {
                            if (i.ColetaExecutadaDetalhadaID != 0)
                            {
                                Result = await _ColetaDetalhada.RemoveDadosByIDAsync(user, i.ColetaExecutadaDetalhadaID);
                            }
                        }
                        else
                        {
                            TBColetaExecutadaDetalhada ColetaDetalhada;

                            if (i.Status == (int) TipoPermissao.Incluir)
                            {
                                ColetaDetalhada = new TBColetaExecutadaDetalhada();

                                ColetaDetalhada.ColetaExecutadaID = ProgramacaoID;
                                ColetaDetalhada.HoraChegadaRota = i.HoraChegadaRota;
                                ColetaDetalhada.LocalEnchimentoCaminhao = i.LocalEnchimentoCaminhao;
                                ColetaDetalhada.ExtensaoPercorridaEnchimento = (i.ExtensaoPercorridaEnchimento == null)
                                    ? 0
                                    : Convert.ToInt32(i.ExtensaoPercorridaEnchimento.Replace(".", ""));
                                ColetaDetalhada.HoraEnchimento = i.HoraEnchimento;
                                ColetaDetalhada.horaChegadaLocalDescarga = i.horaChegadaLocalDescarga;
                                ColetaDetalhada.QtResiduo = (i.QtResiduo == null)
                                    ? 0
                                    : Convert.ToInt32(i.QtResiduo.Replace(".", ""));
                                ColetaDetalhada.PlacaVeiculo = i.PlacaVeiculo;
                                ColetaDetalhada.bAtivo = true;

                                Result = await _ColetaDetalhada.AddDadossAsync(user, ColetaDetalhada);
                            }
                            else if (i.Status != (int) TipoPermissao.Consultar && i.Status != (int) TipoPermissao.Print)
                            {
                                ColetaDetalhada = await _ColetaDetalhada.ReturnDadosByID(i.ColetaExecutadaDetalhadaID);

                                ColetaDetalhada.ColetaExecutadaID = ProgramacaoID;
                                ColetaDetalhada.HoraChegadaRota = i.HoraChegadaRota;
                                ColetaDetalhada.LocalEnchimentoCaminhao = i.LocalEnchimentoCaminhao;
                                ColetaDetalhada.ExtensaoPercorridaEnchimento = (i.ExtensaoPercorridaEnchimento == null)
                                    ? 0
                                    : Convert.ToInt32(i.ExtensaoPercorridaEnchimento.Replace(".", ""));
                                ColetaDetalhada.HoraEnchimento = i.HoraEnchimento;
                                ColetaDetalhada.horaChegadaLocalDescarga = i.horaChegadaLocalDescarga;
                                ColetaDetalhada.QtResiduo = (i.QtResiduo == null)
                                    ? 0
                                    : Convert.ToInt32(i.QtResiduo.Replace(".", ""));
                                ColetaDetalhada.PlacaVeiculo = i.PlacaVeiculo;
                                ColetaDetalhada.bAtivo = true;

                                Result = await _ColetaDetalhada.UpdateDadosAsync(user, ColetaDetalhada);
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
    }
}