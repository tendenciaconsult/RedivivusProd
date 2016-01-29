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
    public class DisposicaoFinalAPP : AppServiceBase<SimirContext>, IDisposicaoFinalAPP
    {
        private readonly IDisposicaoFinalService _service;

        public DisposicaoFinalAPP(IDisposicaoFinalService service)
        {
            _service = service;
        }
        public DisposicaoFinalVM RetornaDisposicaoFinalByIDEmpresa(int id)
        {
            DisposicaoFinalVM retorno = new DisposicaoFinalVM();
            //todo

            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarAsync(DisposicaoFinalVM model)
        {
            var resultado = new Dictionary<string, ModelState>();

            TBDisposicaoFinalResiduo Item = model.DisposicaoFinalResiduoID == 0 ? new TBDisposicaoFinalResiduo() : _service.GetById(model.DisposicaoFinalResiduoID);

            Item.EmpresaID = model.EmpresaID;
            Item.CNPJTransportadora = model.TransportadoraCnpj;
            Item.nmRazaoSocialTransportadora = model.TransportadoraSocial;
            Item.dtRecebimento = DateTime.Now;
            Item.qtRejeito = (model.Quantidade == null)
                    ? 0
                    : Convert.ToInt32(model.Quantidade.Replace(".", ""));
            Item.bAterroControlado = model.bAterroControlado;

            Item.dtMesReferencia = DateTime.ParseExact(model.DataEntrega, "MM/yyyy", null);

            BeginTransaction();

            var tudoCerto = true;
            try
            {
                if (model.DisposicaoFinalResiduoID == 0)
                {
                    _service.Add(Item);
                }
                else
                {  
                    _service.Update(Item);
                }
                //Commit();
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
        public async Task<IDictionary<string, ModelState>> Excluir(int id)
        {
            var resultado = new Dictionary<string, ModelState>();


            var tudoCerto = true;
            try
            {
                BeginTransaction();
                if (tudoCerto)
                    tudoCerto = await _service.ExcluirProgramacaoAsync(id);
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

        public async Task<IList<DisposicaoFinalHistoricoVM>> GetHistoricoDisposicaoFinalAsync(int id)
        {
            return _service.GetAllProgramacaoByEmpresaID(id)
                .Select(x => new DisposicaoFinalHistoricoVM(x)).ToList();
        }
    }
}
