using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IRegiaoAdministrativaService : IServiceBase<TBRegiaoAdministrativa>
    {
        object[][] GetHashRegiaoAdministrativa(int prefeituraID);
        Task<TBRegiaoAdministrativaLogradouro> GetRegiaoAdministrativaLogradouroByID(int id);
        Task<TBRegiaoAdministrativa> ReturnRegiaoAdministrativaByID(int id);
        IEnumerable<TBRegiaoAdministrativaLogradouro> GetAllByRegiaoAdministrativa(int id);
        IEnumerable<TBRegiaoAdministrativa> GetAllRegioesAdministrativasByPrefeituraID(int id);
        Task<TBRegiaoAdministrativa> ReturnPrimeiraRegiaoAdministrativa(int id);
        Task<bool> ValidaLogradouroCadastrado(int RegiaoAdministrativaID, int LogradouroID);

        Task<bool> AddRegiaoAdministrativaLogradouroAsync(AspNetUser user,
            TBRegiaoAdministrativaLogradouro RegiaoAdministrativaLogradouro);

        Task<bool> ExcluirLogradouroAsync(AspNetUser user, int LogradouroID);
        Task<bool> AddRegiaoAdministrativaAsync(AspNetUser user, TBRegiaoAdministrativa RegiaoAdministrativa);
        Task<bool> ExcluirRegiaoAdministrativaAsync(AspNetUser user, int RegiaoAdministrativaID);

        Task<bool> UpdateRegiaoAdministrativaLogradouroAsync(AspNetUser user,
            TBRegiaoAdministrativaLogradouro RegiaoAdministrativaLogradouro);

        Task<bool> UpdateRegiaoAdministrativaAsync(AspNetUser user, TBRegiaoAdministrativa RegiaoAdministrativa);
        object[][] GetLogradouroByRegiaoAdministrativaANDBairro(int idRegiaoAdministrativa, int idBairro);
        object[][] GetBairrosByRegiaoAdministrativa(int idRegiaoAdministrativa);
    }
}