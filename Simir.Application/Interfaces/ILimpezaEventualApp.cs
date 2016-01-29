using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface ILimpezaEventualApp
    {
        object[][] ReturnLimpezaEventualBYData(int prefeituraID, int? id);
        LimpezaEventualVM GetProgramacaoLimpezaEventual(int? id, int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, LimpezaEventualVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int p);
        List<LimpezasFuturasVM> CarregaGrid(int idPrefeitura);
        List<ConsultaProgramacaoVM> BuscaProgramacaoByData(DateTime dtReferencia, int prefeituraID);
    }
}