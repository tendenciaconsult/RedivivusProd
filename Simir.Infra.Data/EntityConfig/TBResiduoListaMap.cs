using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduoListaMap : EntityTypeConfiguration<TBResiduoLista>
    {
        public TBResiduoListaMap()
        {
            // Primary Key
            HasKey(t => t.ResiduoListaID);

            // Properties
            Property(t => t.nmResiduoLista)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(800);
        }
    }
}