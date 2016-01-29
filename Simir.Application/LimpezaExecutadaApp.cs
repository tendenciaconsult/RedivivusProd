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
    public class LimpezaExecutadaApp : AppServiceBase<SimirContext>, ILimpezaExecutadaApp
    {
        private readonly IEquipamentoLimpezaExecutadaService _EquipamentoLimpezaExecutadaService;
        private readonly ILimpezaEventualService _LimpezaEventual;
        private readonly ILimpezaExecutadaService _LimpezaExecutadaService;

        public LimpezaExecutadaApp(ILimpezaExecutadaService LimpezaExecutadaService,
            IEquipamentoLimpezaExecutadaService EquipamentoLimpezaExecutadaService,
            ILimpezaEventualService LimpezaEventual)
        {
            _LimpezaExecutadaService = LimpezaExecutadaService;
            _EquipamentoLimpezaExecutadaService = EquipamentoLimpezaExecutadaService;
            _LimpezaEventual = LimpezaEventual;
        }

        public LimpezaExecutadaVM GetProgramacaoLimpezaEventual(int? id, int prefeituraID)
        {
            LimpezaExecutadaVM retorno;

            if (id == null || id == 0)
            {
                retorno = new LimpezaExecutadaVM();
                retorno.dtProgramacao = Convert.ToString(DateTime.Now).Substring(0, 10);
            }
            else
            {
                var Reg = _LimpezaEventual.ReturnProgramacaoByID((int) id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = LimpezaExecutadaVM.ToView(Reg);
            }


            return retorno;
        }

        public object[][] ReturnLimpezaEventualBYData(int prefeituraID, string Data)
        {
            var dtReferencia = Convert.ToDateTime(Data);

            var lista = _LimpezaExecutadaService.GetHasLimpezaEventualBYData(prefeituraID, dtReferencia).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }

        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, LimpezaExecutadaVM model)
        {
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBLimpezaExecutada LimpezaExecutada;


            if (model.LimpezaExecutadaID == 0)
            {
                LimpezaExecutada = new TBLimpezaExecutada();
            }
            else
            {
                LimpezaExecutada = await _LimpezaExecutadaService.ReturnProgramacaoByID(model.LimpezaExecutadaID);
            }

            LimpezaExecutada.PrefeituraID = model.PrefeituraID;
            LimpezaExecutada.LimpezaExecutadaID = Convert.ToInt32(model.ProgramacaoID);
            LimpezaExecutada.nmLimpezaExecutada = model.nmProgramacao;
            LimpezaExecutada.dtProgramacao = Convert.ToDateTime(model.dtProgramacao);
            LimpezaExecutada.ProgramacaoRealizada = model.bProgramacaoNaoRealizada;
            LimpezaExecutada.nmMotivoNaoExecucao = model.MotivoProgramacaoNaoRealizada;
            if (model.bProgramacaoNaoRealizada)
            {
                LimpezaExecutada.dtInicio = Convert.ToDateTime(model.dtInicio);
                LimpezaExecutada.dtFim = Convert.ToDateTime(model.dtFim);
                LimpezaExecutada.qtGaris = (model.qtGaris == null) ? 0 : Convert.ToInt32(model.qtGaris.Replace(".", ""));
                LimpezaExecutada.qtSupervisor = (model.qtSupervisor == null)
                    ? 0
                    : Convert.ToInt32(model.qtSupervisor.Replace(".", ""));
                LimpezaExecutada.qtEncarregado = (model.qtEncarregado == null)
                    ? 0
                    : Convert.ToInt32(model.qtEncarregado.Replace(".", ""));
            }
            LimpezaExecutada.sObservacao = model.sObservacao;
            LimpezaExecutada.bAtivo = true;


            BeginTransaction();

            try
            {
                if (model.LimpezaExecutadaID == 0)
                    tudoCerto = await _LimpezaExecutadaService.AddNovaProgramacaoAsync(user, LimpezaExecutada);
                else
                    tudoCerto = await _LimpezaExecutadaService.UpdateProgramacaoAsync(user, LimpezaExecutada);

                if (tudoCerto)
                {
                    Commit();
                    var ProgramacaoID = LimpezaExecutada.LimpezaExecutadaID;

                    var Result_Equipamentos = false;

                    foreach (var i in model.Equipamentos)
                    {
                        Result_Equipamentos = false;
                        if (i.Status == 8)
                        {
                            if (i.EquipamentoID != 0)
                            {
                                Result_Equipamentos =
                                    await
                                        _EquipamentoLimpezaExecutadaService.RemoveEquipamentosByIDAsync(user,
                                            i.EquipamentoID);
                            }
                        }
                        else
                        {
                            TBEquipamentoLimpezaExecutada Equipamentos;

                            if (i.Status == 4)
                            {
                                Equipamentos = new TBEquipamentoLimpezaExecutada();

                                Equipamentos.LimpezaExecutadaID = ProgramacaoID;
                                Equipamentos.nmTipoEquipamento = i.nmEquipamento;
                                Equipamentos.Quantidade = (i.qtEquipamento == null) ? 0 : Convert.ToInt32(i.qtEquipamento.Replace(".", ""));
                                Equipamentos.bAtivo = true;

                                Result_Equipamentos =
                                    await _EquipamentoLimpezaExecutadaService.AddEquipamentosAsync(user, Equipamentos);
                            }
                            else if (i.Status != 1 && i.Status != 16)
                            {
                                Equipamentos =
                                    await _EquipamentoLimpezaExecutadaService.ReturnEquipamentoByID(i.EquipamentoID);

                                Equipamentos.LimpezaExecutadaID = ProgramacaoID;
                                Equipamentos.nmTipoEquipamento = i.nmEquipamento;
                                Equipamentos.Quantidade = (i.qtEquipamento == null) ? 0 : Convert.ToInt32(i.qtEquipamento.Replace(".", "")); 
                                Equipamentos.bAtivo = true;

                                Result_Equipamentos =
                                    await
                                        _EquipamentoLimpezaExecutadaService.UpdateEquipamentosAsync(user, Equipamentos);
                            }
                        }

                        if (Result_Equipamentos) Commit();
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