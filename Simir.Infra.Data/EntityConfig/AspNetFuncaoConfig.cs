using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetFuncaoConfig : EntityTypeConfiguration<AspNetFuncao>
    {
        public AspNetFuncaoConfig()
        {
            ToTable("SimirFuncao");
            HasKey(t => t.AspNetFuncaoId);
            HasOptional(s => s.Perfil)
                .WithMany()
                .HasForeignKey(s => s.PerfilId);
        }
    }
}