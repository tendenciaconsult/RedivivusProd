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
    public class TransbordoApp : AppServiceBase<SimirContext>, ITransbordoApp
    {
        private readonly IEnderecoService _Endereco;
        private readonly ITransbordoService _Transbordo;

        public TransbordoApp(
            IEnderecoService enderecoService,
            ITransbordoService Transbordo
            )
        {
            _Transbordo = Transbordo;
            _Endereco = enderecoService;
        }

        public List<TransbordoCadastradosVM> BuscaProgramacao(int idPrefeitura)
        {
            List<TransbordoCadastradosVM> retorno;

            retorno = new List<TransbordoCadastradosVM>();

            retorno = _Transbordo.GetAllProgramacaoByPrefeituraID(idPrefeitura)
                .Select(x => new TransbordoCadastradosVM(x)).ToList();


            return retorno;
        }

        public TransbordoVM GetTransbordo(int? id, int prefeituraID)
        {
            TransbordoVM retorno;

            if (id == null || id == 0)
            {
                retorno = new TransbordoVM();
            }
            else
            {
                var Reg = _Transbordo.getTransbordoByID((int)id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = TransbordoVM.ToView(Reg);
            }

            return retorno;
        }
        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, TransbordoVM model)
        {
            //------------------------salva a programação------------------------
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBTransbordo Item;


            if (model.TransbordoID == 0)
            {
                Item = new TBTransbordo();
            }
            else
            {
                Item = await _Transbordo.getTransbordoByID(model.TransbordoID);
            }

            Item.PrefeituraID = model.PrefeituraID;
            Item.nmFantasiaTransbordo = model.nmFantasiaTransbordo;
            Item.nmRazaoSocialTransbordo = model.nmRazaoSocialTransbordo;
            Item.CNPJ = model.CNPJ;
            Item.numeroLicencaOp = model.numeroLicencaOp;
            Item.bAtivo = true;

            Item.TBEndereco = EnderecoVM.ToModel(model.Endereco);
            Item.TBEndereco.EnderecoID = Item.EnderecoID;


            BeginTransaction();

            try
            {
                tudoCerto = _Endereco.ValidaEndereco(Item.TBEndereco);
                if (tudoCerto)
                {
                    if (model.TransbordoID == 0)
                        tudoCerto = await _Transbordo.AddNovoTransbordoAsync(user, Item);
                    else
                        tudoCerto = await _Transbordo.UpdateTransbordoAsync(user, Item);
                }
                if (tudoCerto) Commit();

            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            return resultado;
        }

        public async Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int TransbordoID)
        {
            var resultado = new Dictionary<string, ModelState>();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _Transbordo.ExcluirTransbordoAsync(user, TransbordoID);
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

        public object[][] GetAllTransbordos(int prefeituraID)
        {
            return _Transbordo.GetAllProgramacaoByPrefeituraID(prefeituraID).Select(x => new object[] { x.TransbordoID, x.nmFantasiaTransbordo }).ToArray();
        }
    }
}
