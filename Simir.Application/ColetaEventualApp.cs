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
    public class ColetaEventualApp : AppServiceBase<SimirContext>, IColetaEventualApp
    {
        private readonly IColetaEventualService _ColetaEventual;
        private readonly IEnderecosColetaEventualService _EnderecosColetaEventual;
        private readonly IEquipamentoColetaEventualService _EquipamentoColetaEventual;

        public ColetaEventualApp(IColetaEventualService ColetaEventual,
            IEquipamentoColetaEventualService EquipamentoColetaEventual,
            IEnderecosColetaEventualService EnderecosColetaEventual)
        {
            _ColetaEventual = ColetaEventual;
            _EquipamentoColetaEventual = EquipamentoColetaEventual;
            _EnderecosColetaEventual = EnderecosColetaEventual;
        }

        public List<ConsultaProgramacaoColetaEventualVM> BuscaProgramacaoByData(DateTime dtReferencia, int prefeituraID)
        {
            List<ConsultaProgramacaoColetaEventualVM> retorno;

            retorno = new List<ConsultaProgramacaoColetaEventualVM>();

            retorno = _ColetaEventual.BuscaProgramacaoByData(dtReferencia, prefeituraID)
                .Select(x => new ConsultaProgramacaoColetaEventualVM(x)).ToList();


            return retorno;
        }

        public ColetaEventualVM RetornaColetaOrdinariaByID(int? id, int prefeituraID)
        {
            ColetaEventualVM retorno;

            if (id == null || id == 0)
            {
                retorno = new ColetaEventualVM();
                retorno.dtReferencia = Convert.ToDateTime(DateTime.Now).ToShortDateString();
            }
            else
            {
                var Reg = _ColetaEventual.RetornaColetaEventualByID((int)id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = ColetaEventualVM.ToView(Reg);
            }

            return retorno;
        }

        public List<HistoricoColetaEventualVM> BuscaProgramacao(int idPrefeitura)
        {
            List<HistoricoColetaEventualVM> retorno;

            retorno = new List<HistoricoColetaEventualVM>();

            retorno = _ColetaEventual.GetAllProgramacaoByPrefeituraID(idPrefeitura)
                .Select(x => new HistoricoColetaEventualVM(x)).ToList();


            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, ColetaEventualVM model)
        {
            //------------------------salva a programação------------------------
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBColetaEventual ColetaEventual;


            if (model.ColetaEventualID == 0)
            {
                ColetaEventual = new TBColetaEventual();
            }
            else
            {
                ColetaEventual = await _ColetaEventual.RetornaColetaEventualByID(model.ColetaEventualID);
            }

            ColetaEventual.PrefeituraID = model.PrefeituraID;
            ColetaEventual.PrestadoraServicosID = Convert.ToInt32(model.PrestadoraServicosID);
            if (model.RotaID != null)
            {
                ColetaEventual.RotasID = Convert.ToInt32(model.RotaID);
            }


            ColetaEventual.dtColeta = Convert.ToDateTime(model.dtReferencia);
            ColetaEventual.DistanciaInicial = (model.DistanciaInicial == null)
                ? 0
                : Convert.ToInt32(model.DistanciaInicial.Replace(".", ""));
            ColetaEventual.DistanciaFinal = (model.DistanciaFinal == null)
                ? 0
                : Convert.ToInt32(model.DistanciaFinal.Replace(".", ""));
            ColetaEventual.qtGari = (model.qtGaris == null) ? 0 : Convert.ToInt32(model.qtGaris.Replace(".", ""));
            ColetaEventual.nmColetaEventual = model.nmProgramacao;
            ColetaEventual.bColetaOrdinaria = false;
            ColetaEventual.qtColetaDia = 1;
            ColetaEventual.bAtivo = true;


            BeginTransaction();

            try
            {
                if (model.ColetaEventualID == 0)
                    tudoCerto = await _ColetaEventual.AddNovaProgramacaoAsync(user, ColetaEventual);
                else
                    tudoCerto = await _ColetaEventual.UpdateProgramacaoAsync(user, ColetaEventual);

                if (tudoCerto)
                {
                    Commit();

                    var ProgramacaoID = ColetaEventual.ColetaEventualID;
                    //------------------------SALVA OS EQUIPAMENTOS DESTA PROGRAMACAO------------------------
                    var Result_Equipamentos = false;

                    foreach (var i in model.Caminhoes)
                    {
                        Result_Equipamentos = false;
                        if (i.Status == (int)TipoPermissao.Excluir)
                        {
                            if (i.EquipamentoID != 0)
                            {
                                Result_Equipamentos =
                                    await _EquipamentoColetaEventual.RemoveEquipamentosByIDAsync(user, i.EquipamentoID);
                            }
                        }
                        else
                        {
                            TBEquipamentoColetaEventual Equipamentos;

                            if (i.Status == (int)TipoPermissao.Incluir)
                            {
                                Equipamentos = new TBEquipamentoColetaEventual();

                                Equipamentos.ColetaEventualID = ProgramacaoID;
                                Equipamentos.nmEquipamento = i.nmEquipamento;
                                Equipamentos.qtEquipamento = (i.qtEquipamento == null)
                                    ? 0
                                    : Convert.ToInt32(i.qtEquipamento.Replace(".", ""));
                                Equipamentos.Volume = Convert.ToDecimal(i.Volume);
                                Equipamentos.bAtivo = true;

                                Result_Equipamentos =
                                    await _EquipamentoColetaEventual.AddEquipamentosAsync(user, Equipamentos);
                            }
                            else if (i.Status != (int)TipoPermissao.Consultar && i.Status != (int)TipoPermissao.Print)
                            {
                                Equipamentos = await _EquipamentoColetaEventual.ReturnEquipamentoByID(i.EquipamentoID);

                                Equipamentos.ColetaEventualID = ProgramacaoID;
                                Equipamentos.nmEquipamento = i.nmEquipamento;
                                Equipamentos.qtEquipamento = (i.qtEquipamento == null)
                                    ? 0
                                    : Convert.ToInt32(i.qtEquipamento.Replace(".", ""));
                                Equipamentos.Volume = Convert.ToDecimal(i.Volume);
                                Equipamentos.bAtivo = true;

                                Result_Equipamentos =
                                    await _EquipamentoColetaEventual.UpdateEquipamentosAsync(user, Equipamentos);
                            }
                        }
                        if (Result_Equipamentos) Commit();
                    }
                    //------------------------SALVA OS ENDERECOS DESTA PROGRAMACAO------------------------
                    var Result_Enderecos = false;

                    foreach (var i in model.ListaEnderecoColeta)
                    {
                        Result_Enderecos = false;
                        if (model.RotaID != null || model.RotaID == "0")
                        {
                            Result_Enderecos =
                                                await
                                                    _EnderecosColetaEventual.RemoveEnderecosByIDAsync(user,
                                                        i.EnderecosColetaEventualID);
                        }
                        else
                        {
                            if (i.Status == (int)TipoPermissao.Excluir)
                            {
                                if (i.EnderecosColetaEventualID != 0)
                                {
                                    Result_Enderecos =
                                        await
                                            _EnderecosColetaEventual.RemoveEnderecosByIDAsync(user,
                                                i.EnderecosColetaEventualID);
                                }
                            }
                            else
                            {
                                TBEnderecosColetaEventual Enderecos;

                                if (i.Status == (int)TipoPermissao.Incluir)
                                {
                                    Enderecos = new TBEnderecosColetaEventual();

                                    Enderecos.ColetaEventualID = ProgramacaoID;
                                    Enderecos.nmSolicitante = i.nmSolicitante;
                                    Enderecos.Telefone = i.Telefone;
                                    Enderecos.EnderecoColeta = i.nmLocalColeta;
                                    Enderecos.ItensColeta = i.nmItemsRecolhido;
                                    Enderecos.bAtivo = true;

                                    Result_Enderecos = await _EnderecosColetaEventual.AddEnderecosAsync(user, Enderecos);
                                }
                                else if (i.Status != (int)TipoPermissao.Consultar && i.Status != (int)TipoPermissao.Print)
                                {
                                    Enderecos =
                                        await _EnderecosColetaEventual.ReturnEnderecosByID(i.EnderecosColetaEventualID);

                                    Enderecos.ColetaEventualID = ProgramacaoID;
                                    Enderecos.nmSolicitante = i.nmSolicitante;
                                    Enderecos.Telefone = i.Telefone;
                                    Enderecos.EnderecoColeta = i.nmLocalColeta;
                                    Enderecos.ItensColeta = i.nmItemsRecolhido;
                                    Enderecos.bAtivo = true;

                                    Result_Enderecos = _EnderecosColetaEventual.UpdateEnderecos(user, Enderecos);
                                }
                            }
                        }
                        if (Result_Enderecos) await CommitAsync();
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
                tudoCerto = await _ColetaEventual.ExcluirProgramacaoAsync(user, idColeta);
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