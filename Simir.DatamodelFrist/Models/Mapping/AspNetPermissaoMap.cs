using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class AspNetPermissaoMap : EntityTypeConfiguration<AspNetPermissao>
    {
        public AspNetPermissaoMap()
        {
            // Primary Key
            this.HasKey(t => t.AspNetPermissaoId);

            // Properties
            // Table & Column Mappings
            this.ToTable("AspNetPermissao");
            this.Property(t => t.AspNetPermissaoId).HasColumnName("AspNetPermissaoId");
            this.Property(t => t.AspNetPerfilId).HasColumnName("AspNetPerfilId");
            this.Property(t => t.AspNetModuloId).HasColumnName("AspNetModuloId");
            this.Property(t => t.AspNetTipoPermissaoId).HasColumnName("AspNetTipoPermissaoId");

            // Relationships
            this.HasRequired(t => t.AspNetModulo)
                .WithMany(t => t.AspNetPermissaos)
                .HasForeignKey(d => d.AspNetModuloId);
            this.HasRequired(t => t.AspNetPerfil)
                .WithMany(t => t.AspNetPermissaos)
                .HasForeignKey(d => d.AspNetPerfilId);

        }
    }
}
