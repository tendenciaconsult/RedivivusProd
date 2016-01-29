using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IEquipamentoLimpezaExecutadaService : IServiceBase<TBEquipamentoLimpezaExecutada>
    {
        Task<bool> RemoveEquipamentosByIDAsync(AspNetUser user, int EquipamentoID);
        Task<bool> AddEquipamentosAsync(AspNetUser user, TBEquipamentoLimpezaExecutada Equipamentos);
        Task<TBEquipamentoLimpezaExecutada> ReturnEquipamentoByID(int EquipamentosID);
        Task<bool> UpdateEquipamentosAsync(AspNetUser user, TBEquipamentoLimpezaExecutada Equipamentos);
    }
}