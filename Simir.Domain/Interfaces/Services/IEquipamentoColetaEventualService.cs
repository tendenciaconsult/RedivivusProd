using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IEquipamentoColetaEventualService : IServiceBase<TBEquipamentoColetaEventual>
    {
        Task<bool> RemoveEquipamentosByIDAsync(AspNetUser user, int EquipamentoID);
        Task<bool> AddEquipamentosAsync(AspNetUser user, TBEquipamentoColetaEventual Equipamentos);
        Task<TBEquipamentoColetaEventual> ReturnEquipamentoByID(int EquipamentosID);
        Task<bool> UpdateEquipamentosAsync(AspNetUser user, TBEquipamentoColetaEventual Equipamentos);
    }
}