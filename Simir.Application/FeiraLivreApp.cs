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
    public class FeiraLivreApp : AppServiceBase<SimirContext>, IFeiraLivreApp
    {
        private readonly IFeiraLivreService _FeiraLivre;

        public FeiraLivreApp(IFeiraLivreService FeiraLivre)
        {
            _FeiraLivre = FeiraLivre;
        }

        public object[][] GetFeiraLivreByRegiaoAdministrativa(int idRegiaoAdministrativa)
        {
            var lista = _FeiraLivre.GetFeiraLivreByRegiaoAdministrativa(idRegiaoAdministrativa).ToList();
            lista.Insert(0, new object[] {"0", " "});

            return lista.ToArray();
        }

        public FeirasLivresVM GetFeriaByID(int? id, int prefeituraID)
        {
            FeirasLivresVM retorno;

            if (id == null || id == 0)
            {
                retorno = new FeirasLivresVM();
            }
            else
            {
                var Reg = _FeiraLivre.GetFeriaByID((int) id).Result;
                if (prefeituraID != Reg.PrefeituraID)
                {
                    throw new Exception("Prefeitura não autorizado");
                }
                if (Reg.bAtivo == false)
                {
                    throw new Exception("Secretaria não existe mais");
                }

                retorno = FeirasLivresVM.ToView(Reg);
            }

            return retorno;
        }

        public List<ConsultaFeirasLivresVM> ConsultaFeiraLivre()
        {
            List<ConsultaFeirasLivresVM> retorno;

            retorno = new List<ConsultaFeirasLivresVM>();

            retorno = _FeiraLivre.ConsultaFeiraLivre()
                .Select(x => new ConsultaFeirasLivresVM(x)).ToList();


            return retorno;
        }

        public async Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, FeirasLivresVM model)
        {
            var tudoCerto = false;

            var resultado = new Dictionary<string, ModelState>();

            TBFeiraLivre Dados;


            if (model.FeiraLivreID == 0)
            {
                Dados = new TBFeiraLivre();
            }
            else
            {
                Dados = await _FeiraLivre.GetFeriaByID(model.FeiraLivreID);
            }

            Dados.PrefeituraID = model.PrefeituraID;
            Dados.nmProgramacao = model.nmProgramacao;
            Dados.RegiaoAdministrativaID = Convert.ToInt32(model.RegiaoAdministrativaID);
            Dados.BairroID = Convert.ToInt32(model.BairroID);
            Dados.LogradouroID = Convert.ToInt32(model.LogradouroID);

            Dados.bAtivo = true;


            BeginTransaction();

            try
            {
                if (model.FeiraLivreID == 0)
                    tudoCerto = await _FeiraLivre.AddNovaProgramacaoAsync(user, Dados);
                else
                    tudoCerto = await _FeiraLivre.UpdateProgramacaoAsync(user, Dados);

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

        public async Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int id)
        {
            var resultado = new Dictionary<string, ModelState>();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = await _FeiraLivre.ExcluirProgramacaoAsync(user, id);
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