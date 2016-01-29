using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBPorteEmpresaMap : EntityTypeConfiguration<TBPorteEmpresa>
    {
        public TBPorteEmpresaMap()
        {
            // Primary Key
            this.HasKey(t => t.PorteEmpresaID);

            // Properties
            this.Property(t => t.nmPorteEmpresa)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("TBPorteEmpresa");
            this.Property(t => t.PorteEmpresaID).HasColumnName("PorteEmpresaID");
            this.Property(t => t.nmPorteEmpresa).HasColumnName("nmPorteEmpresa");
        }
    }
}
