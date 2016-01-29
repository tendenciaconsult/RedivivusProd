using System;
using System.Collections.Generic;
using System.IO;
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
    public class GeradorApp : AppServiceBase<SimirContext>, IGeradorApp
    {
        private readonly IGeradorService _geradorService;

        public GeradorApp(
            IGeradorService geradorService
            )
        {
            _geradorService = geradorService;
        }

        public ResiduosGeradosVM Novo(int empresaID)
        {
            var novo = new ResiduosGeradosVM();

            //novo.Mtrs = GeradorMtrVM.ToView(_geradorService.GetMtrsByEmpresaID(empresaID));
            //novo.ResiduosGerados = ResiduoGeradoBasicoVM.ToView(_geradorService.GetResiduosGeradosByEmpresaID(empresaID));
            return novo;
        }

        public ResiduosGeradosVM GetById(int empresaID, int residuoGeradoID)
        {
            var model = _geradorService.GetById(residuoGeradoID);
            if (model.EmpresaID != empresaID)
            {
                throw new Exception("Resíduo não gerado pela sua empresa");
            }

            var retorno = ResiduosGeradosVM.ToView(model);

            //retorno.Mtrs = GeradorMtrVM.ToView(_geradorService.GetMtrsByEmpresaID(empresaID));
            //retorno.ResiduosGerados = ResiduoGeradoBasicoVM.ToView(_geradorService.GetResiduosGeradosByEmpresaID(empresaID));

            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarResiduoGeradoAsync(int empresaID,
            ResiduosGeradosVM model)
        {
            var resultado = new Dictionary<string, ModelState>();

            TBResiduosGerados residuoGerado;

            residuoGerado = model.ResiduoGeradoID == 0 ? new TBResiduosGerados() : _geradorService.GetById(model.ResiduoGeradoID);

            residuoGerado.CNPJDestinadora = model.DestinoCnpj;
            residuoGerado.CnpjColetora = model.ColetoraCnpj;
            residuoGerado.RazaoSocialDestinadora = model.DestinoRazaoSocial;
            residuoGerado.nmRazaoSocialColetora = model.ColetoraRazaoSocial;
            residuoGerado.ColetoraPublica = model.isPublico;
            residuoGerado.EmpresaID = empresaID;
            residuoGerado.dtMesReferencia = DateTime.ParseExact(model.MesReferencia,"MM/yy",null);

            

            BeginTransaction();

            var tudoCerto = true;
            try
            {
                if (model.ResiduoGeradoID == 0)
                {
                    residuoGerado.Itens = ResiduosEditVM.ToModel(model.Residuos, 0);
                    _geradorService.Add(residuoGerado);
                }
                else
                {

                    ICollection<TBResiduosGeradoItem> novoItems = new List<TBResiduosGeradoItem>();
                    

                    foreach (var item in model.Residuos)
                    {
                        if (item.IdItem == 0)
                        {
                            if (item.Status != (int) TipoPermissao.Excluir)
                            {
                                novoItems.Add(ResiduosEditVM.ToModel(item, residuoGerado.ResiduosGeradosID));
                            }
                        }
                        else
                        {
                            if (!(item.Status == (int) TipoPermissao.Excluir || item.Quantidade <= 0))
                            {
                                var itemModel =
                                    residuoGerado.Itens.FirstOrDefault(x => x.ResiduosGeradoItemID == item.IdItem);
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
                                    residuoGerado.Itens.FirstOrDefault(x => x.ResiduosGeradoItemID == item.IdItem);
                                _geradorService.Remove(itemModel);
                            }
                        }
                    }

                    //residuoGerado.Itens = novoItems;
                    _geradorService.Update(residuoGerado);
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
                    tudoCerto = await _geradorService.SalvarMtrAsync(novoMtr, inputStream);
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
        public async Task<IDictionary<string, ModelState>> SalvarMtrAsync(int empresaID, MtrVM mtr)
        {
            var resultado = new Dictionary<string, ModelState>();

            var novoMtr = mtr.ToModel();

            novoMtr.EmpresaGeradoraID = empresaID;


            var tudoCerto = true;
            try
            {
                BeginTransaction();
                if (tudoCerto)
                    tudoCerto = await _geradorService.SalvarMtrAsync(novoMtr);
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
                    tudoCerto = await _geradorService.ExcluirMtr(empresaID, geradorMtrID);
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

        public async Task<IList<ResiduoGeradoBasicoVM>> GetHistoricoResiduoGeradoAsync(int empresaID)
        {
            return ResiduoGeradoBasicoVM.ToView(_geradorService.GetResiduosGeradosByEmpresaID(empresaID));
        }

        public async Task<IList<MtrVM>> GetHistoricoMtrAsync(int empresaID)
        {
            return MtrVM.ToView(_geradorService.GetMtrsByEmpresaID(empresaID)).ToList();
        }

        public async Task<Stream> VerMtr(int empresaID, int id)
        {
            return await _geradorService.DownloadMtr(empresaID, id);
        }
    }
}