using System;
using System.Collections.Generic;
using Simir.Application.ViewModels;

namespace Simir.Application.Interfaces
{
    public interface ILimpezaConsultaApp
    {
        List<ConsultasLimpezaEventualVM> CarregaGridLimpezaEventual(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao, bool Editavel);

        List<ConsultasLimpezaEventualRealizadaVM> CarregaGridLimpezaEventualExecutado(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao, bool Editavel);

        List<ConsultasLimpezaEventualNaoRealizadaVM> CarregaGridLimpezaEventualNaoExecutado(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao, bool Editavel);

        List<ConsultasLimpezaEventualPendenteVM> CarregaGridLimpezaEventualPendente(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual,
            int TipoProgramacao, bool Editavel);

        List<ConsultasLimpezaOrdinariaVM> CarregaGridLimpezaOrdinaria(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim);

        List<ConsultasLimpezaOrdinariaRealizadaVM> CarregaGridLimpezaOrdinariaExecutado(int idRegiaoAdministrativa,
            int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim);

        List<ConsultasLimpezaOrdinariaNaoRealizadaVM> CarregaGridLimpezaOrdinariaNaoExecutado(
            int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim);

        object[][] RetornaTipoConsulta();
    }
}