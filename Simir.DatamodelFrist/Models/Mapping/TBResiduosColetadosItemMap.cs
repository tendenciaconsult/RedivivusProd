using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduosColetadosItemMap : EntityTypeConfiguration<TBResiduosColetadosItem>
    {
        public TBResiduosColetadosItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosColetadosItemID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TBResiduosColetadosItem");
            this.Property(t => t.ResiduosColetadosItemID).HasColumnName("ResiduosColetadosItemID");
            this.Property(t => t.ResiduosColetadosID).HasColumnName("ResiduosColetadosID");
            this.Property(t => t.ResiduoClassificadoID).HasColumnName("ResiduoClassificadoID");
            this.Property(t => t.emLitros).HasColumnName("emLitros");
            this.Property(t => t.qtResiduo).HasColumnName("qtResiduo");

            // Relationships
            this.HasRequired(t => t.TBResiduoClassificado)
                .WithMany(t => t.TBResiduosColetadosItems)
                .HasForeignKey(d => d.ResiduoClassificadoID);
            this.HasRequired(t => t.TBResiduosColetado)
                .WithMany(t => t.TBResiduosColetadosItems)
                .HasForeignKey(d => d.ResiduosColetadosID);

        }
    }
}
