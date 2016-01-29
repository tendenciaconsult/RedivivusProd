using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEnderecoEstadoMap : EntityTypeConfiguration<TBEnderecoEstado>
    {
        public TBEnderecoEstadoMap()
        {
            // Primary Key
            this.HasKey(t => t.EnderecoEstadoID);

            // Properties
            this.Property(t => t.nmEstado)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Abraviacao)
                .IsRequired()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("TBEnderecoEstado");
            this.Property(t => t.EnderecoEstadoID).HasColumnName("EnderecoEstadoID");
            this.Property(t => t.nmEstado).HasColumnName("nmEstado");
            this.Property(t => t.Abraviacao).HasColumnName("Abraviacao");
        }
    }
}
