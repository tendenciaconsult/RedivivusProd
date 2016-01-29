using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBSecretariasResponsabilidadeMap : EntityTypeConfiguration<TBSecretariasResponsabilidade>
    {
        public TBSecretariasResponsabilidadeMap()
        {
            // Primary Key
            this.HasKey(t => t.SecretariasResponsabilidadesID);

            // Properties
            this.Property(t => t.nmOutros)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBSecretariasResponsabilidades");
            this.Property(t => t.SecretariasResponsabilidadesID).HasColumnName("SecretariasResponsabilidadesID");
            this.Property(t => t.ResponsabilidadesID).HasColumnName("ResponsabilidadesID");
            this.Property(t => t.SecretariaID).HasColumnName("SecretariaID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.nmOutros).HasColumnName("nmOutros");

            // Relationships
            this.HasOptional(t => t.TBPrefeitura)
                .WithMany(t => t.TBSecretariasResponsabilidades)
                .HasForeignKey(d => d.PrefeituraID);
            this.HasOptional(t => t.TBResponsabilidade)
                .WithMany(t => t.TBSecretariasResponsabilidades)
                .HasForeignKey(d => d.ResponsabilidadesID);
            this.HasOptional(t => t.TBSecretaria)
                .WithMany(t => t.TBSecretariasResponsabilidades)
                .HasForeignKey(d => d.SecretariaID);

        }
    }
}
