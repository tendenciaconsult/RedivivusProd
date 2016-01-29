using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBFeiraLivreHistoricoMap : EntityTypeConfiguration<TBFeiraLivreHistorico>
    {
        public TBFeiraLivreHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.FeiraLivreHistoricoID);

            // Properties
            this.Property(t => t.nmProgramacao)
                .HasMaxLength(110);

            this.Property(t => t.UserID)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBFeiraLivreHistorico");
            this.Property(t => t.FeiraLivreHistoricoID).HasColumnName("FeiraLivreHistoricoID");
            this.Property(t => t.FeiraLivreID).HasColumnName("FeiraLivreID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            this.Property(t => t.BairroID).HasColumnName("BairroID");
            this.Property(t => t.LogradouroID).HasColumnName("LogradouroID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
        }
    }
}
