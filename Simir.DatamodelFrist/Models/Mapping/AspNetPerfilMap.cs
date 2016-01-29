using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class AspNetPerfilMap : EntityTypeConfiguration<AspNetPerfil>
    {
        public AspNetPerfilMap()
        {
            // Primary Key
            this.HasKey(t => t.AspNetPerfilId);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AspNetPerfil");
            this.Property(t => t.AspNetPerfilId).HasColumnName("AspNetPerfilId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasMany(t => t.AspNetUsers)
                .WithMany(t => t.AspNetPerfils)
                .Map(m =>
                    {
                        m.ToTable("AspNetUserPerfil");
                        m.MapLeftKey("AspNetPerfilRefId");
                        m.MapRightKey("AspNetUserRefId");
                    });

            this.HasOptional(t => t.TBPrefeitura)
                .WithMany(t => t.AspNetPerfils)
                .HasForeignKey(d => d.PrefeituraID);

        }
    }
}
