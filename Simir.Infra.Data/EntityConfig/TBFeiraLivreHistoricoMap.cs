using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBFeiraLivreHistoricoMap : EntityTypeConfiguration<TBFeiraLivreHistorico>
    {
        public TBFeiraLivreHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.FeiraLivreHistoricoID);

            // Properties
            Property(t => t.nmProgramacao)
                .HasMaxLength(110);

            Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBFeiraLivreHistorico");
            Property(t => t.FeiraLivreHistoricoID).HasColumnName("FeiraLivreHistoricoID");
            Property(t => t.FeiraLivreID).HasColumnName("FeiraLivreID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            Property(t => t.BairroID).HasColumnName("BairroID");
            Property(t => t.LogradouroID).HasColumnName("LogradouroID");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}