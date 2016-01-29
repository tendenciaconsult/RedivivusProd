using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetControllerConfig : EntityTypeConfiguration<AspNetController>
    {
        public AspNetControllerConfig()
        {
            ToTable("AspNetController");
            HasKey(t => t.AspNetControllerId);
        }
    }
}