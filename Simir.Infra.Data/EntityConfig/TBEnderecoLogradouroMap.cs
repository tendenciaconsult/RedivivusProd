using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEnderecoLogradouroMap : EntityTypeConfiguration<TBEnderecoLogradouro>
    {
        public TBEnderecoLogradouroMap()
        {
            // Primary Key
            HasKey(t => t.EnderecoLogradouroID);

            // Properties
            Property(t => t.nmLogradouro)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.CEP)
                .HasMaxLength(30);

            // Table & Column Mappings
            ToTable("TBEnderecoLogradouro");
            Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            Property(t => t.nmLogradouro).HasColumnName("nmLogradouro");
            Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            Property(t => t.CEP).HasColumnName("CEP");
            //this.Property(t => t.tipo).HasColumnName("tipo");

            // Relationships
            HasRequired(t => t.TBEnderecoBairro)
                .WithMany()
                //.WithMany(t => t.TBEnderecoLogradouro)
                .HasForeignKey(d => d.EnderecoBairroID);
        }
    }
}