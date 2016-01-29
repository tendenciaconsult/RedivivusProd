using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEnderecoLogradouroMap : EntityTypeConfiguration<TBEnderecoLogradouro>
    {
        public TBEnderecoLogradouroMap()
        {
            // Primary Key
            this.HasKey(t => t.EnderecoLogradouroID);

            // Properties
            this.Property(t => t.nmLogradouro)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CEP)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("TBEnderecoLogradouro");
            this.Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            this.Property(t => t.nmLogradouro).HasColumnName("nmLogradouro");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.tipo).HasColumnName("tipo");

            // Relationships
            this.HasRequired(t => t.TBEnderecoBairro)
                .WithMany(t => t.TBEnderecoLogradouroes)
                .HasForeignKey(d => d.EnderecoBairroID);

        }
    }
}
