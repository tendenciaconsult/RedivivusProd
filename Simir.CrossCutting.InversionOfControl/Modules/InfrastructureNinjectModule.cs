using Ninject.Modules;
using Simir.Infra.Data.Context;
using Simir.Infra.Data.Repositories;

namespace Simir.CrossCutting.InversionOfControl.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<SimirContext>();
            Bind(typeof (IContextManager<>)).To(typeof (ContextManager<>));
            Bind(typeof (IUnitOfWork<>)).To((typeof (UnitOfWork<>)));
        }
    }
}