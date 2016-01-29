using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBPrefeituraMap : EntityTypeConfiguration<TBPrefeitura>
    {
        public TBPrefeituraMap()
        {
            // Primary Key
            HasKey(t => t.PrefeituraID);

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
            ToTable("TBPrefeitura");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.nmPrefeitura).HasColumnName("nmPrefeitura");
            Property(t => t.nmPrefeito).HasColumnName("nmPrefeito");
            Property(t => t.CNPJ).HasColumnName("CNPJ");
            Property(t => t.Site).HasColumnName("Site");
            //Property(t => t.qtHabitantesUrbanos).HasColumnName("qtHabitantesUrbanos");
            //Property(t => t.qthabitantesRurais).HasColumnName("qthabitantesRurais");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");

            // Relationships
            HasOptional(t => t.TBEndereco)
                .WithMany()
                .HasForeignKey(d => d.EnderecoID);
        }
    }
}