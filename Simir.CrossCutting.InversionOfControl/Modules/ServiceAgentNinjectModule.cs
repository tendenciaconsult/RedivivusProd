using Redivivus.ServiceAgent.DataFileStorage;
using Ninject.Modules;
using Simir.Domain.Interfaces.ServiceAgents;
using Simir.ServiceAgent.Correio;

namespace Simir.CrossCutting.InversionOfControl.Modules
{
    public class ServiceAgentNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISvcConsultCepApi>().To<ServiceCorreio>();
            Bind<IArmazenamentoArquivo>().To<ArmazenamentoArquivoAzure>();
        }
    }
}