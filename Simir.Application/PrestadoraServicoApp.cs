using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.Helpers;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class PrestadoraServicoApp : AppServiceBase<SimirContext>, IPrestadoraServicoApp
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IPrestadoraServicoService _service;

        public PrestadoraServicoApp(IEnderecoService enderecoService,
            IPrestadoraServicoService service
            )
        {
            _service = service;
            _enderecoService = enderecoService;
        }

        public async Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, PrestadoraServicoVM model)
        {
            var resultado = new Dictionary<string, ModelState>();
            var prefeitura = user.TBUsuario.TBPrefeitura;

            TBPrestadoraServico prestadora;

            if (model.PrestadoraServicosID == 0)
            {
                prestadora = new TBPrestadoraServico();
            }
            else
            {
                prestadora = _service.GetById(model.PrestadoraServicosID);
            }
            prestadora.PrefeituraID = prefeitura.PrefeituraID;
            prestadora.nmPrestadoraServico = model.nmPrestadoraServico;
            prestadora.nmRazaoSocial = model.nmRazaoSocial;
            prestadora.CNPJ = model.CNPJ;
            prestadora.tipoPrestadoraServicos = model.tipoPrestadoraServicos;

        /*
        prestadora.Telefone1 = model.Telefone1;
        prestadora.Telefone2 = model.Telefone2;
        prestadora.bPrefeitura = model.bPrefeitura;
        prestadora.qtTotalTrabalhadoresContratados = NullableHelper.ParseNullable<Int32>(model.qtTotalTrabalhadoresContratados, Int32.TryParse);
        prestadora.vlTotalContratado = NullableHelper.ParseNullable<Int32>(model.vlTotalContratado, Int32.TryParse);
        prestadora.dtVencimento = NullableHelper.ParseNullable<DateTime>(model.dtVencimento, DateTime.TryParse);
        prestadora.vlGari = NullableHelper.ParseNullable<Decimal>(model.vlGari, Decimal.TryParse);
        prestadora.VlColetor = NullableHelper.ParseNullable<Decimal>(model.VlColetor, Decimal.TryParse);
        prestadora.vlEncarregadoServico = NullableHelper.ParseNullable<Decimal>(model.vlEncarregadoServico,
            Decimal.TryParse);
        prestadora.vlMotoristaCaminhaoAberto = NullableHelper.ParseNullable<Decimal>(
            model.vlMotoristaCaminhaoAberto, Decimal.TryParse);
        prestadora.vlMotoristaaminhaoCompactador =
            NullableHelper.ParseNullable<Decimal>(model.vlMotoristaaminhaoCompactador, Decimal.TryParse);
        prestadora.vlOperadorVarredeira = NullableHelper.ParseNullable<Decimal>(model.vlOperadorVarredeira,
            Decimal.TryParse);
        prestadora.bRealizaPintura = model.bRealizaPintura;
        prestadora.bRealizaVarricao = model.bRealizaVarricao;
        prestadora.bRealizaPodasArvores = model.bRealizaPodasArvores;
        prestadora.bRealizaLavagem = model.bRealizaLavagem;
        prestadora.bRealizaColeta = model.bRealizaColeta;
        if (prestadora.bRealizaPintura)
        {
            prestadora.qtFuncPintura = Int32.Parse(model.qtFuncPintura);
            prestadora.qtFundoReservaPintura = Decimal.Parse(model.qtFundoReservaPintura);
        }


        if (prestadora.bRealizaVarricao)
        {
            prestadora.qtkmSargetaVarridoContratados = Int32.Parse(model.qtkmSargetaVarridoContratados);
            prestadora.qtFuncVarricao = Int32.Parse(model.qtFuncVarricao);
            prestadora.qtFundoReservaVarricao = Decimal.Parse(model.qtFundoReservaVarricao);
            prestadora.vlKmVarrido = Decimal.Parse(model.vlKmVarrido);
            prestadora.vlKgResidoVarrido = Decimal.Parse(model.vlKgResidoVarrido);
        }
        if (prestadora.bRealizaPodasArvores)
        {
            prestadora.qtFuncPodasArvores = Int32.Parse(model.qtFuncPodasArvores);
            prestadora.qtFundoReservaPodasArvores = Decimal.Parse(model.qtFundoReservaPodasArvores);
        }
        if (prestadora.bRealizaLavagem)
        {
        }
        if (prestadora.bRealizaColeta)
        {
            prestadora.qtColetores = Int32.Parse(model.qtColetores);
            prestadora.qtMotoristas = Int32.Parse(model.qtMotoristas);
            prestadora.qtEncarregados = Int32.Parse(model.qtEncarregados);
        }*/

        prestadora.TBEndereco = EnderecoVM.ToModel(model.Endereco);

            prestadora.TBEndereco.EnderecoID = prestadora.EnderecoID;

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = _enderecoService.ValidaEndereco(prestadora.TBEndereco);
                if (tudoCerto)
                {
                    if (model.PrestadoraServicosID == 0)
                        tudoCerto = await _service.AddAsync(user, prestadora);
                    else
                        tudoCerto = await _service.UpdateAsync(user, prestadora);
                }

                if (tudoCerto) await CommitAsync();

                /*
                foreach (var item in model.Equipamentos)
                {
                    if (item.Status == (int) TipoPermissao.Incluir && item.EquipamentoID == 0)
                    {
                        TBPrestadoraServicosEquipamentoPoda equip = null;
                        EquipamentoVM.ToEquipamento(ref equip, item);
                        equip.PrestadoraServicosID = prestadora.PrestadoraServicosID;
                        tudoCerto = await _service.AddEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                    else if (item.Status == (int) TipoPermissao.Alterar && item.EquipamentoID != 0)
                    {
                        var equip =
                            prestadora.EquipamentosPoda.FirstOrDefault(
                                x => x.PrestadoraServicosEquipamentosID == item.EquipamentoID);
                        EquipamentoVM.ToEquipamento(ref equip, item);
                        tudoCerto = await _service.UpdateEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                    else if (item.Status == (int) TipoPermissao.Excluir && item.EquipamentoID != 0)
                    {
                        var equip =
                            prestadora.EquipamentosPoda.FirstOrDefault(
                                x => x.PrestadoraServicosEquipamentosID == item.EquipamentoID);
                        equip.bAtivo = false;
                        tudoCerto = await _service.UpdateEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                }
                foreach (var item in model.Varredeiros)
                {
                    if (item.Status == (int) TipoPermissao.Incluir && item.EquipamentoID == 0)
                    {
                        TBPrestadoraServicosVarredeira equip = null;
                        EquipamentoVM.ToEquipamento(ref equip, item);
                        equip.PrestadoraServicosID = prestadora.PrestadoraServicosID;
                        tudoCerto = await _service.AddEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                    else if (item.Status == (int) TipoPermissao.Alterar && item.EquipamentoID != 0)
                    {
                        var equip =
                            prestadora.EquipamentosVerredeira.FirstOrDefault(
                                x => x.PrestadoraServicosEquipamentosID == item.EquipamentoID);
                        EquipamentoVM.ToEquipamento(ref equip, item);
                        tudoCerto = await _service.UpdateEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                    else if (item.Status == (int) TipoPermissao.Excluir && item.EquipamentoID != 0)
                    {
                        var equip =
                            prestadora.EquipamentosVerredeira.FirstOrDefault(
                                x => x.PrestadoraServicosEquipamentosID == item.EquipamentoID);
                        equip.bAtivo = false;
                        tudoCerto = await _service.UpdateEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                }
                foreach (var item in model.Caminhoes)
                {
                    if (item.Status == (int) TipoPermissao.Incluir && item.EquipamentoID == 0)
                    {
                        TBPrestadoraServicosCaminhao equip = null;
                        CaminhaoVM.ToEquipamento(ref equip, item);
                        equip.PrestadoraServicosID = prestadora.PrestadoraServicosID;
                        tudoCerto = await _service.AddEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                    else if (item.Status == (int) TipoPermissao.Alterar && item.EquipamentoID != 0)
                    {
                        var equip =
                            prestadora.Caminhoes.FirstOrDefault(
                                x => x.PrestadoraServicosEquipamentosID == item.EquipamentoID);
                        CaminhaoVM.ToEquipamento(ref equip, item);
                        tudoCerto = await _service.UpdateEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                    else if (item.Status == (int) TipoPermissao.Excluir && item.EquipamentoID != 0)
                    {
                        var equip =
                            prestadora.Caminhoes.FirstOrDefault(
                                x => x.PrestadoraServicosEquipamentosID == item.EquipamentoID);
                        equip.bAtivo = false;
                        tudoCerto = await _service.UpdateEquipamentoAsync(user, equip);
                        if (tudoCerto) Commit();
                    }
                }
                */
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

        public async Task<IDictionary<string, ModelState>> Excluir(AspNetUser user, int idPrestadora)
        {
            var resultado = new Dictionary<string, ModelState>();
            var prefeitura = user.TBUsuario.TBPrefeitura;

            TBPrestadoraServico prestadora;
            prestadora = _service.GetById(idPrestadora);

            BeginTransaction();

            var tudoCerto = true;
            try
            {
                if (tudoCerto)
                {
                    prestadora.bAtivo = false;
                    tudoCerto = await _service.UpdateAsync(user, prestadora);
                }
                /*
                foreach (var item in prestadora.Equipamentos)
                {
                    item.bAtivo = false;
                    tudoCerto = await _service.UpdateEquipamentoAsync(user, item);
                }*/
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

        public List<PrestadoraServicoBasicoVM> BuscaProgramacao(int prefeituraID)
        {
            List<PrestadoraServicoBasicoVM> retorno;

            retorno = new List<PrestadoraServicoBasicoVM>();

            retorno =
                _service.GetAllByPrefeitura(prefeituraID)
                    .Select(x => new PrestadoraServicoBasicoVM(x)).ToList();


            return retorno;
        }


        public PrestadoraServicoVM GetPrestadora(int? id, int prefeituraID)
        {
            PrestadoraServicoVM retorno;
            if (id == null || id == 0)
            {
                retorno = new PrestadoraServicoVM();
            }
            else
            {
                var pres = _service.GetById((int) id);
                if (prefeituraID != pres.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (!pres.bAtivo)
                {
                    throw new Exception("Prestadora de serviço já não existe mais no sistema");
                }

                retorno = PrestadoraServicoVM.ToView(pres);
            }
    
            return retorno;
        }

        public object[][] ReturnPrestadoraServicosByPrefeitura(int prefeituraID)
        {
            return _service.ReturnPrestadoraServicosByPrefeitura(prefeituraID);
        }
    }
}