using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduosDestinadoresItemMap : EntityTypeConfiguration<TBResiduosDestinadoresItem>
    {
        public TBResiduosDestinadoresItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosDestinadoresItemID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TBResiduosDestinadoresItem");
            this.Property(t => t.ResiduosDestinadoresItemID).HasColumnName("ResiduosDestinadoresItemID");
            this.Property(t => t.ResiduoClassificadoID).HasColumnName("ResiduoClassificadoID");
            this.Property(t => t.emLitros).HasColumnName("emLitros");
            this.Property(t => t.qtResiduo).HasColumnName("qtResiduo");
            this.Property(t => t.ResiduosDestinadoresID).HasColumnName("ResiduosDestinadoresID");

            // Relationships
            this.HasRequired(t => t.TBResiduoClassificado)
                .WithMany(t => t.TBResiduosDestinadoresItems)
                .HasForeignKey(d => d.ResiduoClassificadoID);
            this.HasOptional(t => t.TBResiduosDestinadore)
                .WithMany(t => t.TBResiduosDestinadoresItems)
                .HasForeignKey(d => d.ResiduosDestinadoresID);

        }
    }
}
