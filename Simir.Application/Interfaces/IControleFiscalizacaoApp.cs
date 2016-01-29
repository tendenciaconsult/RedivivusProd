using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IControleFiscalizacaoApp
    {
        object[][] RetornaTipoConsulta();

        object[][] RetornaResiduoColetado();

        List<TotalResiduoColetadoMesAnoVM> Rel_TotalResiduoColetadoMesAno(int idResiduoColetado, int idRota, int idPrestadoraServicos,
    DateTime dtInicio, DateTime dtFim, bool bColetaRealizada, int idPrefeitura);

        GraficoTotalResiduoColetadoMesAnoVM<TotalResiduoColetadoMesAnoVM> TotalResiduoColetadoMesAno(int idResiduoColetado, int idRota, int idPrestadoraServicos,
            DateTime dtInicio, DateTime dtFim, bool bColetaRealizada, int idPrefeitura);
    }
}
