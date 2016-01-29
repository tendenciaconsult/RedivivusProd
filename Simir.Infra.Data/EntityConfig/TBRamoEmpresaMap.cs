using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRamoEmpresaMap : EntityTypeConfiguration<TBRamoEmpresa>
    {
        public TBRamoEmpresaMap()
        {
            // Primary Key
            HasKey(t => t.RamoEmpresaID);

            // Properties
            Property(t => t.nmRamoEmpresa)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("TBRamoEmpresa");
            Property(t => t.RamoEmpresaID).HasColumnName("RamoEmpresaID");
            Property(t => t.nmRamoEmpresa).HasColumnName("nmRamoEmpresa");
        }
    }
}