using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IPrestadoraServicoService : IServiceBase<TBPrestadoraServico>
    {
        IEnumerable<TBPrestadoraServico> GetAllByPrefeitura(int prefeituraID);
        Task<bool> AddAsync(AspNetUser user, TBPrestadoraServico prestadora);
        Task<bool> UpdateAsync(AspNetUser user, TBPrestadoraServico prestadora);
        object[][] ReturnPrestadoraServicosByPrefeitura(int prefeituraID);
        Task<bool> AddEquipamentoAsync(AspNetUser user, TBPrestadoraServicosEquipamento equip);
        Task<bool> UpdateEquipamentoAsync(AspNetUser user, TBPrestadoraServicosEquipamento equip);
    }
}