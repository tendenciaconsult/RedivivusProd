using Ninject.Modules;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Repository.Common;
using Simir.Infra.Data.Repositories;
using Simir.Infra.Data.Repositories.Common;

namespace Simir.CrossCutting.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IRepositoryBase<>)).To(typeof (RepositoryBase<>));
            Bind(typeof (IRepositoryBaseDaPrefeitura<,>)).To(typeof (RepositoryBaseDaPrefeitura<,>));

            Bind<IAspNetFuncaoRepository>().To<AspNetFuncaoRepository>();


            /*
            Bind<ILocalidadeUfRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(LocalidadeUf)),
                typeof(ILocalidadeUfRepository)
                ));
            Bind<ILocalidadeDistritoRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(LocalidadeDistrito)),
                typeof(ILocalidadeDistritoRepository)
                ));
            */

            Bind<IAspNetPerfilRepository>().To<AspNetPerfilRepository>();
            Bind<IAspNetControllerRepository>().To<AspNetControllerRepository>();
            Bind<IAspNetActionRepository>().To<AspNetActionRepository>();


            Bind<IAspNetModuloRepository>().To<AspNetModuloRepository>();

            Bind<IEnderecoRepository>().To<EnderecoRepository>();

            Bind<IEnderecoEstadoRepository>().To<EnderecoEstadoRepository>();

            Bind<IEnderecoCidadeRepository>().To<EnderecoCidadeRepository>();

            Bind<IEnderecoBairroRepository>().To<EnderecoBairroRepository>();

            Bind<IEnderecoLogradouroRepository>().To<EnderecoLogradouroRepository>();

            Bind<IEmpresaRepository>().To<EmpresaRepository>();

            Bind<IRamoEmpresaRepository>().To<RamoEmpresaRepository>();

            Bind<IPorteEmpresaRepository>().To<PorteEmpresaRepository>();

            Bind<ILicencaOperacaoRepository>().To<LicencaOperacaoRepository>();

            Bind<IResiduoRepository>().To<ResiduoRepository>();
            //Bind<IResiduoClasseRepository>().To<ClassificacaoResidoRepository>();

            Bind<IResiduosGeradoRepository>().To<ResiduosGeradoRepository>();

            Bind<IGeradorMtrRepository>().To<GeradorMtrRepository>();


            Bind<IPrefeituraRepository>().To<PrefeituraRepository>();

            Bind<ISecretariaRepository>().To<SecretariaRepository>();

            Bind<IRegiaoAdministrativaLogradouroRepository>().To<RegiaoAdministrativaLogradouroRepository>();

            Bind<IRegiaoAdministrativaRepository>().To<RegioesAdministrativasRepository>();

            Bind<ISecretariaResponsabilidadesRepository>().To<SecretariaResponsabilidadesRepository>();

            Bind<ILimpezaOrdinariaRepository>().To<LimpezaOrdinariaRepository>();

            Bind<ILimpezaEventualRepository>().To<LimpezaEventualRepository>();

            Bind<IEquipamentoLimpezaExecutadaRepository>().To<EquipamentoLimpezaExecutadaRepository>();

            Bind<IEquipamentoLimpezaEventualRepository>().To<EquipamentoLimpezaEventualRepository>();

            Bind<ILimpezaExecutadaRepository>().To<LimpezaExecutadaRepository>();

            Bind<IPrestadoraServicoRepository>().To<PrestadoraServicoRepository>();

            Bind<IPrestadoraServicoEquipamentoRepository>().To<PrestadoraServicoEquipamentoRepository>();

            Bind<IFeiraLivreRepository>().To<FeiraLivreRepository>();

            Bind<IRepositoryProc>().To<RepositoryProc>();

            Bind<IContratoRepository>().To<ContratoRepository>();


            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IColetaOrdinariaRepository>().To<ColetaOrdinariaRepository>();
            Bind<IEquipamentoColetaOrdinariaRepository>().To<EquipamentoColetaOrdinariaRepository>();

            Bind<IColetaEventualRepository>().To<ColetaEventualRepository>();
            Bind<IEnderecosColetaEventualRepository>().To<EnderecosColetaEventualRepository>();
            Bind<IEquipamentoColetaEventualRepository>().To<EquipamentoColetaEventualRepository>();

            Bind<IColetaExecutadaRepository>().To<ColetaExecutadaRepository>();
            Bind<IColetaExecutadaDetalhadaRepository>().To<ColetaExecutadaDetalhadaRepository>();


            Bind<IRotasRepository>().To<RotaRepository>();
            Bind<IRotasDescricaoRepository>().To<RotasDescricaoRepository>();

            Bind<IAspNetPermissaoRepository>().To<AspNetPermissaoRepository>();

            Bind<IAterroRepository>().To<AterroRepository>();
            Bind<ITransbordoRepository>().To<TransbordoRepository>();

            Bind<IResiduosDestinadorRejeitoRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBResiduosDestinadorRejeito)),
                typeof(IResiduosDestinadorRejeitoRepository)
                ));

            Bind<IDisposicaoFinalRepository>().To<DisposicaoFinalRepository>();

            Bind<IFaleConoscoRepository>().To<FaleConoscoRepository>();

            Bind<IResponsabilidadesRepository>().To(Helper.DynamicImplementation(
                typeof (RepositoryBase<>).MakeGenericType(typeof (TBResponsabilidade)),
                typeof (IResponsabilidadesRepository)
                ));

            Bind<ILogEventoRepository>().To(Helper.DynamicImplementation(
                typeof (RepositoryBase<>).MakeGenericType(typeof (TBLogEvento)),
                typeof (ILogEventoRepository)
                ));

            Bind<IResiduoAtividadeRepository>().To(Helper.DynamicImplementation(
                typeof (RepositoryBase<>).MakeGenericType(typeof (TBResiduoAtividade)),
                typeof (IResiduoAtividadeRepository)
                ));

            Bind<IResiduoListaRepository>().To(Helper.DynamicImplementation(
                typeof (RepositoryBase<>).MakeGenericType(typeof (TBResiduoLista)),
                typeof (IResiduoListaRepository)
                ));

            Bind<IResiduoClasseRepository>().To(Helper.DynamicImplementation(
                typeof (RepositoryBase<>).MakeGenericType(typeof (TBResiduoClasse)),
                typeof (IResiduoClasseRepository)
                ));

            Bind<IResiduoClassificadoRepository>().To(Helper.DynamicImplementation(
                typeof (RepositoryBase<>).MakeGenericType(typeof (TBResiduoClassificado)),
                typeof (IResiduoClassificadoRepository)
                ));

            Bind<IResiduosGeradoItemRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBResiduosGeradoItem)),
                typeof(IResiduosGeradoItemRepository)
                ));

            Bind<IResiduosColetadoRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBResiduosColetado)),
                typeof(IResiduosColetadoRepository)
                ));

            Bind<IResiduosColetadoItemRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBResiduosColetadoItem)),
                typeof(IResiduosColetadoItemRepository)
                ));

            Bind<IDestinadorRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBResiduosDestinadore)),
                typeof(IDestinadorRepository)
                ));
            Bind<IDestinadorItemRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBResiduosDestinadoreItem)),
                typeof(IDestinadorItemRepository)
                ));

            Bind<IResiduosDestinadorTratadoRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBResiduosTratado)),
                typeof(IResiduosDestinadorTratadoRepository)
                ));

            Bind<IServicoRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBServico)),
                typeof(IServicoRepository)
                ));

            Bind<IServicoFuncionarioRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBServicoFuncionario)),
                typeof(IServicoFuncionarioRepository)
                ));

            Bind<IServicoFuncaoTituloRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBServicoFuncaoTitulo)),
                typeof(IServicoFuncaoTituloRepository)
                ));
            Bind<IServicoFuncaoSubtituloRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBServicoFuncaoSubtitulo)),
                typeof(IServicoFuncaoSubtituloRepository)
                ));

            Bind<IContratoVeiculoRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBContratoVeiculo)),
                typeof(IContratoVeiculoRepository)
                ));

            Bind<IContratoEquipamentoRepository>().To(Helper.DynamicImplementation(
                typeof(RepositoryBase<>).MakeGenericType(typeof(TBContratoEquipamento)),
                typeof(IContratoEquipamentoRepository)
                ));


        }
    }
}