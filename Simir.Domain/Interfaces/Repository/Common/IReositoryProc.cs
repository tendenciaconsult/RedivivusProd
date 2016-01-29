using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository.Common
{
    public interface IRepositoryProc
    {
        IEnumerable<Proc_ReturnListaMenu> GetListaMenu(int perfilId);
        IEnumerable<Proc_Return_Total_Residuo_Mes_Ano> GetTotalResiduoMesAno(DateTime dtInicio, DateTime dtFim, int idPrefeitura, int idRota, int idResiduo, int Prestadora, bool bColetaRealizada);
        IEnumerable<Proc_Return_Total_Residuo_Diario> GetTotalResiduoDiario(DateTime dtInicio, DateTime dtFim, int idPrefeitura, int idRota, int idResiduo, int Prestadora, bool bColetaRealizada);

    }
}
