using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEnderecoCidadeMap : EntityTypeConfiguration<TBEnderecoCidade>
    {
        public TBEnderecoCidadeMap()
        {
            // Primary Key
            HasKey(t => t.EnderecoCidadeID);

            // Properties
            Property(t => t.nmCidade)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBEnderecoCidade");
            Property(t => t.EnderecoCidadeID).HasColumnName("EnderecoCidadeID");
            Property(t => t.nmCidade).HasColumnName("nmCidade");
            Property(t => t.EnderecoEstadoID).HasColumnName("EnderecoEstadoID");

            // Relationships
            HasRequired(t => t.TBEnderecoEstado)
                .WithMany() //.WithMany(t => t.TBEnderecoCidades)
                .HasForeignKey(d => d.EnderecoEstadoID);
        }
    }
}