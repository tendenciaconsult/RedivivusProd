using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBColetaEventualHistoricoMap : EntityTypeConfiguration<TBColetaEventualHistorico>
    {
        public TBColetaEventualHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.ColetaEventualHistoricoID);

            // Properties
            Property(t => t.nmColetaEventual)
                .HasMaxLength(255);

            Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBColetaEventualHistorico");
            Property(t => t.ColetaEventualHistoricoID).HasColumnName("ColetaEventualHistoricoID");
            Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            Property(t => t.RotasID).HasColumnName("RotasID");
            Property(t => t.dtColeta).HasColumnName("dtColeta");
            Property(t => t.DistanciaInicial).HasColumnName("DistanciaInicial");
            Property(t => t.DistanciaFinal).HasColumnName("DistanciaFinal");
            Property(t => t.qtGari).HasColumnName("qtGari");
            Property(t => t.nmColetaEventual).HasColumnName("nmColetaEventual");
            Property(t => t.bColetaOrdinaria).HasColumnName("bColetaOrdinaria");
            Property(t => t.qtColetaDia).HasColumnName("qtColetaDia");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}