using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduosGeradosItemMap : EntityTypeConfiguration<TBResiduosGeradosItem>
    {
        public TBResiduosGeradosItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosGeradosItemID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TBResiduosGeradosItem");
            this.Property(t => t.ResiduosGeradosItemID).HasColumnName("ResiduosGeradosItemID");
            this.Property(t => t.ResiduosGeradosID).HasColumnName("ResiduosGeradosID");
            this.Property(t => t.ResiduoClassificadoID).HasColumnName("ResiduoClassificadoID");
            this.Property(t => t.emLitros).HasColumnName("emLitros");
            this.Property(t => t.qtResiduo).HasColumnName("qtResiduo");

            // Relationships
            this.HasRequired(t => t.TBResiduoClassificado)
                .WithMany(t => t.TBResiduosGeradosItems)
                .HasForeignKey(d => d.ResiduoClassificadoID);
            this.HasRequired(t => t.TBResiduosGerado)
                .WithMany(t => t.TBResiduosGeradosItems)
                .HasForeignKey(d => d.ResiduosGeradosID);

        }
    }
}
