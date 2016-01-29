using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduoClasseMap : EntityTypeConfiguration<TBResiduoClasse>
    {
        public TBResiduoClasseMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduoClasseID);

            // Properties
            this.Property(t => t.nmResiduoClasse)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(800);

            // Table & Column Mappings
            this.ToTable("TBResiduoClasse");
            this.Property(t => t.ResiduoClasseID).HasColumnName("ResiduoClasseID");
            this.Property(t => t.nmResiduoClasse).HasColumnName("nmResiduoClasse");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
