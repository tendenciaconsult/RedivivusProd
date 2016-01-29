using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;


namespace Simir.Domain.Interfaces.Services
{
    public interface ITransbordoService : IServiceBase<TBTransbordo>
    {
        List<TBTransbordo> GetAllProgramacaoByPrefeituraID(int idPrefeitura);
        Task<TBTransbordo> getTransbordoByID(int id);
        Task<bool> AddNovoTransbordoAsync(AspNetUser user, TBTransbordo item);
        Task<bool> UpdateTransbordoAsync(AspNetUser user, TBTransbordo item);
        Task<bool> ExcluirTransbordoAsync(AspNetUser user, int idAterro);
    }
}
