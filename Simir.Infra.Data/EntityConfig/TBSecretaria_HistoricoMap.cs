using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBSecretaria_HistoricoMap : EntityTypeConfiguration<TBSecretaria_Historico>
    {
        public TBSecretaria_HistoricoMap()
        {
            // Primary Key
            HasKey(t => t.Secretaria_HistoricoID);

            // Properties
            Property(t => t.nmSecretaria)
                .HasMaxLength(255);

            Property(t => t.nmSecretario)
                .HasMaxLength(255);

            Property(t => t.Site)
                .HasMaxLength(255);

            Property(t => t.Telefone1)
                .HasMaxLength(255);

            Property(t => t.Telefone2)
                .HasMaxLength(255);

            Property(t => t.Email)
                .HasMaxLength(255);
        }
    }
}