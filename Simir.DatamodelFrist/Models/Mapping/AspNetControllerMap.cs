using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class AspNetControllerMap : EntityTypeConfiguration<AspNetController>
    {
        public AspNetControllerMap()
        {
            // Primary Key
            this.HasKey(t => t.AspNetControllerId);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            this.Property(t => t.Display)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AspNetController");
            this.Property(t => t.AspNetControllerId).HasColumnName("AspNetControllerId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Display).HasColumnName("Display");
        }
    }
}
