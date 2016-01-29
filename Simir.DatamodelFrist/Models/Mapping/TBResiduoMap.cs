using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduoMap : EntityTypeConfiguration<TBResiduo>
    {
        public TBResiduoMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduoID);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(800);

            this.Property(t => t.nmResiduo)
                .IsRequired()
                .HasMaxLength(800);

            // Table & Column Mappings
            this.ToTable("TBResiduo");
            this.Property(t => t.ResiduoID).HasColumnName("ResiduoID");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.nmResiduo).HasColumnName("nmResiduo");
        }
    }
}
