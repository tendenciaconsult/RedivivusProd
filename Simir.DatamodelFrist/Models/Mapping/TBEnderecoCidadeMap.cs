using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEnderecoCidadeMap : EntityTypeConfiguration<TBEnderecoCidade>
    {
        public TBEnderecoCidadeMap()
        {
            // Primary Key
            this.HasKey(t => t.EnderecoCidadeID);

            // Properties
            this.Property(t => t.nmCidade)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBEnderecoCidade");
            this.Property(t => t.EnderecoCidadeID).HasColumnName("EnderecoCidadeID");
            this.Property(t => t.nmCidade).HasColumnName("nmCidade");
            this.Property(t => t.EnderecoEstadoID).HasColumnName("EnderecoEstadoID");

            // Relationships
            this.HasRequired(t => t.TBEnderecoEstado)
                .WithMany(t => t.TBEnderecoCidades)
                .HasForeignKey(d => d.EnderecoEstadoID);

        }
    }
}
