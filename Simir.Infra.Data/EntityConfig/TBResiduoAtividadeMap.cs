using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduoAtividadeMap : EntityTypeConfiguration<TBResiduoAtividade>
    {
        public TBResiduoAtividadeMap()
        {
            // Primary Key
            HasKey(t => t.ResiduoAtividadeID);

            // Properties
            Property(t => t.nmResiduoAtividade)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(800);
        }
    }
}