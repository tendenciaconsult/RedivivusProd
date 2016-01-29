using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEnderecoEstadoMap : EntityTypeConfiguration<TBEnderecoEstado>
    {
        public TBEnderecoEstadoMap()
        {
            // Primary Key
            HasKey(t => t.EnderecoEstadoID);

            // Properties
            Property(t => t.nmEstado)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Abraviacao)
                .IsRequired()
                .HasMaxLength(2);

            // Table & Column Mappings
            ToTable("TBEnderecoEstado");
            Property(t => t.EnderecoEstadoID).HasColumnName("EnderecoEstadoID");
            Property(t => t.nmEstado).HasColumnName("nmEstado");
            Property(t => t.Abraviacao).HasColumnName("Abraviacao");
        }
    }
}