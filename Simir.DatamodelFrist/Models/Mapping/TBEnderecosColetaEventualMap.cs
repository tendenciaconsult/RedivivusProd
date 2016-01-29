using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEnderecosColetaEventualMap : EntityTypeConfiguration<TBEnderecosColetaEventual>
    {
        public TBEnderecosColetaEventualMap()
        {
            // Primary Key
            this.HasKey(t => t.EnderecosColetaEventualID);

            // Properties
            this.Property(t => t.nmSolicitante)
                .HasMaxLength(255);

            this.Property(t => t.Telefone)
                .HasMaxLength(25);

            this.Property(t => t.EnderecoColeta)
                .HasMaxLength(255);

            this.Property(t => t.ItensColeta)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBEnderecosColetaEventual");
            this.Property(t => t.EnderecosColetaEventualID).HasColumnName("EnderecosColetaEventualID");
            this.Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            this.Property(t => t.nmSolicitante).HasColumnName("nmSolicitante");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.EnderecoColeta).HasColumnName("EnderecoColeta");
            this.Property(t => t.ItensColeta).HasColumnName("ItensColeta");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasRequired(t => t.TBColetaEventual)
                .WithMany(t => t.TBEnderecosColetaEventuals)
                .HasForeignKey(d => d.ColetaEventualID);

        }
    }
}
