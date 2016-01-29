using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEnderecosColetaEventualHistoricoMap : EntityTypeConfiguration<TBEnderecosColetaEventualHistorico>
    {
        public TBEnderecosColetaEventualHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.EnderecosColetaEventualHistoricoID);

            // Properties
            Property(t => t.nmSolicitante)
                .HasMaxLength(255);

            Property(t => t.Telefone)
                .HasMaxLength(25);

            Property(t => t.EnderecoColeta)
                .HasMaxLength(255);

            Property(t => t.ItensColeta)
                .HasMaxLength(255);

            Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBEnderecosColetaEventualHistorico");
            Property(t => t.EnderecosColetaEventualHistoricoID).HasColumnName("EnderecosColetaEventualHistoricoID");
            Property(t => t.EnderecosColetaEventualID).HasColumnName("EnderecosColetaEventualID");
            Property(t => t.nmSolicitante).HasColumnName("nmSolicitante");
            Property(t => t.Telefone).HasColumnName("Telefone");
            Property(t => t.EnderecoColeta).HasColumnName("EnderecoColeta");
            Property(t => t.ItensColeta).HasColumnName("ItensColeta");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
        }
    }
}