using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IEnderecosColetaEventualService : IServiceBase<TBEnderecosColetaEventual>
    {
        Task<bool> RemoveEnderecosByIDAsync(AspNetUser user, int EquipamentoID);
        Task<bool> AddEnderecosAsync(AspNetUser user, TBEnderecosColetaEventual Equipamentos);
        Task<TBEnderecosColetaEventual> ReturnEnderecosByID(int EquipamentosID);
        bool UpdateEnderecos(AspNetUser user, TBEnderecosColetaEventual Equipamentos);
    }
}