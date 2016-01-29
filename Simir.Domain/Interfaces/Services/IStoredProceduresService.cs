using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IStoredProceduresService
    {
        List<Proc_ReturnListaMenu> GetMenus(int id);
        List<Proc_Return_Total_Residuo_Mes_Ano> GetResiduoMesAno(DateTime dtInicio, DateTime dtFim, int idPrefeitura, int idRota, int idResiduo, int prestadora, bool bColetaRealizada);
        List<Proc_Return_Total_Residuo_Diario> GetResiduoDiario(DateTime dtInicio, DateTime dtFim, int idPrefeitura, int idRota, int idResiduo, int prestadora, bool bColetaRealizada);
    }
}
