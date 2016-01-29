using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface ILimpezaEventualService : IServiceBase<TBLimpezaEventual>
    {
        object[][] GetHasLimpezaEventualBYData(int prefeituraID, DateTime dtReferencia);

        List<TBLimpezaEventual> GetAllProgramacaoNaoRealizadas(int prefeituraID);

        Task<TBLimpezaEventual> ReturnProgramacaoByID(int id);
        Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBLimpezaEventual LimpezaEventual);
        Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBLimpezaEventual LimpezaEventual);
        Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int LimpezaEventualID);
        //-----------Grid tela de consulta Limpeza. Retorna Dados da Limpeza Eventual -----------------
        List<TBLimpezaEventual> CarregaGridLimpezaEventual(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao);

        List<TBLimpezaEventual> CarregaGridLimpezaEventualExecutado(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao);

        List<TBLimpezaEventual> CarregaGridLimpezaEventualNaoExecutado(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao);

        List<TBLimpezaEventual> CarregaGridLimpezaEventualPendente(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao);

        //-----------Grid tela de consulta Limpeza. Retorna Dados da Limpeza Ordinaria -----------------
        List<TBLimpezaEventual> CarregaGridLimpezaOrdinaria(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim);

        List<TBLimpezaEventual> CarregaGridLimpezaOrdinariaExecutado(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim);

        List<TBLimpezaEventual> CarregaGridLimpezaOrdinariaNaoExecutado(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim);

        List<TBLimpezaEventual> BuscaProgramacaoByData(DateTime dtReferencia, int prefeituraID);
    }
}