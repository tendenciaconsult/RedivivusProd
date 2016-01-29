using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class AspNetModuloMap : EntityTypeConfiguration<AspNetModulo>
    {
        public AspNetModuloMap()
        {
            // Primary Key
            this.HasKey(t => t.AspNetModuloId);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            this.Property(t => t.Display)
                .HasMaxLength(100);

            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AspNetModulo");
            this.Property(t => t.AspNetModuloId).HasColumnName("AspNetModuloId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Display).HasColumnName("Display");
            this.Property(t => t.AspNetControllerId).HasColumnName("AspNetControllerId");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            this.Property(t => t.ModuloPaiId).HasColumnName("ModuloPaiId");
            this.Property(t => t.Nivel).HasColumnName("Nivel");
            this.Property(t => t.bVisivelDisplay).HasColumnName("bVisivelDisplay");

            // Relationships
            this.HasOptional(t => t.AspNetController)
                .WithMany(t => t.AspNetModuloes)
                .HasForeignKey(d => d.AspNetControllerId);
            this.HasOptional(t => t.AspNetModulo2)
                .WithMany(t => t.AspNetModulo1)
                .HasForeignKey(d => d.ModuloPaiId);

        }
    }
}
