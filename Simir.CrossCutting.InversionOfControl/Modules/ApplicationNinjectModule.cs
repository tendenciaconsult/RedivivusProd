using Ninject.Modules;
using Simir.Application;
using Simir.Application.Interfaces;

namespace Simir.CrossCutting.InversionOfControl.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IAppServiceBase<>)).To(typeof (AppServiceBase<>));

            Bind<IPerfilApp>().To<PerfilApp>();
            Bind<IFuncaoApp>().To<FuncaoApp>();
            Bind<IUsuarioApp>().To<UsuarioApp>();
            Bind<IEnderecoApp>().To<EnderecoApp>();
            Bind<IEmpresaApp>().To<EmpresaApp>();
            Bind<IResiduoApp>().To<ResiduoApp>();
            Bind<IGeradorApp>().To<GeradorApp>();
            Bind<IPrefeituraApp>().To<PrefeituraApp>();
            Bind<ISecretariaApp>().To<SecretariaApp>();
            Bind<IRegiaoAdministrativaApp>().To<RegiaoAdministrativaApp>();
            Bind<ILimpezaOrdinariaApp>().To<LimpezaOrdinariaApp>();
            Bind<ILimpezaEventualApp>().To<LimpezaEventualApp>();
            Bind<ILimpezaConsultaApp>().To<LimpezaConsultaApp>();

            Bind<ILimpezaExecutadaApp>().To<LimpezaExecutadaApp>();
            Bind<IPrestadoraServicoApp>().To<PrestadoraServicoApp>();

            Bind<IColetaOrdinariaApp>().To<ColetaOrdinariaApp>();
            Bind<IRotasApp>().To<RotasApp>();

            Bind<IFeiraLivreApp>().To<FeiraLivreApp>();

            Bind<IColetaEventualApp>().To<ColetaEventualApp>();
            Bind<IColetaExecutadaApp>().To<ColetaExecutadaApp>();
            Bind<IColetaConsultaApp>().To<ColetaConsultaApp>();

            Bind<IGrupoAcessoApp>().To<GrupoAcessoApp>();

            Bind<IControleFiscalizacaoApp>().To<ControleFiscalizacaoApp>();

            Bind<IColetaTransporteApp>().To<ColetaTransporteApp>();

            Bind<IDestinadorApp>().To<DestinadorApp>();

            Bind<IDisposicaoFinalAPP>().To<DisposicaoFinalAPP>();

            Bind<IFaleConoscoApp>().To<FaleConoscoApp>();


            Bind<IAterroApp>().To<AterroApp>();

            Bind<ITransbordoApp>().To<TransbordoApp>();
            Bind<IContratoApp>().To<ContratoApp>();
        }
    }
}