using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBColetaEventualHistoricoMap : EntityTypeConfiguration<TBColetaEventualHistorico>
    {
        public TBColetaEventualHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.ColetaEventualHistoricoID);

            // Properties
            this.Property(t => t.nmColetaEventual)
                .HasMaxLength(255);

            this.Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBColetaEventualHistorico");
            this.Property(t => t.ColetaEventualHistoricoID).HasColumnName("ColetaEventualHistoricoID");
            this.Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.RotasID).HasColumnName("RotasID");
            this.Property(t => t.dtColeta).HasColumnName("dtColeta");
            this.Property(t => t.DistanciaInicial).HasColumnName("DistanciaInicial");
            this.Property(t => t.DistanciaFinal).HasColumnName("DistanciaFinal");
            this.Property(t => t.qtGari).HasColumnName("qtGari");
            this.Property(t => t.nmColetaEventual).HasColumnName("nmColetaEventual");
            this.Property(t => t.bColetaOrdinaria).HasColumnName("bColetaOrdinaria");
            this.Property(t => t.qtColetaDia).HasColumnName("qtColetaDia");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
