using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduoMap : EntityTypeConfiguration<TBResiduo>
    {
        public TBResiduoMap()
        {
            // Primary Key
            HasKey(t => t.ResiduoID);

            // Properties
            Property(t => t.nmResiduo)
                .IsRequired()
                .HasMaxLength(800);

            Property(t => t.Descricao)
                .HasMaxLength(800);
        }
    }
}