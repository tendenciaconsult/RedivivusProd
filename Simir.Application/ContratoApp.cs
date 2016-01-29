using Simir.Application.Interfaces;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Application.ViewModels.ContratoVMs;
using Simir.Domain.Entities;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Simir.Application.Helpers;
using Simir.Domain.Enuns;

namespace Simir.Application
{
    public class ContratoApp : AppServiceBase<SimirContext>, IContratoApp
    {
        private readonly IContratoService _service;
        private readonly IServicoService _servicoService;
        private readonly IContratoFuncionarioService _funcionarioService;
        private readonly IContratoEquipamentoService _equipamentoService;
        private readonly IContratoVeiculoService _veiculoService;

        public ContratoApp(
            IContratoService service,
            IServicoService servicoService,
            IContratoFuncionarioService funcionarioService,
            IContratoEquipamentoService equipamentoService,
            IContratoVeiculoService veiculoService
            )
        {
            _service = service;
            _servicoService = servicoService;
            _funcionarioService = funcionarioService;
            _equipamentoService = equipamentoService;
            _veiculoService = veiculoService;
        }

        public ContratoVM GetContrato(int? id, int prefeituraID)
        {
            ContratoVM retorno;
            if (id == null || id == 0)
            {
                retorno = new ContratoVM();

                retorno.Servicos = _servicoService.GetAll().Select(x=>new ContratoServicoVM(x,false)).ToList();
            }
            else
            {
                var pres = _service.GetById2((int)id);
                if (prefeituraID != pres.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (!pres.bAtivo)
                {
                    throw new Exception("Prestadora de serviço já não existe mais no sistema");
                }

                retorno = ContratoVM.ToView(pres);
                var ids = pres.Servicos.Select(x => x.ServicoID);
                retorno.Servicos = _servicoService.GetAll().Select(x =>  new ContratoServicoVM(x, ids.Contains(x.ServicoID))).ToList();

                retorno.Funcoes = ContratoFuncaoVM.ToView(_funcionarioService.GetAll().ToList());
                retorno.Equipamentos = ContratoEquipamentoVM.ToView(_equipamentoService.GetAll().ToList());
                retorno.Veiculos = ContratoVeiculoVM.ToView(_veiculoService.GetAll().ToList());
            }

            
            return retorno;
        }


        public Task<IDictionary<string, ModelState>> Excluir(AspNetUser user, int iD)
        {
            throw new NotImplementedException();
        }

        public async Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, ContratoVM model)
        {
            var resultado = new Dictionary<string, ModelState>();
            var prefeitura = user.TBUsuario.TBPrefeitura;

            TBContrato contrato;

            if (model.ID == 0)
            {
                contrato = new TBContrato();
            }
            else
            {
                contrato = _service.GetById2(model.ID);
            }
            contrato.PrefeituraID = prefeitura.PrefeituraID;
            contrato.NumeroContrato = model.NumeroContrato;
            contrato.dtInicioContrato = NullableHelper.ParseNullable<DateTime>(model.InicioContrato, DateTime.TryParse);
            contrato.dtTerminoContrato = NullableHelper.ParseNullable<DateTime>(model.TerminoContrato, DateTime.TryParse);
            contrato.PrestadoraID = Int32.Parse( model.PrestadoraValor);
            contrato.TotalFuncionarios = NullableHelper.ParseNullable<int>(model.TotalFuncionarios, Int32.TryParse);
            contrato.vlTotalContrato = NullableHelper.ParseNullable<decimal>(model.ValorTotalContrato, Decimal.TryParse);
            contrato.vlPagoAteHoje = NullableHelper.ParseNullable<decimal>(model.ValorPagoAteHoje, Decimal.TryParse);
            contrato.FormaPagamento = model.FormaPagamento;
            contrato.dtUltimoPagamento = NullableHelper.ParseNullable<DateTime>(model.DataUltimoPagamento, DateTime.TryParse);

            /*
            var ids = model.Servicos.Where(x => x.Status).Select(x => x.ID);
            contrato.Servicos = _servicoService.GetAll().Where(x => ids.Contains(x.ServicoID)).ToList();
            */

            foreach (var item in model.Servicos)
            {
                if ( item.Status && contrato.Servicos.FirstOrDefault(x=>x.ServicoID == item.ID)== null)
                {
                    contrato.Servicos.Add(_servicoService.GetById(item.ID));
                }

                if (!item.Status && contrato.Servicos.FirstOrDefault(x => x.ServicoID == item.ID) != null)
                {
                    contrato.Servicos.Remove(contrato.Servicos.FirstOrDefault(x => x.ServicoID == item.ID));
                }
            }

            foreach (var item in model.Funcoes)
            {
                if (item.Status == (int)TipoPermissao.Excluir && item.ID > 0)
                {
                    contrato.Funcoes.Remove(contrato.Funcoes.FirstOrDefault(x => x.ContratoID == item.ID));
                }

                if (item.Status == (int)TipoPermissao.Incluir && item.ID == 0)
                {
                    contrato.Funcoes.Add(ContratoFuncaoVM.ToModel(item));
                }
            }

            foreach (var item in model.Veiculos)
            {
                if (item.Status == (int)TipoPermissao.Excluir && item.ID > 0)
                {
                    contrato.Veiculos.Remove(contrato.Veiculos.FirstOrDefault(x => x.ContratoID == item.ID));
                }

                if (item.Status == (int)TipoPermissao.Incluir && item.ID == 0)
                {
                    contrato.Veiculos.Add(ContratoVeiculoVM.ToModel(item));
                }
            }

            foreach (var item in model.Equipamentos)
            {
                if (item.Status == (int)TipoPermissao.Excluir && item.ID > 0)
                {
                    contrato.Equipamentos.Remove(contrato.Equipamentos.FirstOrDefault(x => x.ContratoID == item.ID));
                }

                if (item.Status == (int)TipoPermissao.Incluir && item.ID == 0)
                {
                    contrato.Equipamentos.Add(ContratoEquipamentoVM.ToModel(item));
                }
            }



            BeginTransaction();

            var tudoCerto = true;
            try
            {
                if (tudoCerto)
                {
                    if (model.ID == 0)
                        tudoCerto = await _service.AddAsync(user, contrato);
                    else
                        tudoCerto = await _service.UpdateAsync(user, contrato);
                }

                if (tudoCerto) await CommitAsync();
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

        public string[][] GetAllFuncaoTitulo()
        {
            return _funcionarioService.GetAllFuncaoTitulo();
        }

        public string[][] GetFuncaoTituloBySubtitulo(int id)
        {
            return _funcionarioService.GetFuncaoTituloBySubtitulo(id);
        }
    }
}
