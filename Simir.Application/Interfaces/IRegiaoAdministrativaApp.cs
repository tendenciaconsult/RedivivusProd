using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IRegiaoAdministrativaApp
    {

        object[][] GetHashRegiaoAdministrativa(int prefeituraID);

        Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, RegiaoAdministrativaVM model);
        Task<IDictionary<string, ModelState>> Excluir(AspNetUser user, RegiaoAdministrativaVM model);

        object[][] GetBairrosByRegiaoAdministrativa(int idRegiaoAdministrativa);
        object[][] GetLogradouroByRegiaoAdministrativaANDBairro(int idRegiaoAdministrativa, int idBairro);

        RegiaoAdministrativaVM CarregaRegiaoAdministrativa(int? p, int prefeituraID);

        List<RegioesAdministrativasCadastradasVM> BuscaProgramacao(int prefeituraID);
    }
}