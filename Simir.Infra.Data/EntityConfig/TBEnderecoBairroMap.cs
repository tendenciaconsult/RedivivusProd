using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEnderecoBairroMap : EntityTypeConfiguration<TBEnderecoBairro>
    {
        public TBEnderecoBairroMap()
        {
            // Primary Key
            HasKey(t => t.EnderecoBairroID);

            // Properties
            Property(t => t.nmBairro)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBEnderecoBairro");
            Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            Property(t => t.nmBairro).HasColumnName("nmBairro");
            Property(t => t.EnderecoCidadeID).HasColumnName("EnderecoCidadeID");

            // Relationships
            HasRequired(t => t.TBEnderecoCidade)
                .WithMany() //.WithMany(t => t.TBEnderecoBairro)
                .HasForeignKey(d => d.EnderecoCidadeID);
        }
    }
}