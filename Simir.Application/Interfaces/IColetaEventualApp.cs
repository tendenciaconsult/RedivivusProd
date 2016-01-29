using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IColetaEventualApp
    {
        ColetaEventualVM RetornaColetaOrdinariaByID(int? id, int PrefeituraID);
        List<HistoricoColetaEventualVM> BuscaProgramacao(int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, ColetaEventualVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int p);
        List<ConsultaProgramacaoColetaEventualVM> BuscaProgramacaoByData(DateTime dtReferencia, int prefeituraID);
    }
}