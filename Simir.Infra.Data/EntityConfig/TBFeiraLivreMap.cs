using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBFeiraLivreMap : EntityTypeConfiguration<TBFeiraLivre>
    {
        public TBFeiraLivreMap()
        {
            // Primary Key
            HasKey(t => t.FeiraLivreID);

            // Properties
            Property(t => t.nmProgramacao)
                .IsRequired()
                .HasMaxLength(110);

            // Table & Column Mappings
            ToTable("TBFeiraLivre");
            Property(t => t.FeiraLivreID).HasColumnName("FeiraLivreID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            Property(t => t.BairroID).HasColumnName("BairroID");
            Property(t => t.LogradouroID).HasColumnName("LogradouroID");
            Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            HasRequired(t => t.TBEnderecoBairro)
                .WithMany()
                .HasForeignKey(d => d.BairroID);
            HasRequired(t => t.TBEnderecoLogradouro)
                .WithMany()
                .HasForeignKey(d => d.LogradouroID);
            HasRequired(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
            HasRequired(t => t.TBRegiaoAdministrativa)
                .WithMany()
                .HasForeignKey(d => d.RegiaoAdministrativaID);
        }
    }
}