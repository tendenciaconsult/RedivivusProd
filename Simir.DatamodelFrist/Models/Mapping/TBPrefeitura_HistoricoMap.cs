using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBPrefeitura_HistoricoMap : EntityTypeConfiguration<TBPrefeitura_Historico>
    {
        public TBPrefeitura_HistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.Prefeitura_HistoricoID);

            // Properties
            this.Property(t => t.nmPrefeitura)
                .HasMaxLength(255);

            this.Property(t => t.nmPrefeito)
                .HasMaxLength(255);

            this.Property(t => t.CNPJ)
                .HasMaxLength(50);

            this.Property(t => t.Site)
                .HasMaxLength(255);

            this.Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBPrefeitura_Historico");
            this.Property(t => t.Prefeitura_HistoricoID).HasColumnName("Prefeitura_HistoricoID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.nmPrefeitura).HasColumnName("nmPrefeitura");
            this.Property(t => t.nmPrefeito).HasColumnName("nmPrefeito");
            this.Property(t => t.CNPJ).HasColumnName("CNPJ");
            this.Property(t => t.Site).HasColumnName("Site");
            this.Property(t => t.qtHabitantesHurbanos).HasColumnName("qtHabitantesHurbanos");
            this.Property(t => t.qthabitantesRurais).HasColumnName("qthabitantesRurais");
            this.Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
