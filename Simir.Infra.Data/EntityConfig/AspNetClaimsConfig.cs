using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetClaimsConfig : EntityTypeConfiguration<AspNetClaims>
    {
        public AspNetClaimsConfig()
        {
            ToTable("AspNetClaims");
            HasKey(p => p.AspNetClaimsId);
        }
    }
}