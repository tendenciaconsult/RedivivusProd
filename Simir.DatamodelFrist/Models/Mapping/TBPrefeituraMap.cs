using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBPrefeituraMap : EntityTypeConfiguration<TBPrefeitura>
    {
        public TBPrefeituraMap()
        {
            // Primary Key
            this.HasKey(t => t.PrefeituraID);

            // Properties
            this.Property(t => t.nmPrefeitura)
                .HasMaxLength(255);

            this.Property(t => t.nmPrefeito)
                .HasMaxLength(255);

            this.Property(t => t.CNPJ)
                .HasMaxLength(50);

            this.Property(t => t.Site)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBPrefeitura");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.nmPrefeitura).HasColumnName("nmPrefeitura");
            this.Property(t => t.nmPrefeito).HasColumnName("nmPrefeito");
            this.Property(t => t.CNPJ).HasColumnName("CNPJ");
            this.Property(t => t.Site).HasColumnName("Site");
            this.Property(t => t.qtHabitantesUrbanos).HasColumnName("qtHabitantesUrbanos");
            this.Property(t => t.qthabitantesRurais).HasColumnName("qthabitantesRurais");
            this.Property(t => t.EnderecoID).HasColumnName("EnderecoID");

            // Relationships
            this.HasOptional(t => t.TBEndereco)
                .WithMany(t => t.TBPrefeituras)
                .HasForeignKey(d => d.EnderecoID);

        }
    }
}
