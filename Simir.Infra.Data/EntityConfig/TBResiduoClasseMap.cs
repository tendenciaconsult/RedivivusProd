using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduoClasseMap : EntityTypeConfiguration<TBResiduoClasse>
    {
        public TBResiduoClasseMap()
        {
            // Primary Key
            HasKey(t => t.ResiduoClasseID);

            // Properties
            Property(t => t.nmResiduoClasse)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(800);
        }
    }
}