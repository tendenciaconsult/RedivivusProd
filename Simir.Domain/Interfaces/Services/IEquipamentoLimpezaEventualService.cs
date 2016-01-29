using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IEquipamentoLimpezaEventualService : IServiceBase<TBEquipamentoLimpezaEventual>
    {
        Task<bool> RemoveEquipamentosByIDAsync(AspNetUser user, int EquipamentoID);
        Task<bool> AddEquipamentosAsync(AspNetUser user, TBEquipamentoLimpezaEventual Equipamentos);
        Task<TBEquipamentoLimpezaEventual> ReturnEquipamentoByID(int EquipamentosID);
        Task<bool> UpdateEquipamentosAsync(AspNetUser user, TBEquipamentoLimpezaEventual Equipamentos);
    }
}