using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IRotasDescricaoService : IServiceBase<TBRotasDescricao>
    {
        Task<bool> RemoverDadosByIDAsync(AspNetUser user, int Dados);
        Task<bool> AddDadosAsync(AspNetUser user, TBRotasDescricao Dados);
        Task<TBRotasDescricao> ReturnDadosByID(int Dados);
        Task<bool> UpdateDadosAsync(AspNetUser user, TBRotasDescricao Dados);
    }
}