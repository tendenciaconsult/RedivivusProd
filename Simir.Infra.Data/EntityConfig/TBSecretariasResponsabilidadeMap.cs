using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBSecretariasResponsabilidadeMap : EntityTypeConfiguration<TBSecretariasResponsabilidade>
    {
        public TBSecretariasResponsabilidadeMap()
        {
            // Primary Key
            HasKey(t => t.SecretariasResponsabilidadesID);

            // Properties
            Property(t => t.nmOutros)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBSecretariasResponsabilidades");
            Property(t => t.SecretariasResponsabilidadesID).HasColumnName("SecretariasResponsabilidadesID");
            Property(t => t.ResponsabilidadesID).HasColumnName("ResponsabilidadesID");
            Property(t => t.SecretariaID).HasColumnName("SecretariaID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.nmOutros).HasColumnName("nmOutros");

            // Relationships
            HasOptional(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
            HasOptional(t => t.TBResponsabilidade)
                .WithMany()
                .HasForeignKey(d => d.ResponsabilidadesID);
            HasOptional(t => t.TBSecretaria)
                .WithMany(t => t.TBSecretariasResponsabilidades)
                .HasForeignKey(d => d.SecretariaID);
        }
    }
}