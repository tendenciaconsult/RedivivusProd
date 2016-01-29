using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRamoEmpresaMap : EntityTypeConfiguration<TBRamoEmpresa>
    {
        public TBRamoEmpresaMap()
        {
            // Primary Key
            this.HasKey(t => t.RamoEmpresaID);

            // Properties
            this.Property(t => t.nmRamoEmpresa)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TBRamoEmpresa");
            this.Property(t => t.RamoEmpresaID).HasColumnName("RamoEmpresaID");
            this.Property(t => t.nmRamoEmpresa).HasColumnName("nmRamoEmpresa");
        }
    }
}
