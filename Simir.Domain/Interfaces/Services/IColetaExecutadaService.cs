using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IColetaExecutadaService : IServiceBase<TBColetaExecutada>
    {
        Task<TBColetaExecutada> RetornaColetaExecutadaByID(int p);
        Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBColetaExecutada ColetaEventual);
        Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBColetaExecutada ColetaEventual);

        List<TBColetaExecutada> TotalResiduoColetado(int idResiduoColetado, int idRota, int idPrestadoraServicos,
                            DateTime dtInicio, DateTime dtFim, bool bColetaRealizada, int idPrefeitura);
    }
}