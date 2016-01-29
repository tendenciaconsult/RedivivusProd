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
    public class ColetaOrdinariaApp : AppServiceBase<SimirContext>, IColetaOrdinariaApp
    {
        private readonly IColetaOrdinariaService _ColetaOrdinaria;
        private readonly IEquipamentoColetaOrdinariaService _EquipamentosColetaOrdinaria;

        public ColetaOrdinariaApp(IColetaOrdinariaService ColetaOrdinaria,
            IEquipamentoColetaOrdinariaService EquipamentosColetaOrdinaria)
        {
            _EquipamentosColetaOrdinaria = EquipamentosColetaOrdinaria;
            _ColetaOrdinaria = ColetaOrdinaria;
        }

        public ColetaOrdinariaVM RetornaColetaOrdinariaByID(int? id, int prefeituraID)
        {
            ColetaOrdinariaVM retorno;

            if (id == null || id == 0)
            {
                retorno = new ColetaOrdinariaVM();
            }
            else
            {
                var Reg = _ColetaOrdinaria.RetornaColetaOrdinariaByID((int) id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = ColetaOrdinariaVM.ToView(Reg);
            }


            return retorno;
        }

        public List<HistoricoColetaOrdinariaVM> CarregaGrid(int idPrefeitura)
        {
            List<HistoricoColetaOrdinariaVM> retorno;

            retorno = new List<HistoricoColetaOrdinariaVM>();

            retorno = _ColetaOrdinaria.GetAllProgramacaoByPrefeituraID(idPrefeitura)
                .Select(x => new HistoricoColetaOrdinariaVM(x)).ToList();


            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, ColetaOrdinariaVM model)
        {
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBColetaOrdinaria ColetaOrdinaria;


            if (model.ColetaordinariaID == 0)
            {
                ColetaOrdinaria = new TBColetaOrdinaria();
            }
            else
            {
                ColetaOrdinaria = await _ColetaOrdinaria.RetornaColetaOrdinariaByID(model.ColetaordinariaID);
            }


            ColetaOrdinaria.RotasID = Convert.ToInt32(model.RotaID);
            ColetaOrdinaria.PrestadoraServicosID = Convert.ToInt32(model.PrestadoraServicosID);
            ColetaOrdinaria.nmColetaOrdinaria = model.nmProgramacao;
            ColetaOrdinaria.bSegunda = model.bSegunda;
            ColetaOrdinaria.bTerca = model.bTerca;
            ColetaOrdinaria.bQuarta = model.bQuarta;
            ColetaOrdinaria.bQuinta = model.bQuinta;
            ColetaOrdinaria.bSexta = model.bSexta;
            ColetaOrdinaria.bSabado = model.bSabado;
            ColetaOrdinaria.bAtivo = true;
            ColetaOrdinaria.PrefeituraID = model.PrefeituraID;

            ColetaOrdinaria.bSegundaFiscalizado = model.bSegundaFiscalizado;
            ColetaOrdinaria.bTercaFiscalizado = model.bTercaFiscalizado;
            ColetaOrdinaria.bQuartaFiscalizado = model.bQuartaFiscalizado;
            ColetaOrdinaria.bQuintaFiscalizado = model.bQuintaFiscalizado;
            ColetaOrdinaria.bSextaFiscalizado = model.bSextaFiscalizado;
            ColetaOrdinaria.bSabadoFiscalizado = model.bSabadoFiscalizado;
            ColetaOrdinaria.bDomingo = model.bDomingo;
            ColetaOrdinaria.bDomingoFiscalizado = model.bDomingoFiscalizado;
            ColetaOrdinaria.qtGarisSegunda = (model.qtGarisSegunda == null)
                ? 0
                : Convert.ToInt32(model.qtGarisSegunda.Replace(".", ""));
            ColetaOrdinaria.qtGarisTerca = (model.qtGarisTerca == null)
                ? 0
                : Convert.ToInt32(model.qtGarisTerca.Replace(".", ""));
            ColetaOrdinaria.qtGarisQuarta = (model.qtGarisQuarta == null)
                ? 0
                : Convert.ToInt32(model.qtGarisQuarta.Replace(".", ""));
            ColetaOrdinaria.qtGarisQuinta = (model.qtGarisQuinta == null)
                ? 0
                : Convert.ToInt32(model.qtGarisQuinta.Replace(".", ""));
            ColetaOrdinaria.qtGarisSexta = (model.qtGarisSexta == null)
                ? 0
                : Convert.ToInt32(model.qtGarisSexta.Replace(".", ""));
            ColetaOrdinaria.qtGarisSabado = (model.qtGarisSabado == null)
                ? 0
                : Convert.ToInt32(model.qtGarisSabado.Replace(".", ""));
            ColetaOrdinaria.qtGarisDomingo = (model.qtGarisDomingo == null) ? 0 : Convert.ToInt32(model.qtGarisDomingo.Replace(".", ""));
            ColetaOrdinaria.qtColetaSegunda = model.qtColetaSegunda;
            ColetaOrdinaria.qtColetaTerca = model.qtColetaTerca;
            ColetaOrdinaria.qtColetaQuarta = model.qtColetaQuarta;
            ColetaOrdinaria.qtColetaQuinta = model.qtColetaQuinta;
            ColetaOrdinaria.qtColetaSexta = model.qtColetaSexta;
            ColetaOrdinaria.qtColetaSabado = model.qtColetaSabado;
            ColetaOrdinaria.qtColetaDomingo = model.qtColetaDomingo;

            BeginTransaction();

            try
            {
                if (model.ColetaordinariaID == 0)
                    tudoCerto = await _ColetaOrdinaria.AddNovaProgramacaoAsync(user, ColetaOrdinaria);
                else
                    tudoCerto = await _ColetaOrdinaria.UpdateProgramacaoAsync(user, ColetaOrdinaria);

                if (tudoCerto)
                {
                    Commit();
                    var ProgramacaoID = ColetaOrdinaria.ColetaOrdinariaID;

                    var Result_Equipamentos = false;

                    foreach (var i in model.Caminhoes)
                    {
                        Result_Equipamentos = false;
                        if (i.Status == (int) TipoPermissao.Excluir)
                        {
                            if (i.EquipamentoID != 0)
                            {
                                Result_Equipamentos =
                                    await
                                        _EquipamentosColetaOrdinaria.RemoveEquipamentosByIDAsync(user, i.EquipamentoID);
                            }
                        }
                        else
                        {
                            TBEquipamentoColetaOrdinaria Equipamentos;

                            if (i.Status == (int) TipoPermissao.Incluir)
                            {
                                Equipamentos = new TBEquipamentoColetaOrdinaria();

                                Equipamentos.ColetaOrdinariaID = ProgramacaoID;
                                Equipamentos.nmEquipamento = i.nmEquipamento;
                                Equipamentos.qtEquipamento = (i.qtEquipamento == null) ? 0 : Convert.ToInt32(i.qtEquipamento.Replace(".", "")); 
                                Equipamentos.Volume = Convert.ToDecimal(i.Volume);
                                Equipamentos.bAtivo = true;

                                Result_Equipamentos =
                                    await _EquipamentosColetaOrdinaria.AddEquipamentosAsync(user, Equipamentos);
                            }
                            else if (i.Status != (int) TipoPermissao.Consultar && i.Status != (int) TipoPermissao.Print)
                            {
                                Equipamentos = await _EquipamentosColetaOrdinaria.ReturnEquipamentoByID(i.EquipamentoID);

                                Equipamentos.ColetaOrdinariaID = ProgramacaoID;
                                Equipamentos.nmEquipamento = i.nmEquipamento;
                                Equipamentos.qtEquipamento = (i.qtEquipamento == null) ? 0 : Convert.ToInt32(i.qtEquipamento.Replace(".", ""));
                                Equipamentos.Volume = Convert.ToDecimal(i.Volume);
                                Equipamentos.bAtivo = true;

                                Result_Equipamentos =
                                    await _EquipamentosColetaOrdinaria.UpdateEquipamentosAsync(user, Equipamentos);
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

        public async Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int idColeta)
        {
            var resultado = new Dictionary<string, ModelState>();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _ColetaOrdinaria.ExcluirProgramacaoAsync(user, idColeta);
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