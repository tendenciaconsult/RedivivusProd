using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResponsabilidadeMap : EntityTypeConfiguration<TBResponsabilidade>
    {
        public TBResponsabilidadeMap()
        {
            // Primary Key
            this.HasKey(t => t.ResponsabilidadesID);

            // Properties
            this.Property(t => t.nmResponsabilidades)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBResponsabilidades");
            this.Property(t => t.ResponsabilidadesID).HasColumnName("ResponsabilidadesID");
            this.Property(t => t.nmResponsabilidades).HasColumnName("nmResponsabilidades");
        }
    }
}
