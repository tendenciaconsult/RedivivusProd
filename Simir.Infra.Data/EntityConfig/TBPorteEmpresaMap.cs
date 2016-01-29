using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBPorteEmpresaMap : EntityTypeConfiguration<TBPorteEmpresa>
    {
        public TBPorteEmpresaMap()
        {
            // Primary Key
            HasKey(t => t.PorteEmpresaID);

            // Properties
            Property(t => t.nmPorteEmpresa)
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("TBPorteEmpresa");
            Property(t => t.PorteEmpresaID).HasColumnName("PorteEmpresaID");
            Property(t => t.nmPorteEmpresa).HasColumnName("nmPorteEmpresa");
        }
    }
}