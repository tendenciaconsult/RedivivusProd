﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Simir.WebInterfaceComAuth.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BDRedivivusEntities : DbContext
    {
        public BDRedivivusEntities()
            : base("name=BDRedivivusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<Proc_Return_Total_Residuo_Diario_Result> Proc_Return_Total_Residuo_Diario(Nullable<System.DateTime> dtInicio, Nullable<System.DateTime> dtFim, Nullable<int> idPrefeitura, Nullable<int> idRota, Nullable<int> idResiduo, Nullable<int> prestadora, Nullable<bool> bColetaRealizada)
        {
            var dtInicioParameter = dtInicio.HasValue ?
                new ObjectParameter("dtInicio", dtInicio) :
                new ObjectParameter("dtInicio", typeof(System.DateTime));
    
            var dtFimParameter = dtFim.HasValue ?
                new ObjectParameter("dtFim", dtFim) :
                new ObjectParameter("dtFim", typeof(System.DateTime));
    
            var idPrefeituraParameter = idPrefeitura.HasValue ?
                new ObjectParameter("idPrefeitura", idPrefeitura) :
                new ObjectParameter("idPrefeitura", typeof(int));
    
            var idRotaParameter = idRota.HasValue ?
                new ObjectParameter("idRota", idRota) :
                new ObjectParameter("idRota", typeof(int));
    
            var idResiduoParameter = idResiduo.HasValue ?
                new ObjectParameter("idResiduo", idResiduo) :
                new ObjectParameter("idResiduo", typeof(int));
    
            var prestadoraParameter = prestadora.HasValue ?
                new ObjectParameter("Prestadora", prestadora) :
                new ObjectParameter("Prestadora", typeof(int));
    
            var bColetaRealizadaParameter = bColetaRealizada.HasValue ?
                new ObjectParameter("bColetaRealizada", bColetaRealizada) :
                new ObjectParameter("bColetaRealizada", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_Return_Total_Residuo_Diario_Result>("Proc_Return_Total_Residuo_Diario", dtInicioParameter, dtFimParameter, idPrefeituraParameter, idRotaParameter, idResiduoParameter, prestadoraParameter, bColetaRealizadaParameter);
        }
    
        public virtual ObjectResult<Proc_Return_Total_Residuo_Mes_Ano_Result> Proc_Return_Total_Residuo_Mes_Ano(Nullable<System.DateTime> dtInicio, Nullable<System.DateTime> dtFim, Nullable<int> idPrefeitura, Nullable<int> idRota, Nullable<int> idResiduo, Nullable<int> prestadora, Nullable<bool> bColetaRealizada)
        {
            var dtInicioParameter = dtInicio.HasValue ?
                new ObjectParameter("dtInicio", dtInicio) :
                new ObjectParameter("dtInicio", typeof(System.DateTime));
    
            var dtFimParameter = dtFim.HasValue ?
                new ObjectParameter("dtFim", dtFim) :
                new ObjectParameter("dtFim", typeof(System.DateTime));
    
            var idPrefeituraParameter = idPrefeitura.HasValue ?
                new ObjectParameter("idPrefeitura", idPrefeitura) :
                new ObjectParameter("idPrefeitura", typeof(int));
    
            var idRotaParameter = idRota.HasValue ?
                new ObjectParameter("idRota", idRota) :
                new ObjectParameter("idRota", typeof(int));
    
            var idResiduoParameter = idResiduo.HasValue ?
                new ObjectParameter("idResiduo", idResiduo) :
                new ObjectParameter("idResiduo", typeof(int));
    
            var prestadoraParameter = prestadora.HasValue ?
                new ObjectParameter("Prestadora", prestadora) :
                new ObjectParameter("Prestadora", typeof(int));
    
            var bColetaRealizadaParameter = bColetaRealizada.HasValue ?
                new ObjectParameter("bColetaRealizada", bColetaRealizada) :
                new ObjectParameter("bColetaRealizada", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_Return_Total_Residuo_Mes_Ano_Result>("Proc_Return_Total_Residuo_Mes_Ano", dtInicioParameter, dtFimParameter, idPrefeituraParameter, idRotaParameter, idResiduoParameter, prestadoraParameter, bColetaRealizadaParameter);
        }
    }
}
