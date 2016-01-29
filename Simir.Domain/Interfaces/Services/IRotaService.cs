using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IRotaService : IServiceBase<TBRota>
    {
        object[][] GetRotasByPrefeitura(int prefeituraID);

        Task<TBRota> ReturnProgramacaoByID(int id);
        Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBRota Dados);
        Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBRota Dados);
        Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int id);

        List<TBRota> CarregaGrid(int PrefeituraID);
    }
}