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
    public class LimpezaEventualApp : AppServiceBase<SimirContext>, ILimpezaEventualApp
    {
        private readonly IEquipamentoLimpezaEventualService _Equipamentos;
        private readonly ILimpezaEventualService _ILimpezaEventualService;

        public LimpezaEventualApp(ILimpezaEventualService ILimpezaEventualService,
            IEquipamentoLimpezaEventualService Equipamentos)
        {
            _ILimpezaEventualService = ILimpezaEventualService;
            _Equipamentos = Equipamentos;
        }

        public object[][] ReturnLimpezaEventualBYData(int prefeituraID, int? dtRef)
        {
            var data = Convert.ToDateTime(dtRef);

            var lista = _ILimpezaEventualService.GetHasLimpezaEventualBYData(prefeituraID, data).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }

        public LimpezaEventualVM GetProgramacaoLimpezaEventual(int? id, int prefeituraID)
        {
            LimpezaEventualVM retorno;

            if (id == null || id == 0)
            {
                retorno = new LimpezaEventualVM();
                retorno.TipoProgramacao = 1;
                retorno.dtInicio = DateTime.Now.ToShortDateString();
                retorno.dtFim = DateTime.Now.ToShortDateString();
            }
            else
            {
                var Reg = _ILimpezaEventualService.ReturnProgramacaoByID((int) id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = LimpezaEventualVM.ToView(Reg);
            }


            return retorno;
        }

        public List<LimpezasFuturasVM> CarregaGrid(int idPrefeitura)
        {
            List<LimpezasFuturasVM> retorno;

            retorno = new List<LimpezasFuturasVM>();

            retorno =
                _ILimpezaEventualService.GetAllProgramacaoNaoRealizadas(idPrefeitura)
                    .Select(x => new LimpezasFuturasVM(x)).ToList();


            return retorno;
        }

        public List<ConsultaProgramacaoVM> BuscaProgramacaoByData(DateTime dtReferencia, int prefeituraID)
        {
            List<ConsultaProgramacaoVM> retorno;

            retorno = new List<ConsultaProgramacaoVM>();

            retorno = _ILimpezaEventualService.BuscaProgramacaoByData(dtReferencia, prefeituraID)
                .Select(x => new ConsultaProgramacaoVM(x)).ToList();


            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, LimpezaEventualVM model)
        {
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBLimpezaEventual LimpezaEventual;


            if (model.LimpezaEventualID == 0)
            {
                LimpezaEventual = new TBLimpezaEventual();
                LimpezaEventual.bServicoOrdinario = false;
            }
            else
            {
                LimpezaEventual = await _ILimpezaEventualService.ReturnProgramacaoByID(model.LimpezaEventualID);
            }
            LimpezaEventual.PrefeituraID = model.PrefeituraID;
            LimpezaEventual.RegiaoAdministrativaID = Convert.ToInt32(model.RegiaoAdministrativaID);
            LimpezaEventual.PrestadoraServicosID = Convert.ToInt32(model.PrestadoraServicosID);
            LimpezaEventual.EnderecoBairroID = Convert.ToInt32(model.EnderecoBairroID);
            LimpezaEventual.EnderecoLogradouroID = Convert.ToInt32(model.EnderecoLogradouroID);
            LimpezaEventual.nmProgramacao = model.nmProgramacao;
            LimpezaEventual.dtInicio = Convert.ToDateTime(model.dtInicio);
            LimpezaEventual.dtFim = Convert.ToDateTime(model.dtFim);
            LimpezaEventual.qtTintasUtilizados = (model.qtTintasUtilizados == null)
                ? 0
                : Convert.ToInt32(model.qtTintasUtilizados.Replace(".", ""));
            LimpezaEventual.nmOutroLogradouro = model.nmLogradouro;
            LimpezaEventual.qtGaris = (model.qtGaris == null) ? 0 : Convert.ToInt32(model.qtGaris.Replace(".", ""));
            LimpezaEventual.TipoProgramacao = model.TipoProgramacao;
            LimpezaEventual.bAtivo = true;

            switch (model.TipoProgramacao)
            {
                case 1:
                    LimpezaEventual.nmTipoProgramacao = "Capina";
                    break;
                case 2:
                    LimpezaEventual.nmTipoProgramacao = "Varrição";
                    break;
                case 3:
                    LimpezaEventual.nmTipoProgramacao = "Roçagem";
                    break;
                case 4:
                    LimpezaEventual.nmTipoProgramacao = "Raspagem";
                    break;
                case 5:
                    LimpezaEventual.nmTipoProgramacao = "Podas ou Arranquios de Árvores";
                    break;
                case 6:
                    LimpezaEventual.nmTipoProgramacao = "Lavagem de vias";
                    break;
                case 7:
                    LimpezaEventual.nmTipoProgramacao = "Limpeza de Galerias pluviais";
                    break;
                case 8:
                    LimpezaEventual.nmTipoProgramacao = "Pintura de guias";
                    break;
                case 9:
                    LimpezaEventual.nmTipoProgramacao = "Limpeza de boca de lobos";
                    break;
                case 10:
                    LimpezaEventual.nmTipoProgramacao = "Multirão de Limpeza";
                    break;
                default:
                    LimpezaEventual.nmTipoProgramacao = "";
                    break;
            }


            BeginTransaction();

            try
            {
                if (model.LimpezaEventualID == 0)
                    tudoCerto = await _ILimpezaEventualService.AddNovaProgramacaoAsync(user, LimpezaEventual);
                else
                    tudoCerto = await _ILimpezaEventualService.UpdateProgramacaoAsync(user, LimpezaEventual);

                if (tudoCerto)
                {
                    Commit();
                    var ProgramacaoID = LimpezaEventual.LimpezaEventualID;

                    var Result_Equipamentos = false;

                    foreach (var i in model.Equipamentos)
                    {
                        Result_Equipamentos = false;
                        if (i.Status == (int) TipoPermissao.Excluir)
                        {
                            if (i.EquipamentoID != 0)
                            {
                                Result_Equipamentos =
                                    await _Equipamentos.RemoveEquipamentosByIDAsync(user, i.EquipamentoID);
                            }
                        }
                        else
                        {
                            TBEquipamentoLimpezaEventual Equipamentos;

                            if (i.Status == (int) TipoPermissao.Incluir)
                            {
                                Equipamentos = new TBEquipamentoLimpezaEventual();

                                Equipamentos.LimpezaEventualID = ProgramacaoID;
                                Equipamentos.nmTipoEquipamento = i.nmEquipamento;
                                Equipamentos.Quantidade = (i.qtEquipamento == null) ? 0 : Convert.ToInt32(i.qtEquipamento.Replace(".", ""));
                                Equipamentos.bAtivo = true;

                                Result_Equipamentos = await _Equipamentos.AddEquipamentosAsync(user, Equipamentos);
                            }
                            else if (i.Status != (int) TipoPermissao.Consultar && i.Status != (int) TipoPermissao.Print)
                            {
                                Equipamentos = await _Equipamentos.ReturnEquipamentoByID(i.EquipamentoID);

                                Equipamentos.LimpezaEventualID = ProgramacaoID;
                                Equipamentos.nmTipoEquipamento = i.nmEquipamento;
                                Equipamentos.Quantidade = (i.qtEquipamento == null) ? 0 : Convert.ToInt32(i.qtEquipamento.Replace(".", ""));
                                Equipamentos.bAtivo = true;

                                Result_Equipamentos = await _Equipamentos.UpdateEquipamentosAsync(user, Equipamentos);
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

        public async Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int LimpezaEventualID)
        {
            var resultado = new Dictionary<string, ModelState>();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _ILimpezaEventualService.ExcluirProgramacaoAsync(user, LimpezaEventualID);
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