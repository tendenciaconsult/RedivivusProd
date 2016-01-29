using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IColetaOrdinariaApp
    {
        ColetaOrdinariaVM RetornaColetaOrdinariaByID(int? id, int PrefeituraID);
        List<HistoricoColetaOrdinariaVM> CarregaGrid(int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, ColetaOrdinariaVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int p);
    }
}