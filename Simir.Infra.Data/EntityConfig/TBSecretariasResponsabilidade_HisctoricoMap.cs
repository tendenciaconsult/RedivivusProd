using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBSecretariasResponsabilidade_HisctoricoMap :
        EntityTypeConfiguration<TBSecretariasResponsabilidade_Historico>
    {
        public TBSecretariasResponsabilidade_HisctoricoMap()
        {
            // Primary Key
            HasKey(t => t.SecretariasResponsabilidades_HistoricoID);

            // Properties
            Property(t => t.nmOutros)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBSecretariasResponsabilidades_Historico");
        }
    }
}