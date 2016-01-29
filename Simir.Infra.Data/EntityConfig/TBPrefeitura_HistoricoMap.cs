using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBPrefeitura_HistoricoMap : EntityTypeConfiguration<TBPrefeitura_Historico>
    {
        public TBPrefeitura_HistoricoMap()
        {
            // Primary Key
            HasKey(t => t.Prefeitura_HistoricoID);

            Property(t => t.UserId)
                .HasMaxLength(128);
            // Properties
            Property(t => t.nmPrefeitura)
                .HasMaxLength(255);

            Property(t => t.nmPrefeito)
                .HasMaxLength(255);

            Property(t => t.CNPJ)
                .HasMaxLength(50);

            Property(t => t.Site)
                .HasMaxLength(255);


            // Table & Column Mappings
            ToTable("TBPrefeitura_Historico");
        }
    }
}