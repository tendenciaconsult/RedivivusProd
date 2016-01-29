using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResponsabilidadeMap : EntityTypeConfiguration<TBResponsabilidade>
    {
        public TBResponsabilidadeMap()
        {
            // Primary Key
            HasKey(t => t.ResponsabilidadesID);

            // Properties
            Property(t => t.nmResponsabilidades)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBResponsabilidades");
            Property(t => t.ResponsabilidadesID).HasColumnName("ResponsabilidadesID");
            Property(t => t.nmResponsabilidades).HasColumnName("nmResponsabilidades");
        }
    }
}