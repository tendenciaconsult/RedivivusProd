using System;
using System.Collections.Generic;
using Simir.Application.ViewModels;

namespace Simir.Application.Interfaces
{
    public interface IColetaConsultaApp
    {
        object[][] RetornaTipoConsulta();

        List<ConsultasColetaEventualVM> CarregaGrigColetaEventual(int idPrestadora, int RotaID, DateTime dtInicio,
            DateTime dtFim, bool bOrdinaria, bool bEventual);

        List<ConsultasColetaEventualRealizadaVM> CarregaGridColetaEventualRealizada(int idPrestadora, int RotaID,
            DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, bool Editavel);

        List<ConsultasColetaEventualNaoRealizadaVM> CarregaGridColetaEventualNaoRealizada(int idPrestadora, int RotaID,
            DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, bool Editavel);

        List<ConsultasColetaEventualPendenteVM> CarregaGridColetaEventualPendente(int idPrestadora, int RotaID,
            DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, bool Editavel);
    }
}