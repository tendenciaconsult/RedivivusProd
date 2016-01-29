using Ninject.Modules;
using Simir.Domain.Interfaces.Services;
using Simir.Domain.Services;

namespace Simir.CrossCutting.InversionOfControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IServiceBase<>)).To(typeof (ServiceBase<>));

            Bind<IAspNetFuncaoService>().To<AspNetFuncaoService>();

            Bind<IAspNetPerfilService>().To<AspNetPerfilService>();

            Bind<IEnderecoService>().To<EnderecoService>();
            Bind<IEmpresaService>().To<EmpresaService>();
            Bind<IResiduoService>().To<ResiduoService>();

            Bind<IGeradorService>().To<GeradorService>();
            Bind<IPrefeituraService>().To<PrefeituraService>();
            Bind<ISecretariaService>().To<SecretariaService>();
            Bind<IRegiaoAdministrativaService>().To<RegiaoAdministrativaService>();
            Bind<ILimpezaOrdinariaService>().To<LimpezaOrdinariaService>();

            Bind<ILimpezaEventualService>().To<LimpezaEventualService>();

            Bind<ILimpezaExecutadaService>().To<LimpezaExecutadaService>();
            Bind<IEquipamentoLimpezaExecutadaService>().To<EquipamentoLimpezaExecutadaService>();

            Bind<IEquipamentoLimpezaEventualService>().To<EquipamentoLimpezaEventualService>();

            Bind<IPrestadoraServicoService>().To<PrestadoraServicoService>();

            Bind<IUsuarioService>().To<UsuarioService>();

            Bind<IColetaOrdinariaService>().To<ColetaOrdinariaService>();
            Bind<IEquipamentoColetaOrdinariaService>().To<EquipamentoColetaOrdinariaService>();

            Bind<IRotaService>().To<RotaService>();
            Bind<IRotasDescricaoService>().To<RotasDescricaoService>();


            Bind<IFeiraLivreService>().To<FeiraLivreService>();

            Bind<IColetaEventualService>().To<ColetaEventualService>();
            Bind<IColetaExecutadaService>().To<ColetaExecutadaService>();
            Bind<IColetaExecutadaDetalhadaService>().To<ColetaExecutadaDetalhadaService>();
            Bind<IEnderecosColetaEventualService>().To<EnderecosColetaEventualService>();
            Bind<IEquipamentoColetaEventualService>().To<EquipamentoColetaEventualService>();

            Bind<IStoredProceduresService>().To<StoredProceduresService>();

            Bind<IAspNetPermissaoService>().To<AspNetPermissaoService>();

            Bind<IColetaTransporteService>().To<ColetaTransporteService>();

            Bind<IDestinadorService>().To<DestinadorService>();

            Bind<IDisposicaoFinalService>().To<DisposicaoFinalService>();

            Bind<IFaleConoscoService>().To<FaleConoscoService>();

            Bind<IDestinadorTratadoService>().To<DestinadorTratadoService>();
            Bind<IContratoService>().To<ContratoService>();

            Bind<IServicoService>().To<ServicoService>();

            Bind<IContratoFuncionarioService>().To<ContratoFuncionarioService>();

            Bind<IContratoEquipamentoService>().To<ContratoEquipamentoService>();
            Bind<IContratoVeiculoService>().To<ContratoVeiculoService>();


            Bind<IAterroService>().To<AterroService>();
            Bind<ITransbordoService>().To<TransbordoService>();
        }
    }
}