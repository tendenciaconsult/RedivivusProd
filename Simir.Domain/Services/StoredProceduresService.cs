using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Repository.Common;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class StoredProceduresService : IStoredProceduresService
    {
        private readonly IRepositoryProc _Proc;


        public StoredProceduresService(IRepositoryProc Proc)
        {
            _Proc = Proc;

        }

        public List<Proc_ReturnListaMenu> GetMenus(int id)
        {
            return _Proc.GetListaMenu(id).ToList();
        }

        public List<Proc_Return_Total_Residuo_Mes_Ano> GetResiduoMesAno(DateTime dtInicio, DateTime dtFim,
            int idPrefeitura, int idRota, int idResiduo, int prestadora, bool bColetaRealizada)
        {
            return _Proc.GetTotalResiduoMesAno(dtInicio, dtFim,
            idPrefeitura, idRota, idResiduo, prestadora, bColetaRealizada).ToList();
        }

        public List<Proc_Return_Total_Residuo_Diario> GetResiduoDiario(DateTime dtInicio, DateTime dtFim,
            int idPrefeitura, int idRota, int idResiduo, int prestadora, bool bColetaRealizada)
        {
            return _Proc.GetTotalResiduoDiario(dtInicio, dtFim,
            idPrefeitura, idRota, idResiduo, prestadora, bColetaRealizada).ToList();
        }

    }
}
