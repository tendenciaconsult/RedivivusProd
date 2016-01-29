using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEnderecoMap : EntityTypeConfiguration<TBEndereco>
    {
        public TBEnderecoMap()
        {
            // Primary Key
            HasKey(t => t.EnderecoID);

            // Properties
            Property(t => t.Numero)
                .HasMaxLength(10);

            Property(t => t.Complemento)
                .HasMaxLength(50);

            Property(t => t.CEP)
                .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("TBEndereco");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Complemento).HasColumnName("Complemento");
            Property(t => t.nmLogradouro).HasColumnName("nmLogradouro");
            Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            Property(t => t.EnderecoCidadeID).HasColumnName("EnderecoCidadeID");
            Property(t => t.EnderecoEstadoID).HasColumnName("EnderecoEstadoID");
            Property(t => t.CEP).HasColumnName("CEP");

            // Relationships
            //this.HasRequired(t => t.TBEnderecoLogradouro)
            //.WithMany()
            //.WithMany(t => t.TBEndereco)
            //.HasForeignKey(d => d.EnderecoLogradouroID);
            HasRequired(t => t.TBEnderecoBairro)
                .WithMany() //.WithMany(t => t.TBEnderecoes)
                .HasForeignKey(d => d.EnderecoBairroID);
            HasRequired(t => t.TBEnderecoCidade)
                .WithMany() //.WithMany(t => t.TBEnderecoes)
                .HasForeignKey(d => d.EnderecoCidadeID);
            HasRequired(t => t.TBEnderecoEstado)
                .WithMany() //.WithMany(t => t.TBEnderecoes)
                .HasForeignKey(d => d.EnderecoEstadoID);
        }
    }
}