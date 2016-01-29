using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEnderecoMap : EntityTypeConfiguration<TBEndereco>
    {
        public TBEnderecoMap()
        {
            // Primary Key
            this.HasKey(t => t.EnderecoID);

            // Properties
            this.Property(t => t.Numero)
                .HasMaxLength(10);

            this.Property(t => t.Complemento)
                .HasMaxLength(50);

            this.Property(t => t.CEP)
                .HasMaxLength(30);

            this.Property(t => t.nmLogradouro)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBEndereco");
            this.Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Complemento).HasColumnName("Complemento");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.EnderecoCidadeID).HasColumnName("EnderecoCidadeID");
            this.Property(t => t.EnderecoEstadoID).HasColumnName("EnderecoEstadoID");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.nmLogradouro).HasColumnName("nmLogradouro");

            // Relationships
            this.HasRequired(t => t.TBEnderecoBairro)
                .WithMany(t => t.TBEnderecoes)
                .HasForeignKey(d => d.EnderecoBairroID);
            this.HasRequired(t => t.TBEnderecoCidade)
                .WithMany(t => t.TBEnderecoes)
                .HasForeignKey(d => d.EnderecoCidadeID);
            this.HasRequired(t => t.TBEnderecoEstado)
                .WithMany(t => t.TBEnderecoes)
                .HasForeignKey(d => d.EnderecoEstadoID);

        }
    }
}
