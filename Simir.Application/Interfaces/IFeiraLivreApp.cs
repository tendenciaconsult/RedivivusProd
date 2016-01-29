using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IFeiraLivreApp
    {
        object[][] GetFeiraLivreByRegiaoAdministrativa(int idRegiaoAdministrativa);
        FeirasLivresVM GetFeriaByID(int? id, int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, FeirasLivresVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int p);
        List<ConsultaFeirasLivresVM> ConsultaFeiraLivre();
    }
}