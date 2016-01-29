using System;
using System.Threading.Tasks;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Simir.Application.ViewModels.DestinadorVMs;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;

namespace Simir.Application
{
    public class DestinadorApp : AppServiceBase<SimirContext>, IDestinadorApp
    {
        private readonly IDestinadorService _service;
        private readonly IDestinadorTratadoService _serviceTratado;
        private readonly IServiceBase<TBResiduosDestinadorRejeito> _serviceRejeito;

        public DestinadorApp(
            IDestinadorService service,
            IDestinadorTratadoService serviceTratado,
            IServiceBase<TBResiduosDestinadorRejeito> serviceRejeito
            )
        {
            _service = service;
            _serviceTratado = serviceTratado;
            _serviceRejeito = serviceRejeito;
        }


        public ResiduosRecebidosVM Novo(int empresaID)
        {
            var novo = new ResiduosRecebidosVM();

            
            return novo;
        }

        public ResiduosRecebidosVM GetById(int empresaID, int residuoGeradoID)
        {
            var model = _service.GetById(residuoGeradoID);
            if (model.EmpresaID != empresaID)
            {
                throw new Exception("Resíduo não gerado pela sua empresa");
            }

            var retorno = ResiduosRecebidosVM.ToView(model);

           
            return retorno;
        }


        public async Task<IDictionary<string, ModelState>> SalvarResiduoGeradoAsync(int empresaID, ResiduosRecebidosVM model)
        {
            var resultado = new Dictionary<string, ModelState>();

            TBResiduosDestinadore residuoDestinador = model.ResiduosRecebidosID == 0 ? new TBResiduosDestinadore() : _service.GetById(model.ResiduosRecebidosID);

            if (model.ResiduosRecebidosID != 0 && residuoDestinador.EmpresaID != empresaID)
                throw new Exception("Resíduo não gerado pela sua empresa");

            residuoDestinador.EmpresaID = empresaID;
            residuoDestinador.ResiduosDestinadoresID = model.ResiduosRecebidosID;

            residuoDestinador.RealizouTransbordo = model.RealizouTransbordo;
            residuoDestinador.nmRazaoSocialTransbordo = model.TransbordoSocial;
            residuoDestinador.CNPJTransbordo = model.TransbordoCnpj;
            residuoDestinador.CNPJTransportadora = model.TransportadoraCnpj;
            residuoDestinador.DePrefeitura = model.DePrefeitura;
            residuoDestinador.nmRazaoSocialTransportadora = model.TransportadoraSocial;
            residuoDestinador.dtMesReferencia = DateTime.ParseExact(model.DataEntrega, "MM/yyyy", null);
            BeginTransaction();

            var tudoCerto = true;
            try
            {
                if (model.ResiduosRecebidosID == 0)
                {
                    residuoDestinador.Itens = ResiduosEditVM.ToModelDestinador(model.Residuos, 0);
                    _service.Add(residuoDestinador);
                }
                else
                {

                    ICollection<TBResiduosColetadoItem> novoItems = new List<TBResiduosColetadoItem>();


                    foreach (var item in model.Residuos)
                    {
                        if (item.IdItem == 0)
                        {
                            if (item.Status != (int)TipoPermissao.Excluir)
                            {
                                novoItems.Add(ResiduosEditVM.ToModelColetado(item, residuoDestinador.ResiduosDestinadoresID));
                            }
                        }
                        else
                        {
                            if (!(item.Status == (int)TipoPermissao.Excluir || item.Quantidade <= 0))
                            {
                                var itemModel =
                                    residuoDestinador.Itens.FirstOrDefault(x => x.ResiduosDestinadoreItemID == item.IdItem);
                                if (itemModel != null)
                                {
                                    itemModel.emLitros = item.Medida;
                                    itemModel.qtResiduo = item.Quantidade;
                                    //novoItems.Add(itemModel);
                                }
                            }
                            else
                            {
                                var itemModel =
                                    residuoDestinador.Itens.FirstOrDefault(x => x.ResiduosDestinadoreItemID == item.IdItem);
                                _service.Remove(itemModel);
                            }
                        }
                    }

                    //residuoGerado.Itens = novoItems;
                    _service.Update(residuoDestinador);
                }


                await CommitAsync();
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


        public ResiduosTratadosVM GetResiduoTratadoById(int empresaID, int residuoGeradoID)
        {
            var model = _serviceTratado.GetById(residuoGeradoID);
            if (model.EmpresaID != empresaID)
            {
                throw new Exception("Resíduo não gerado pela sua empresa");
            }

            var retorno = ResiduosTratadosVM.ToView(model);
            var hash = _service.HashResiduosRecebidoNaoTratados(empresaID);
            var naotratados =
                hash.FirstOrDefault(x => ((int)x[0]) == model.ResiduoClassificadoID)[2];

            retorno.ResiduosNaoTratados = (double) naotratados;
            return retorno;
            
        }

        public ResiduosTratadosVM NovoResiduoTratado(int empresaID)
        {
            var novo = new ResiduosTratadosVM();
            //novo.ResiduosNaoTratados = _service.
            return novo;
        }

        public object[][] HashResiduosRecebidoNaoTratados(int empresaId)
        {

            return _service.HashResiduosRecebidoNaoTratados(empresaId);
        }

        public async Task<IDictionary<string, ModelState>> SalvarResiduoTratadoAsync(int empresaID, ResiduosTratadosVM model)
        {
            var resultado = new Dictionary<string, ModelState>();

            TBResiduosTratado residuoDestinador = model.Id == 0 ? new TBResiduosTratado() : _serviceTratado.GetById(model.Id);

            if (model.Id != 0 && residuoDestinador.EmpresaID != empresaID)
                throw new Exception("Resíduo não gerado pela sua empresa");

            residuoDestinador.EmpresaID = empresaID;
            residuoDestinador.ResiduosTratadosID = model.Id;

            residuoDestinador.ResiduoClassificadoID = Int32.Parse(model.TipoResiduoValor);
            residuoDestinador.qtResiduoTratado = model.QuantidadeReaproveitadaInt;
            residuoDestinador.qtRejeito = model.QuantidadeRejeitoInt;
            residuoDestinador.OutroTipoTratamento = model.Especifique;
            residuoDestinador.TipoTratamento = (TipoTratamento)model.TipoDestinacao;

            residuoDestinador.emLitros = model.emLitros;

            BeginTransaction();

            var tudoCerto = true;
            try
            {
                if (model.Id == 0)
                {
                    _serviceTratado.Add(residuoDestinador);
                }
                else
                {
                    _serviceTratado.Update(residuoDestinador);
                }


                await CommitAsync();
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

        public RejeitosVM NovoRejeito(int empresaID)
        {
            var retorno = new RejeitosVM();
            retorno.RejeitosNaoTratados = _serviceTratado.GetRejeitosNaoTratados(empresaID);
            return retorno;
        }

        public RejeitosVM GetRejeitoId(int empresaID, int rejeitoID)
        {
            var model = _serviceRejeito.GetById(rejeitoID);
            if (model.EmpresaID != empresaID)
            {
                throw new Exception("Rejeito não gerado pela sua empresa");
            }

            var retorno = RejeitosVM.ToView(model);

            retorno.RejeitosNaoTratados = _serviceTratado.GetRejeitosNaoTratados(empresaID) + retorno.RejeitosASerViculado;
            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarRejeitoAsync(int empresaID, RejeitosVM model)
        {
            var resultado = new Dictionary<string, ModelState>();

            TBResiduosDestinadorRejeito residuoDestinador = model.Id == 0 ? new TBResiduosDestinadorRejeito() : _serviceRejeito.GetById(model.Id);

            if (model.Id != 0 && residuoDestinador.EmpresaID != empresaID)
                throw new Exception("Rejeito não gerado pela sua empresa");

            residuoDestinador.EmpresaID = empresaID;
            residuoDestinador.ResiduosDestinadorRejeitoID = model.Id;

            residuoDestinador.CNPJDestinadoraFinal = model.DestinoFinalCnpj;
            residuoDestinador.nmRazaoSocialDestinadoraFinal  = model.DestinoFinalSocial;
            residuoDestinador.CNPJTransportadora  = model.ColetoraCnpj;
            residuoDestinador.nmRazaoSocialTransportadora  = model.ColetoraSocial;

            residuoDestinador.qtRejeitoVinculado = model.RejeitosASerViculado;

            BeginTransaction();

            var tudoCerto = true;
            try
            {
                if (model.Id == 0)
                {
                    _serviceRejeito.Add(residuoDestinador);
                }
                else
                {
                    _serviceRejeito.Update(residuoDestinador);
                }


                await CommitAsync();
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

        public async Task<IList<ResiduosRecebidosBasicoVM>> GetHistoricoResiduosRecebidosAsync(int empresaID)
        {
            return ResiduosRecebidosBasicoVM.ToView(_service.GetResiduosGeradosByEmpresaID(empresaID)).ToList();
        }

        public async Task<IList<ResiduosRecebidosBasicoVM>> GetHistoricoResiduosTratadosAsync(int empresaID)
        {
            return ResiduosRecebidosBasicoVM.ToView(_service.GetResiduosGeradosByEmpresaID(empresaID)).ToList();
        }

        public async Task<IList<ResiduosRecebidosBasicoVM>> GetHistoricoRejetosAsync(int empresaID)
        {
            return ResiduosRecebidosBasicoVM.ToView(_service.GetResiduosGeradosByEmpresaID(empresaID)).ToList();
        }
    }
}
