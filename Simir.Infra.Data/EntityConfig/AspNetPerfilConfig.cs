using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetPerfilConfig : EntityTypeConfiguration<AspNetPerfil>
    {
        public AspNetPerfilConfig()
        {
            ToTable("AspNetPerfil");
            HasKey(t => t.AspNetPerfilId);

            /*
            HasMany<AspNetModulo>(x => x.SimirModulos).WithMany().Map(cs =>
            {
                cs.MapLeftKey("AspNetPerfilRefId");
                cs.MapRightKey("AspNetModuloRefId");
                cs.ToTable("AspNetPerfilModulo");
            });
            */
        }
    }
}