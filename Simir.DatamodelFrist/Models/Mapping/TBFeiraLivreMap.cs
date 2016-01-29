using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBFeiraLivreMap : EntityTypeConfiguration<TBFeiraLivre>
    {
        public TBFeiraLivreMap()
        {
            // Primary Key
            this.HasKey(t => t.FeiraLivreID);

            // Properties
            this.Property(t => t.nmProgramacao)
                .IsRequired()
                .HasMaxLength(110);

            // Table & Column Mappings
            this.ToTable("TBFeiraLivre");
            this.Property(t => t.FeiraLivreID).HasColumnName("FeiraLivreID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            this.Property(t => t.BairroID).HasColumnName("BairroID");
            this.Property(t => t.LogradouroID).HasColumnName("LogradouroID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasRequired(t => t.TBEnderecoBairro)
                .WithMany(t => t.TBFeiraLivres)
                .HasForeignKey(d => d.BairroID);
            this.HasRequired(t => t.TBEnderecoLogradouro)
                .WithMany(t => t.TBFeiraLivres)
                .HasForeignKey(d => d.LogradouroID);
            this.HasRequired(t => t.TBPrefeitura)
                .WithMany(t => t.TBFeiraLivres)
                .HasForeignKey(d => d.PrefeituraID);
            this.HasRequired(t => t.TBRegiaoAdministrativa)
                .WithMany(t => t.TBFeiraLivres)
                .HasForeignKey(d => d.RegiaoAdministrativaID);

        }
    }
}
