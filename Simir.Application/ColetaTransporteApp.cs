using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Simir.Application.ViewModels.ColetaTransporteMVs;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;
using Simir.Domain.Interfaces.Services;
using System.Web.Mvc;
using System.IO;

namespace Simir.Application
{
    public class ColetaTransporteApp : AppServiceBase<SimirContext>, IColetaTransporteApp
    {
        private readonly IColetaTransporteService _coletaTransporteService;

        public ColetaTransporteApp(
            IColetaTransporteService coletaTransporteService
            )
        {
            _coletaTransporteService = coletaTransporteService;
        }

       public ColetaTransporteVM Novo(int empresaID)
        {
            var novo = new ColetaTransporteVM();

            //novo.Mtrs = GeradorMtrVM.ToView(_coletaTransporteService.GetMtrsByEmpresaID(empresaID));
            return novo;
        }

       public ColetaTransporteVM GetById(int empresaID, int residuoGeradoID)
        {
            var model = _coletaTransporteService.GetById(residuoGeradoID);
            if (model.EmpresaID != empresaID)
            {
                throw new Exception("Resíduo não gerado pela sua empresa");
            }

            var retorno = ColetaTransporteVM.ToView(model);
            
            return retorno;
        }


        public async Task<IDictionary<string, ModelState>> SalvarResiduoGeradoAsync(int empresaID,
            ColetaTransporteVM model)
        {
            var resultado = new Dictionary<string, ModelState>();

            TBResiduosColetado residuoColetado = model.ColetaTransporteID == 0 ? new TBResiduosColetado() : _coletaTransporteService.GetById(model.ColetaTransporteID);

            if (model.ColetaTransporteID != 0 && residuoColetado.EmpresaID != empresaID)
                throw new Exception("Resíduo não gerado pela sua empresa");

            residuoColetado.EmpresaID = empresaID;

            residuoColetado.CNPJDestinadora = model.DestinoCnpj;
            residuoColetado.RealizouTransbordo = model.RealizouTransbordo;
            residuoColetado.RazaoSocialDestinadora = model.DestinoRazaoSocial;
            residuoColetado.CNPJTransbordo = model.TransbordoCnpj;
            residuoColetado.CnpjGeradora = model.GeradoraCnpj;
            residuoColetado.nmRazaoSocialGeradora = model.GeradoraSocial;
            residuoColetado.nmPessoaLiberouColeta = model.NomeResponsavel;
            residuoColetado.CNPJDestinadora = model.DestinoCnpj;
            residuoColetado.RazaoSocialDestinadora = model.DestinoRazaoSocial;
            residuoColetado.DestinadoraFinal = model.RealizouTransbordo;
            residuoColetado.CnpjGeradora = model.GeradoraCnpj;

           
            residuoColetado.dtMesReferencia = DateTime.ParseExact(model.DataColeta,"MM/yyyy",null);
                    
            

            BeginTransaction();

            var tudoCerto = true;
            try
            {
                if (model.ColetaTransporteID == 0)
                {
                    residuoColetado.Itens = ResiduosEditVM.ToModelColetado(model.Residuos, 0);
                    _coletaTransporteService.Add(residuoColetado);
                }
                else
                {

                    ICollection<TBResiduosColetadoItem> novoItems = new List<TBResiduosColetadoItem>();
                    

                    foreach (var item in model.Residuos)
                    {
                        if (item.IdItem == 0)
                        {
                            if (item.Status != (int) TipoPermissao.Excluir)
                            {
                                novoItems.Add(ResiduosEditVM.ToModelColetado(item, residuoColetado.ResiduosColetadosID));
                            }
                        }
                        else
                        {
                            if (!(item.Status == (int) TipoPermissao.Excluir || item.Quantidade <= 0))
                            {
                                var itemModel =
                                    residuoColetado.Itens.FirstOrDefault(x => x.ResiduosColetadoItemID == item.IdItem);
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
                                    residuoColetado.Itens.FirstOrDefault(x => x.ResiduosColetadoItemID == item.IdItem);
                                _coletaTransporteService.Remove(itemModel);
                            }
                        }
                    }

                    //residuoGerado.Itens = novoItems;
                    _coletaTransporteService.Update(residuoColetado);
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

        public MtrVM NovoMtr(int empresaID, string path, string fileName)
        {
            return MtrVM.ToView(new TBGeradorMtr(empresaID, path, fileName));
        }
        public async Task<IDictionary<string, ModelState>> SalvarMtrAsync(int empresaID, MtrVM mtr, Stream inputStream)
        {
            var resultado = new Dictionary<string, ModelState>();

            var novoMtr = mtr.ToModel();

            novoMtr.EmpresaGeradoraID = empresaID;


            var tudoCerto = true;
            try
            {
                BeginTransaction();
                if (tudoCerto)
                    tudoCerto = await _coletaTransporteService.SalvarMtrAsync(novoMtr, inputStream);
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

        public async Task<IDictionary<string, ModelState>> ExcluirMtr(int empresaID, int geradorMtrID)
        {
            var resultado = new Dictionary<string, ModelState>();


            var tudoCerto = true;
            try
            {
                BeginTransaction();
                if (tudoCerto)
                    tudoCerto = await _coletaTransporteService.ExcluirMtr(empresaID, geradorMtrID);
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

        public async Task<IList<ColetaTransporteBasicoVM>> GetHistoricoColetaTransporteAsync(int empresaID)
        {
            return ColetaTransporteBasicoVM.ToView(_coletaTransporteService.GetResiduosGeradosByEmpresaID(empresaID));
        }


        public async Task<IList<MtrVM>> GetHistoricoMtrAsync(int empresaID)
        {
            return MtrVM.ToView(_coletaTransporteService.GetMtrsByEmpresaID(empresaID)).ToList();
        }

        public async Task<Stream> VerMtr(int empresaID, int id)
        {
            return await _coletaTransporteService.DownloadMtr(empresaID, id);
        }

        public Task<IDictionary<string, ModelState>> SalvarMtrAsync(int empresaID, MtrVM mtr)
        {
            throw new NotImplementedException();
        }
    }
}
