using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEnderecoBairroMap : EntityTypeConfiguration<TBEnderecoBairro>
    {
        public TBEnderecoBairroMap()
        {
            // Primary Key
            this.HasKey(t => t.EnderecoBairroID);

            // Properties
            this.Property(t => t.nmBairro)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBEnderecoBairro");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.nmBairro).HasColumnName("nmBairro");
            this.Property(t => t.EnderecoCidadeID).HasColumnName("EnderecoCidadeID");

            // Relationships
            this.HasRequired(t => t.TBEnderecoCidade)
                .WithMany(t => t.TBEnderecoBairroes)
                .HasForeignKey(d => d.EnderecoCidadeID);

        }
    }
}
