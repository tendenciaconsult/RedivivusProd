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
    public class LimpezaOrdinariaApp : AppServiceBase<SimirContext>, ILimpezaOrdinariaApp
    {
        private readonly ILimpezaOrdinariaService _LimpezaOrdinariaService;

        public LimpezaOrdinariaApp(ILimpezaOrdinariaService LimpezaOrdinariaService)
        {
            _LimpezaOrdinariaService = LimpezaOrdinariaService;
        }

        //public object[][] RetornRegiaoAdministrativaBYPrefeitura(int prefeituraID)
        //{

        //    var lista = _LimpezaOrdinariaService.RetornRegiaoAdministrativaBYPrefeitura(prefeituraID).ToList();
        //    lista.Insert(0, new object[] { "0", " " });

        //    return lista.ToArray();
        //}
        public object[][] ReturnPrestadoraServicosByPrefeitura(int prefeituraID)
        {
            var lista = _LimpezaOrdinariaService.ReturnPrestadoraServicosByPrefeitura(prefeituraID).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }

        public List<LimpezasCadastradosVM> CarregaGrid(int idPrefeitura)
        {
            List<LimpezasCadastradosVM> retorno;

            retorno = new List<LimpezasCadastradosVM>();

            retorno =
                _LimpezaOrdinariaService.GetAllProgramacaoLimpezaOrdinariaByPrefeitura(idPrefeitura)
                    .Select(x => new LimpezasCadastradosVM(x))
                    .ToList();


            return retorno;
        }

        public LimpezaOrdinariaVM GetProgramacaoLimpezaOrdinaria(int? id, int prefeituraID)
        {
            LimpezaOrdinariaVM retorno;

            if (id == null || id == 0)
            {
                retorno = new LimpezaOrdinariaVM();
                retorno.TipoServico = 1;
            }
            else
            {
                var Reg = _LimpezaOrdinariaService.ReturnProgramacaoByID((int) id).Result;
                if (prefeituraID != Reg.TBRegiaoAdministrativa.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }
                retorno = LimpezaOrdinariaVM.ToView(Reg);
            }

            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, LimpezaOrdinariaVM model)
        {
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBLimpezaOrdinaria LimpezaOrdinaria;

            if (model.LimpezaOrdinariaID == 0)
            {
                LimpezaOrdinaria = new TBLimpezaOrdinaria();
            }
            else
            {
                LimpezaOrdinaria = await _LimpezaOrdinariaService.ReturnProgramacaoByID(model.LimpezaOrdinariaID);
            }

            LimpezaOrdinaria.nmProgramacao = model.nmProgramacao;
            LimpezaOrdinaria.PrefeituraID = model.PrefeituraID;
            LimpezaOrdinaria.RegiaoAdministrativaID = Convert.ToInt32(model.RegiaoAdministrativaID);
            LimpezaOrdinaria.PrestadoraServicosID = Convert.ToInt32(model.PrestadoraServicosID);
            LimpezaOrdinaria.ExtensaoSargetas = (model.ExtensaoSargetas == null)
                ? 0
                : Convert.ToInt32(model.ExtensaoSargetas.Replace(".", ""));
            if (model.BairroID != null)
            {
                LimpezaOrdinaria.EnderecoBairroID = Convert.ToInt32(model.BairroID);
            }
            if (model.LogradouroID != null)
            {
                LimpezaOrdinaria.EnderecoLogradouroID = Convert.ToInt32(model.LogradouroID);
            }
            if (model.FeiraLivreID != null)
            {
                LimpezaOrdinaria.FeiraLivreID = Convert.ToInt32(model.FeiraLivreID);
            }
            LimpezaOrdinaria.nmOutroServico = model.nmOutroServico;
            LimpezaOrdinaria.TipoServico = model.TipoServico;
            LimpezaOrdinaria.bSegunda = model.bSegunda;
            LimpezaOrdinaria.qtVarricaoSegunda = model.qtVarricaoSegunda;
            LimpezaOrdinaria.bSegundaFiscalizado = model.bSegundaFiscalizado;
            LimpezaOrdinaria.bTerca = model.bTerca;
            LimpezaOrdinaria.qtVarricaoTerca = model.qtVarricaoTerca;
            LimpezaOrdinaria.bTercaFiscalizado = model.bTercaFiscalizado;
            LimpezaOrdinaria.bQuarta = model.bQuarta;
            LimpezaOrdinaria.qtVarricaoQuarta = model.qtVarricaoQuarta;
            LimpezaOrdinaria.bQuartaFiscalizado = model.bQuartaFiscalizado;
            LimpezaOrdinaria.bQuinta = model.bQuartaFiscalizado;
            LimpezaOrdinaria.qtVarricaoQuinta = Convert.ToInt32(model.bQuartaFiscalizado);
            LimpezaOrdinaria.bQuintaFiscalizado = model.bQuartaFiscalizado;
            LimpezaOrdinaria.bSexta = model.bQuartaFiscalizado;
            LimpezaOrdinaria.qtVarricaoSexta = Convert.ToInt32(model.bQuartaFiscalizado);
            LimpezaOrdinaria.bSextaFiscalizado = model.bQuartaFiscalizado;
            LimpezaOrdinaria.bSabado = model.bSabado;
            LimpezaOrdinaria.qtVarricaoSabado = model.qtVarricaoSabado;
            LimpezaOrdinaria.bSabadoFiscalizado = model.bSabadoFiscalizado;
            LimpezaOrdinaria.bDomingo = model.bDomingo;
            LimpezaOrdinaria.qtVarricaoDomingo = model.qtVarricaoDomingo;
            LimpezaOrdinaria.bDomingoFiscalizado = model.bDomingoFiscalizado;
            LimpezaOrdinaria.qtGarisSegunda = (model.qtGarisSegunda == null)
                ? 0
                : Convert.ToInt32(model.qtGarisSegunda.Replace(".", ""));
            LimpezaOrdinaria.qtGarisTerca = (model.qtGarisTerca == null)
                ? 0
                : Convert.ToInt32(model.qtGarisTerca.Replace(".", ""));
            LimpezaOrdinaria.qtGarisQuarta = (model.qtGarisQuarta == null)
                ? 0
                : Convert.ToInt32(model.qtGarisQuarta.Replace(".", ""));
            LimpezaOrdinaria.qtGarisQuinta = (model.qtGarisQuinta == null)
                ? 0
                : Convert.ToInt32(model.qtGarisQuinta.Replace(".", ""));
            LimpezaOrdinaria.qtGarisSexta = (model.qtGarisSexta == null)
                ? 0
                : Convert.ToInt32(model.qtGarisSexta.Replace(".", ""));
            LimpezaOrdinaria.qtGarisSabado = (model.qtGarisSabado == null)
                ? 0
                : Convert.ToInt32(model.qtGarisSabado.Replace(".", ""));
            LimpezaOrdinaria.qtGarisDomingo = (model.qtGarisDomingo == null)
                ? 0
                : Convert.ToInt32(model.qtGarisDomingo.Replace(".", ""));
            LimpezaOrdinaria.bAtivo = true;


            BeginTransaction();

            try
            {
                if (model.LimpezaOrdinariaID == 0)
                    tudoCerto = await _LimpezaOrdinariaService.AddNovaProgramacaoAsync(user, LimpezaOrdinaria);
                else
                    tudoCerto = await _LimpezaOrdinariaService.UpdateProgramacaoAsync(user, LimpezaOrdinaria);

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

        public async Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int LimpezaOrdinariaID)
        {
            var resultado = new Dictionary<string, ModelState>();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _LimpezaOrdinariaService.ExcluirProgramacaoAsync(user, LimpezaOrdinariaID);
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