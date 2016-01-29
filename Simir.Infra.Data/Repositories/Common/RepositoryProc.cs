using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository.Common;
using Simir.Infra.Data.Context;

namespace Simir.Infra.Data.Repositories.Common
{
    public class RepositoryProc: IRepositoryProc, IDisposable
        
    {
        private readonly ObjectContext _dbContext;
        protected ObjectContext Context
        {
            get { return _dbContext; }
        }

        public RepositoryProc()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<SimirContext>>()
            as ContextManager<SimirContext>;

            _dbContext = ((IObjectContextAdapter)contextManager.GetContext()).ObjectContext;
        }



        public IEnumerable<Proc_ReturnListaMenu> GetListaMenu(int perfilId)
        {
            var perfilIDParameter = new object[] { new SqlParameter("@PerfilID", perfilId) };

            return Context.ExecuteStoreQuery<Proc_ReturnListaMenu>("exec Proc_ReturnListaMenu @PerfilID", perfilIDParameter);
        }

        public IEnumerable<Proc_Return_Total_Residuo_Mes_Ano> GetTotalResiduoMesAno(DateTime dtInicio, DateTime dtFim,
            int idPrefeitura, int idRota, int idResiduo, int Prestadora, bool bColetaRealizada)
        {
            var Parametros = new object[]
            {
                new SqlParameter("@dtInicio", dtInicio), 
                new SqlParameter("@dtFim", dtFim),
                new SqlParameter("@idPrefeitura", idPrefeitura), 
                new SqlParameter("@idRota", idRota), 
                new SqlParameter("@idResiduo", idResiduo), 
                new SqlParameter("@Prestadora", Prestadora),
                new SqlParameter("@bColetaRealizada", bColetaRealizada)
            
            };

            return Context.ExecuteStoreQuery<Proc_Return_Total_Residuo_Mes_Ano>("exec Proc_Return_Total_Residuo_Mes_Ano @dtInicio, @dtFim, @idPrefeitura, @idRota, @idResiduo, @Prestadora, @bColetaRealizada", Parametros);

        }

        public IEnumerable<Proc_Return_Total_Residuo_Diario> GetTotalResiduoDiario(DateTime dtInicio, DateTime dtFim,
            int idPrefeitura, int idRota, int idResiduo, int Prestadora, bool bColetaRealizada)
        {
            var Parametros = new object[]
            {
                new SqlParameter("@dtInicio", dtInicio), 
                new SqlParameter("@dtFim", dtFim),
                new SqlParameter("@idPrefeitura", idPrefeitura), 
                new SqlParameter("@idRota", idRota), 
                new SqlParameter("@idResiduo", idResiduo), 
                new SqlParameter("@Prestadora", Prestadora),
                new SqlParameter("@bColetaRealizada", bColetaRealizada) 
            
            };

            return Context.ExecuteStoreQuery<Proc_Return_Total_Residuo_Diario>("exec Proc_Return_Total_Residuo_Diario @dtInicio, @dtFim, @idPrefeitura, @idRota, @idResiduo, @Prestadora, @bColetaRealizada", Parametros);

        }




        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }
}
