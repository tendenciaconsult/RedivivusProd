using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IColetaExecutadaDetalhadaService : IServiceBase<TBColetaExecutadaDetalhada>
    {
        Task<bool> RemoveDadosByIDAsync(AspNetUser user, int EquipamentoID);
        Task<bool> AddDadossAsync(AspNetUser user, TBColetaExecutadaDetalhada Equipamentos);
        Task<TBColetaExecutadaDetalhada> ReturnDadosByID(int EquipamentosID);
        Task<bool> UpdateDadosAsync(AspNetUser user, TBColetaExecutadaDetalhada Equipamentos);
    }
}