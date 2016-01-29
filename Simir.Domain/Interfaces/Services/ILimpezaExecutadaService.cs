using System;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface ILimpezaExecutadaService : IServiceBase<TBLimpezaExecutada>
    {
        object[][] GetHasLimpezaEventualBYData(int prefeituraID, DateTime Data);
        Task<TBLimpezaExecutada> ReturnProgramacaoByID(int id);
        Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBLimpezaExecutada LimpezaExecutada);
        Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBLimpezaExecutada LimpezaExecutada);
    }
}