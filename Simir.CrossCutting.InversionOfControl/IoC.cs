using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Simir.CrossCutting.InversionOfControl.Modules;

namespace Simir.CrossCutting.InversionOfControl
{
    public class IoC
    {
        public IoC()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        public IKernel Kernel { get; private set; }

        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule(),
                new InfrastructureNinjectModule(),
                new RepositoryNinjectModule(),
                new ApplicationNinjectModule(),
                new ServiceAgentNinjectModule()
                );
        }
    }
}