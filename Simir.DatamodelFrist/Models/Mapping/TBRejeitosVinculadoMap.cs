using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRejeitosVinculadoMap : EntityTypeConfiguration<TBRejeitosVinculado>
    {
        public TBRejeitosVinculadoMap()
        {
            // Primary Key
            this.HasKey(t => t.RejeitosVinculadosID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TBRejeitosVinculados");
            this.Property(t => t.RejeitosVinculadosID).HasColumnName("RejeitosVinculadosID");
            this.Property(t => t.DestinacaoRejeitoID).HasColumnName("DestinacaoRejeitoID");
            this.Property(t => t.ResiduoID).HasColumnName("ResiduoID");
            this.Property(t => t.qtRejeitoVinculado).HasColumnName("qtRejeitoVinculado");

            // Relationships
            this.HasOptional(t => t.TBDestinacaoRejeito)
                .WithMany(t => t.TBRejeitosVinculados)
                .HasForeignKey(d => d.DestinacaoRejeitoID);
            this.HasOptional(t => t.TBResiduo)
                .WithMany(t => t.TBRejeitosVinculados)
                .HasForeignKey(d => d.ResiduoID);

        }
    }
}
