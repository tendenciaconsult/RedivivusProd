using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetUserConfig : EntityTypeConfiguration<AspNetUser>
    {
        public AspNetUserConfig()
        {
            Ignore(x => x.CurrentClientId);

            /*
            this.HasMany<AspNetFuncao>(t => t.Funcoes)
                .WithMany(t => t.Usuarios)
                .Map(m =>
                {
                    m.ToTable("SimirFuncaoUser");
                    m.MapLeftKey("SimirFuncaoRefId");
                    m.MapRightKey("SimirUserRefId");
                });
             */

            //*
            HasMany(x => x.Perfis).WithMany().Map(cs =>
            {
                cs.MapLeftKey("AspNetUserRefId");
                cs.MapRightKey("AspNetPerfilRefId");
                cs.ToTable("AspNetUserPerfil");
            });

            //* */

            HasMany(x => x.Clients)
                .WithOptional()
                .HasForeignKey(y => y.SimirUser_Id);

            HasOptional(x => x.TBEmpresa)
                .WithMany()
                .HasForeignKey(d => d.EmpresaID);
        }
    }
}