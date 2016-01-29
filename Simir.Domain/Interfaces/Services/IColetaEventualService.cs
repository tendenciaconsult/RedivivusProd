using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IColetaEventualService : IServiceBase<TBColetaEventual>
    {
        Task<TBColetaEventual> RetornaColetaEventualByID(int p);
        List<TBColetaEventual> GetAllProgramacaoByPrefeituraID(int idPrefeitura);
        Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBColetaEventual ColetaEventual);
        Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBColetaEventual ColetaEventual);
        Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int idColetaEventual);
        List<TBColetaEventual> BuscaProgramacaoByData(DateTime dtReferencia, int prefeituraID);

        List<TBColetaEventual> CarregaGrigColetaEventual(int idPrestadora, int RotaID, DateTime dtInicio, DateTime dtFim,
            bool bOrdinaria, bool bEventual);

        List<TBColetaEventual> CarregaGridColetaEventualRealizada(int idPrestadora, int RotaID, DateTime dtInicio,
            DateTime dtFim, bool bOrdinaria, bool bEventual);

        List<TBColetaEventual> CarregaGridColetaEventualNaoRealizada(int idPrestadora, int RotaID, DateTime dtInicio,
            DateTime dtFim, bool bOrdinaria, bool bEventual);

        List<TBColetaEventual> CarregaGridColetaEventualPendente(int idPrestadora, int RotaID, DateTime dtInicio,
            DateTime dtFim, bool bOrdinaria, bool bEventual);
    }
}