using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.Practices.ServiceLocation;
using Simir.Domain.Entities;
using Simir.Infra.Data.EntityConfig;
using Simir.Infra.Data.Repositories;

namespace Simir.Infra.Data.Context
{
    public class SimirContext : BaseDbContext
    {
        public SimirContext()
            : base("connectionSimir")
        {
        }

        public DbSet<AspNetClient> SimirClients { get; set; }
        public DbSet<AspNetClaims> SimirClaims { get; set; }
        //public DbSet<AspNetFuncao> SimirFuncoes { get; set; }

        public DbSet<TBLogEvento> LogEventos { get; set; }
        /*
        public DbSet<SimirController> SimirControllers { get; set; }
        public DbSet<SimirFuncao> SimirFuncaos { get; set; }
        public DbSet<SimirModulo> SimirModuloes { get; set; }
        public DbSet<SimirPerfil> SimirPerfils { get; set; }
         */
        public DbSet<TBResiduosDestinadorRejeito> TBDestinacaoRejeitoes { get; set; }
        public DbSet<TBDisposicaoFinalResiduo> TBDisposicaoFinalResiduos { get; set; }
        public DbSet<TBEmpresa> TBEmpresas { get; set; }
        public DbSet<TBEndereco> TBEnderecoes { get; set; }
        public DbSet<TBEnderecoBairro> TBEnderecoBairroes { get; set; }
        public DbSet<TBEnderecoCidade> TBEnderecoCidades { get; set; }
        public DbSet<TBEnderecoEstado> TBEnderecoEstadoes { get; set; }
        public DbSet<TBEnderecoLogradouro> TBEnderecoLogradouroes { get; set; }
        public DbSet<TBFuncoesEmpresa> TBFuncoesEmpresas { get; set; }
        public DbSet<TBLicencaOperacao> TBLicencaOperacaos { get; set; }
        public DbSet<TBPorteEmpresa> TBPorteEmpresas { get; set; }
        public DbSet<TBPrefeitura> TBPrefeituras { get; set; }
        public DbSet<TBRamoEmpresa> TBRamoEmpresas { get; set; }
        public DbSet<TBResiduo> TBResiduos { get; set; }
        public DbSet<TBResiduosColetado> TBResiduosColetados { get; set; }
        public DbSet<TBResiduosDestinadore> TBResiduosDestinadores { get; set; }
        public DbSet<TBResiduosGerados> TBResiduosGerados { get; set; }
        public DbSet<TBResiduosTratado> TBResiduosTratados { get; set; }
        public DbSet<TBResiduoVinculado> TBResiduoVinculadoes { get; set; }

        public static SimirContext Create()
        {
            var context = new SimirContext();
            return context;
        }

        public static SimirContext GetContext()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<SimirContext>>()
                as ContextManager<SimirContext>;

            return contextManager.GetContextConcreto();
            //return contextManager.GetContext();
            //return ServiceLocator.Current.GetInstance<SimirContext>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            modelBuilder.Configurations.Add(new AspNetClientConfig());
            modelBuilder.Configurations.Add(new AspNetClaimsConfig());

            modelBuilder.Configurations.Add(new AspNetPerfilConfig());
            modelBuilder.Configurations.Add(new AspNetModuloConfig());
            modelBuilder.Configurations.Add(new AspNetModuloPaiConfig());

            modelBuilder.Configurations.Add(new AspNetActionConfig());
            modelBuilder.Configurations.Add(new AspNetControllerConfig());

            modelBuilder.Configurations.Add(new AspNetUserConfig());

            modelBuilder.Configurations.Add(new TBLogEventoMap());

            modelBuilder.Configurations.Add(new TBResiduosDestinadorRejeitoMap());
            modelBuilder.Configurations.Add(new TBDisposicaoFinalResiduoMap());
            modelBuilder.Configurations.Add(new TBEmpresaMap());
            modelBuilder.Configurations.Add(new TBEnderecoMap());
            modelBuilder.Configurations.Add(new TBEnderecoBairroMap());
            modelBuilder.Configurations.Add(new TBEnderecoCidadeMap());
            modelBuilder.Configurations.Add(new TBEnderecoEstadoMap());
            modelBuilder.Configurations.Add(new TBEnderecoLogradouroMap());
            modelBuilder.Configurations.Add(new TBFuncoesEmpresaMap());
            modelBuilder.Configurations.Add(new TBLicencaOperacaoMap());
            modelBuilder.Configurations.Add(new TBPorteEmpresaMap());
            modelBuilder.Configurations.Add(new TBPrefeituraMap());
            modelBuilder.Configurations.Add(new TBRamoEmpresaMap());

            modelBuilder.Configurations.Add(new TBResiduosColetadoMap());
            modelBuilder.Configurations.Add(new TBResiduosColetadoItemMap());
            modelBuilder.Configurations.Add(new TBResiduosDestinadoreMap());
            modelBuilder.Configurations.Add(new TBResiduosDestinadoreItemMap());
            modelBuilder.Configurations.Add(new TBResiduosGeradoMap());
            modelBuilder.Configurations.Add(new TBResiduosGeradoItemMap());
            modelBuilder.Configurations.Add(new TBResiduosTratadoMap());
            modelBuilder.Configurations.Add(new TBResiduoVinculadoMap());


            modelBuilder.Configurations.Add(new TBArquivoMap());
            modelBuilder.Configurations.Add(new TBGeradorMtrMap());

            modelBuilder.Configurations.Add(new TBUsuarioMap());
            modelBuilder.Configurations.Add(new TBUsuario_HistoricoMap());

            modelBuilder.Configurations.Add(new TBPrefeitura_HistoricoMap());

            modelBuilder.Configurations.Add(new TBSecretariaMap());
            modelBuilder.Configurations.Add(new TBSecretariasResponsabilidadeMap());
            modelBuilder.Configurations.Add(new TBResponsabilidadeMap());
            modelBuilder.Configurations.Add(new TBSecretaria_HistoricoMap());
            modelBuilder.Configurations.Add(new TBSecretariasResponsabilidade_HisctoricoMap());

            modelBuilder.Configurations.Add(new TBLimpezaOrdinariaMap());
            modelBuilder.Configurations.Add(new TBLimpezaOrdinariaHistoryMap());

            modelBuilder.Configurations.Add(new TBLimpezaEventualMap());
            modelBuilder.Configurations.Add(new TBLimpezaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBEquipamentoLimpezaEventualMap());
            modelBuilder.Configurations.Add(new TBEquipamentoLimpezaEventualHistoricoMap());

            modelBuilder.Configurations.Add(new TBLimpezaExecutadaMap());
            modelBuilder.Configurations.Add(new TBLimpezaExecutadaHistoricoMap());
            modelBuilder.Configurations.Add(new TBEquipamentoLimpezaExecutadaMap());
            modelBuilder.Configurations.Add(new TBEquipamentoLimpezaExecutadaHistoricoMap());

            modelBuilder.Configurations.Add(new TBRegiaoAdministrativaMap());
            modelBuilder.Configurations.Add(new TBRegiaoAdministrativaHistoricoMap());
            modelBuilder.Configurations.Add(new TBRegiaoAdministrativaLogradouroMap());
            modelBuilder.Configurations.Add(new TBRegiaoAdministrativaLogradouroHistoricoMap());

            modelBuilder.Configurations.Add(new TBColetaOrdinariaMap());
            modelBuilder.Configurations.Add(new TBColetaOrdinariaHistoricoMap());
            modelBuilder.Configurations.Add(new TBEquipamentoColetaOrdinariaMap());
            modelBuilder.Configurations.Add(new TBEquipamentoColetaOrdinariaHistoricoMap());

            modelBuilder.Configurations.Add(new TBColetaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBColetaEventualMap());
            modelBuilder.Configurations.Add(new TBEnderecosColetaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBEnderecosColetaEventualMap());
            modelBuilder.Configurations.Add(new TBEquipamentoColetaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBEquipamentoColetaEventualMap());

            modelBuilder.Configurations.Add(new TBColetaExecutadaDetalhadaHistoricoMap());
            modelBuilder.Configurations.Add(new TBColetaExecutadaDetalhadaMap());
            modelBuilder.Configurations.Add(new TBColetaExecutadaHistoricoMap());
            modelBuilder.Configurations.Add(new TBColetaExecutadaMap());

            modelBuilder.Configurations.Add(new TBPrestadoraServicoMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicosEquipamentoMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicosEquipamentosHistoricoMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicosHistoricoMap());

            modelBuilder.Configurations.Add(new TBRotaMap());
            modelBuilder.Configurations.Add(new TBRotasDescricaoMap());
            modelBuilder.Configurations.Add(new TBRotasDescricaoHistoricoMap());
            modelBuilder.Configurations.Add(new TBRotasHistoricoMap());

            modelBuilder.Configurations.Add(new TBPrestadoraServicosEquipamentoPodaMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicosVarredeiraMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicosCaminhaoMap());

            modelBuilder.Configurations.Add(new TBFeiraLivreMap());
            modelBuilder.Configurations.Add(new TBFeiraLivreHistoricoMap());

            modelBuilder.Configurations.Add(new TBResiduoClasseMap());
            modelBuilder.Configurations.Add(new TBResiduoMap());
            modelBuilder.Configurations.Add(new TBResiduoAtividadeMap());
            modelBuilder.Configurations.Add(new TBResiduoListaMap());
            modelBuilder.Configurations.Add(new TBResiduoClassificadoMap());

            modelBuilder.Configurations.Add(new TBTransbordoMap());
            modelBuilder.Configurations.Add(new TBAterroMap());
            modelBuilder.Configurations.Add(new TBTransbordoHistoricoMap());
            modelBuilder.Configurations.Add(new TBAterroHistoricoMap());

            modelBuilder.Configurations.Add(new TBFaleConoscoMap());

            modelBuilder.Configurations.Add(new TBContratoMap());
            modelBuilder.Configurations.Add(new TBContratoHistoricoMap());
            modelBuilder.Configurations.Add(new TBServicoMap());

            modelBuilder.Configurations.Add(new TBServicoFuncaoTituloMap());
            modelBuilder.Configurations.Add(new TBServicoFuncaoSubtituloMap());
            modelBuilder.Configurations.Add(new TBServicoFuncionarioMap());


            modelBuilder.Configurations.Add(new TBContratoVeiculoMap());
            modelBuilder.Configurations.Add(new TBContratoEquipamentoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}