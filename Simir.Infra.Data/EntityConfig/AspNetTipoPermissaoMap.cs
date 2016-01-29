using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetTipoPermissaoMap : EntityTypeConfiguration<AspNetTipoPermissao>
    {
        public AspNetTipoPermissaoMap()
        {
            // Primary Key
            HasKey(t => t.AspNetTipoPermissaoId);

            // Properties
            Property(t => t.AspNetTipoPermissaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("AspNetTipoPermissao");
            Property(t => t.AspNetTipoPermissaoId).HasColumnName("AspNetTipoPermissaoId");
            Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}