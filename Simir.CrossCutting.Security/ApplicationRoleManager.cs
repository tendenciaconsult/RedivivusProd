using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Simir.Infra.Data.Context;

namespace Simir.CrossCutting.Security
{
    /*
    public class ApplicationRoleManager : RoleManager<SimirFuncao>
    {
        public ApplicationRoleManager(IRoleStore<SimirFuncao, string> roleStore)
            : base(roleStore)
        {

        }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(
                new RoleStore<SimirFuncao>(context.Get<SimirContext>()));
        }


    }
    */
    // Configurando o RoleManager utilizado na aplicação.

    //*
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(
                new RoleStore<IdentityRole>(context.Get<SimirContext>()));
        }
    }

    //*/
}