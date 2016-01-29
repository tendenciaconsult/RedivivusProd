using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBSecretariaMap : EntityTypeConfiguration<TBSecretaria>
    {
        public TBSecretariaMap()
        {
            // Primary Key
            HasKey(t => t.SecretariaID);

            // Properties
            Property(t => t.nmSecretaria)
                .HasMaxLength(255);

            Property(t => t.nmSecretario)
                .HasMaxLength(255);

            Property(t => t.Site)
                .HasMaxLength(255);

            Property(t => t.Telefone1)
                .HasMaxLength(255);

            Property(t => t.Telefone2)
                .HasMaxLength(255);

            Property(t => t.Email)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBSecretaria");
            Property(t => t.SecretariaID).HasColumnName("SecretariaID");
            Property(t => t.nmSecretaria).HasColumnName("nmSecretaria");
            Property(t => t.nmSecretario).HasColumnName("nmSecretario");
            Property(t => t.Site).HasColumnName("Site");
            Property(t => t.Telefone1).HasColumnName("Telefone1");
            Property(t => t.Telefone2).HasColumnName("Telefone2");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");

            // Relationships
            HasOptional(t => t.TBEndereco)
                .WithMany()
                .HasForeignKey(d => d.EnderecoID);
            HasOptional(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
        }
    }
}