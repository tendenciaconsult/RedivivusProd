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
    public class AterroApp : AppServiceBase<SimirContext>, IAterroApp
    {
        private readonly IEnderecoService _Endereco;
        private readonly IAterroService _Aterro;

        public AterroApp(
            IEnderecoService enderecoService,
            IAterroService Aterro
            )
        {
            _Aterro = Aterro;
            _Endereco = enderecoService;
        }

        public List<AterroCadastradosVM> BuscaProgramacao(int idPrefeitura)
        {
            List<AterroCadastradosVM> retorno;

            retorno = new List<AterroCadastradosVM>();

            retorno = _Aterro.GetAllProgramacaoByPrefeituraID(idPrefeitura)
                .Select(x => new AterroCadastradosVM(x)).ToList();


            return retorno;
        }

        public AterroVM getAterro(int? id, int prefeituraID)
        {
            AterroVM retorno;

            if (id == null || id == 0)
            {
                retorno = new AterroVM();
            }
            else
            {
                var Reg = _Aterro.getAterroByID((int)id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = AterroVM.ToView(Reg);
            }

            return retorno;
        }
        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, AterroVM model)
        {
            //------------------------salva a programação------------------------
            

            var resultado = new Dictionary<string, ModelState>();

            TBAterro Item;


            if (model.AterroID == 0)
            {
                Item = new TBAterro();
            }
            else
            {
                Item = await _Aterro.getAterroByID(model.AterroID);
            }


            Item.PrefeituraID = model.PrefeituraID;
            Item.nmFantasiaAterro = model.nmFantasiaAterro;
            Item.nmRazaoSocialAterro = model.nmRazaoSocialAterro;
            Item.CNPJ = model.CNPJ;
            Item.numeroLicencaOp = model.numeroLicencaOp;
            Item.AterroControlado = model.bAterroControlado;
            Item.bAtivo = true;

            Item.TBEndereco = EnderecoVM.ToModel(model.Endereco);
            Item.TBEndereco.EnderecoID = Item.EnderecoID;


            BeginTransaction();
            var tudoCerto = false;
            try
            {
                tudoCerto = _Endereco.ValidaEndereco(Item.TBEndereco);
                if (tudoCerto)
                {
                    if (model.AterroID == 0)
                        tudoCerto = await _Aterro.AddNovoAterroAsync(user, Item);
                    else
                        tudoCerto = await _Aterro.UpdateAterroAsync(user, Item);
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

        public async Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int idAterro)
        {
            var resultado = new Dictionary<string, ModelState>();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _Aterro.ExcluirAterroAsync(user, idAterro);
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

        public object[][] GetAllAterros(int prefeituraID)
        {
            return _Aterro.GetAllProgramacaoByPrefeituraID(prefeituraID).Select(x=> new object[] { x.AterroID, x.nmFantasiaAterro }).ToArray();
        }
    }
}
