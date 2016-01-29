using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetModuloPaiConfig : EntityTypeConfiguration<AspNetModuloPai>
    {
        public AspNetModuloPaiConfig()
        {
            HasMany(s => s.ModuloFilhos)
                .WithOptional(x => x.ModuloPai)
                .HasForeignKey(s => s.ModuloPaiId);
        }
    }
}