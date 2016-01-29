using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class AspNetTipoPermissaoMap : EntityTypeConfiguration<AspNetTipoPermissao>
    {
        public AspNetTipoPermissaoMap()
        {
            // Primary Key
            this.HasKey(t => t.AspNetTipoPermissaoId);

            // Properties
            this.Property(t => t.AspNetTipoPermissaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("AspNetTipoPermissao");
            this.Property(t => t.AspNetTipoPermissaoId).HasColumnName("AspNetTipoPermissaoId");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
