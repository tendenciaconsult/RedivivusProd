using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBEnderecosColetaEventualHistoricoMap : EntityTypeConfiguration<TBEnderecosColetaEventualHistorico>
    {
        public TBEnderecosColetaEventualHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.EnderecosColetaEventualHistoricoID);

            // Properties
            this.Property(t => t.nmSolicitante)
                .HasMaxLength(255);

            this.Property(t => t.Telefone)
                .HasMaxLength(25);

            this.Property(t => t.EnderecoColeta)
                .HasMaxLength(255);

            this.Property(t => t.ItensColeta)
                .HasMaxLength(255);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBEnderecosColetaEventualHistorico");
            this.Property(t => t.EnderecosColetaEventualHistoricoID).HasColumnName("EnderecosColetaEventualHistoricoID");
            this.Property(t => t.EnderecosColetaEventualID).HasColumnName("EnderecosColetaEventualID");
            this.Property(t => t.nmSolicitante).HasColumnName("nmSolicitante");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.EnderecoColeta).HasColumnName("EnderecoColeta");
            this.Property(t => t.ItensColeta).HasColumnName("ItensColeta");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
        }
    }
}
