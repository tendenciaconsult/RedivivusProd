using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IEquipamentoColetaOrdinariaService : IServiceBase<TBEquipamentoColetaOrdinaria>
    {
        Task<bool> RemoveEquipamentosByIDAsync(AspNetUser user, int EquipamentoID);
        Task<bool> AddEquipamentosAsync(AspNetUser user, TBEquipamentoColetaOrdinaria Equipamentos);
        Task<TBEquipamentoColetaOrdinaria> ReturnEquipamentoByID(int EquipamentosID);
        Task<bool> UpdateEquipamentosAsync(AspNetUser user, TBEquipamentoColetaOrdinaria Equipamentos);
    }
}