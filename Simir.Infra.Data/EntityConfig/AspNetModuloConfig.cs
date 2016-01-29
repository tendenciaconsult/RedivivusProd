using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetModuloConfig : EntityTypeConfiguration<AspNetModulo>
    {
        public AspNetModuloConfig()
        {
            ToTable("AspNetModulo");
            HasKey(t => t.AspNetModuloId);
        }
    }
}