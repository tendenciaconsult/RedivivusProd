using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBEnderecosColetaEventualMap : EntityTypeConfiguration<TBEnderecosColetaEventual>
    {
        public TBEnderecosColetaEventualMap()
        {
            // Primary Key
            HasKey(t => t.EnderecosColetaEventualID);

            // Properties
            Property(t => t.nmSolicitante)
                .HasMaxLength(255);

            Property(t => t.Telefone)
                .HasMaxLength(25);

            Property(t => t.EnderecoColeta)
                .HasMaxLength(255);

            Property(t => t.ItensColeta)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBEnderecosColetaEventual");
            Property(t => t.EnderecosColetaEventualID).HasColumnName("EnderecosColetaEventualID");
            Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            Property(t => t.nmSolicitante).HasColumnName("nmSolicitante");
            Property(t => t.Telefone).HasColumnName("Telefone");
            Property(t => t.EnderecoColeta).HasColumnName("EnderecoColeta");
            Property(t => t.ItensColeta).HasColumnName("ItensColeta");
            Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            HasRequired(t => t.TBColetaEventual)
                .WithMany(t => t.TBEnderecosColetaEventuals)
                .HasForeignKey(d => d.ColetaEventualID);
        }
    }
}