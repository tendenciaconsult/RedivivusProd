using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduoVinculadoMap : EntityTypeConfiguration<TBResiduoVinculado>
    {
        public TBResiduoVinculadoMap()
        {
            // Primary Key
            HasKey(t => t.ResiduoVinculadoID);

            // Properties
            // Table & Column Mappings
            ToTable("TBResiduoVinculado");
            Property(t => t.ResiduoVinculadoID).HasColumnName("ResiduoVinculadoID");
            Property(t => t.DestinacaoRejeitoID).HasColumnName("DestinacaoRejeitoID");
            Property(t => t.ResiduoID).HasColumnName("ResiduoID");
            Property(t => t.qtRejeitoVinculado).HasColumnName("qtRejeitoVinculado");

            // Relationships
            HasOptional(t => t.TBDestinacaoRejeito)
                .WithMany()
                .HasForeignKey(d => d.DestinacaoRejeitoID);
            HasOptional(t => t.TBResiduo)
                .WithMany()
                .HasForeignKey(d => d.ResiduoID);
        }
    }
}