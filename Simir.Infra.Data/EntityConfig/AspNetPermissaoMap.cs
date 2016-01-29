using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetPermissaoMap : EntityTypeConfiguration<AspNetPermissao>
    {
        public AspNetPermissaoMap()
        {
            // Primary Key
            HasKey(t => t.AspNetPermissaoId);

            // Properties
            // Table & Column Mappings
            ToTable("AspNetPermissao");
            //this.Property(t => t.AspNetPerfilModuloId).HasColumnName("AspNetPerfilModuloId");
            Property(t => t.AspNetPerfilId).HasColumnName("AspNetPerfilId");
            Property(t => t.AspNetModuloId).HasColumnName("AspNetModuloId");


            // Relationships

            /*
            this.HasMany(t => t.Permissoes)
                .WithMany(t => t.AspNetPerfilModuloes)
                .Map(m =>
                    {
                        m.ToTable("AspNetPermissao");
                        m.MapLeftKey("AspNetPerfilModuloRefId");
                        m.MapRightKey("AspNetTipoPermissaoRefId");
                    });
             * */

            HasRequired(t => t.AspNetModulo)
                .WithMany() //(t => t.PerfilModulos)
                .HasForeignKey(d => d.AspNetModuloId);
            HasRequired(t => t.AspNetPerfil)
                .WithMany(t => t.Permissoes)
                .HasForeignKey(d => d.AspNetPerfilId);
            /*
            HasRequired(t => t.AspNetTipoPermissao)
                .WithMany()
                .HasForeignKey(d => d.AspNetTipoPermissaoId);
             */
        }
    }
}