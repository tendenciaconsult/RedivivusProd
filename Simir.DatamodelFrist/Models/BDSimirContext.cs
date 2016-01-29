using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Simir.DatamodelFrist.Models.Mapping;

namespace Simir.DatamodelFrist.Models
{
    public partial class BDSimirContext : DbContext
    {
        static BDSimirContext()
        {
            Database.SetInitializer<BDSimirContext>(null);
        }

        public BDSimirContext()
            : base("Name=BDSimirContext")
        {
        }

        public DbSet<AspNetClaim> AspNetClaims { get; set; }
        public DbSet<AspNetClient> AspNetClients { get; set; }
        public DbSet<AspNetController> AspNetControllers { get; set; }
        public DbSet<AspNetModulo> AspNetModuloes { get; set; }
        public DbSet<AspNetPerfil> AspNetPerfils { get; set; }
        public DbSet<AspNetPermissao> AspNetPermissaos { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetTipoPermissao> AspNetTipoPermissaos { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<TBArquivo> TBArquivoes { get; set; }
        public DbSet<TBClassificacaoResiduo> TBClassificacaoResiduos { get; set; }
        public DbSet<TBColetaEventual> TBColetaEventuals { get; set; }
        public DbSet<TBColetaEventualHistorico> TBColetaEventualHistoricoes { get; set; }
        public DbSet<TBColetaExecutada> TBColetaExecutadas { get; set; }
        public DbSet<TBColetaExecutadaDetalhada> TBColetaExecutadaDetalhadas { get; set; }
        public DbSet<TBColetaExecutadaDetalhadaHistorico> TBColetaExecutadaDetalhadaHistoricoes { get; set; }
        public DbSet<TBColetaExecutadaHistorico> TBColetaExecutadaHistoricoes { get; set; }
        public DbSet<TBColetaOrdinaria> TBColetaOrdinarias { get; set; }
        public DbSet<TBColetaOrdinariaHistorico> TBColetaOrdinariaHistoricoes { get; set; }
        public DbSet<TBDestinacaoRejeito> TBDestinacaoRejeitoes { get; set; }
        public DbSet<TBDisposicaoFinalResiduo> TBDisposicaoFinalResiduos { get; set; }
        public DbSet<TBEmpresa> TBEmpresas { get; set; }
        public DbSet<TBEndereco> TBEnderecoes { get; set; }
        public DbSet<TBEnderecoBairro> TBEnderecoBairroes { get; set; }
        public DbSet<TBEnderecoCidade> TBEnderecoCidades { get; set; }
        public DbSet<TBEnderecoEstado> TBEnderecoEstadoes { get; set; }
        public DbSet<TBEnderecoLogradouro> TBEnderecoLogradouroes { get; set; }
        public DbSet<TBEnderecosColetaEventual> TBEnderecosColetaEventuals { get; set; }
        public DbSet<TBEnderecosColetaEventualHistorico> TBEnderecosColetaEventualHistoricoes { get; set; }
        public DbSet<TBEquipamentoColetaEventual> TBEquipamentoColetaEventuals { get; set; }
        public DbSet<TBEquipamentoColetaEventualHistorico> TBEquipamentoColetaEventualHistoricoes { get; set; }
        public DbSet<TBEquipamentoColetaOrdinaria> TBEquipamentoColetaOrdinarias { get; set; }
        public DbSet<TBEquipamentoColetaOrdinariaHistorico> TBEquipamentoColetaOrdinariaHistoricoes { get; set; }
        public DbSet<TBEquipamentoLimpezaEventual> TBEquipamentoLimpezaEventuals { get; set; }
        public DbSet<TBEquipamentoLimpezaEventualHistorico> TBEquipamentoLimpezaEventualHistoricoes { get; set; }
        public DbSet<TBEquipamentoLimpezaExecutada> TBEquipamentoLimpezaExecutadas { get; set; }
        public DbSet<TBEquipamentoLimpezaExecutadaHistorico> TBEquipamentoLimpezaExecutadaHistoricoes { get; set; }
        public DbSet<TBFaleConosco> TBFaleConoscoes { get; set; }
        public DbSet<TBFeiraLivre> TBFeiraLivres { get; set; }
        public DbSet<TBFeiraLivreHistorico> TBFeiraLivreHistoricoes { get; set; }
        public DbSet<TBLicencaOperacao> TBLicencaOperacaos { get; set; }
        public DbSet<TBLimpezaEventual> TBLimpezaEventuals { get; set; }
        public DbSet<TBLimpezaEventualHistorico> TBLimpezaEventualHistoricoes { get; set; }
        public DbSet<TBLimpezaExecutada> TBLimpezaExecutadas { get; set; }
        public DbSet<TBLimpezaExecutadaHistorico> TBLimpezaExecutadaHistoricoes { get; set; }
        public DbSet<TBLimpezaOrdinaria> TBLimpezaOrdinarias { get; set; }
        public DbSet<TBLimpezaOrdinariaHistory> TBLimpezaOrdinariaHistories { get; set; }
        public DbSet<TBLogEvento> TBLogEventos { get; set; }
        public DbSet<TBPorteEmpresa> TBPorteEmpresas { get; set; }
        public DbSet<TBPrefeitura> TBPrefeituras { get; set; }
        public DbSet<TBPrefeitura_Historico> TBPrefeitura_Historico { get; set; }
        public DbSet<TBPrestadoraServico> TBPrestadoraServicos { get; set; }
        public DbSet<TBPrestadoraServicosEquipamento> TBPrestadoraServicosEquipamentos { get; set; }
        public DbSet<TBPrestadoraServicosEquipamentosHistorico> TBPrestadoraServicosEquipamentosHistoricoes { get; set; }
        public DbSet<TBPrestadoraServicosHistorico> TBPrestadoraServicosHistoricoes { get; set; }
        public DbSet<TBRamo> TBRamoes { get; set; }
        public DbSet<TBRamoEmpresa> TBRamoEmpresas { get; set; }
        public DbSet<TBRegiaoAdministrativa> TBRegiaoAdministrativas { get; set; }
        public DbSet<TBRegiaoAdministrativaHistorico> TBRegiaoAdministrativaHistoricoes { get; set; }
        public DbSet<TBRegiaoAdministrativaLogradouro> TBRegiaoAdministrativaLogradouroes { get; set; }
        public DbSet<TBRegiaoAdministrativaLogradouroHistorico> TBRegiaoAdministrativaLogradouroHistoricoes { get; set; }
        public DbSet<TBRejeitosVinculado> TBRejeitosVinculados { get; set; }
        public DbSet<TBResiduo> TBResiduos { get; set; }
        public DbSet<TBResiduoAtividade> TBResiduoAtividades { get; set; }
        public DbSet<TBResiduoClasse> TBResiduoClasses { get; set; }
        public DbSet<TBResiduoClassificado> TBResiduoClassificadoes { get; set; }
        public DbSet<TBResiduoLista> TBResiduoListas { get; set; }
        public DbSet<TBResiduosColetado> TBResiduosColetados { get; set; }
        public DbSet<TBResiduosColetadosItem> TBResiduosColetadosItems { get; set; }
        public DbSet<TBResiduosDestinadore> TBResiduosDestinadores { get; set; }
        public DbSet<TBResiduosDestinadoresItem> TBResiduosDestinadoresItems { get; set; }
        public DbSet<TBResiduosDestinadorRejeito> TBResiduosDestinadorRejeitoes { get; set; }
        public DbSet<TBResiduosGerado> TBResiduosGerados { get; set; }
        public DbSet<TBResiduosGeradosItem> TBResiduosGeradosItems { get; set; }
        public DbSet<TBResiduosTratado> TBResiduosTratados { get; set; }
        public DbSet<TBResponsabilidade> TBResponsabilidades { get; set; }
        public DbSet<TBRota> TBRotas { get; set; }
        public DbSet<TBRotasDescricao> TBRotasDescricaos { get; set; }
        public DbSet<TBRotasDescricaoHistorico> TBRotasDescricaoHistoricoes { get; set; }
        public DbSet<TBRotasHistorico> TBRotasHistoricoes { get; set; }
        public DbSet<TBSecretaria> TBSecretarias { get; set; }
        public DbSet<TBSecretaria_Historico> TBSecretaria_Historico { get; set; }
        public DbSet<TBSecretariasResponsabilidade> TBSecretariasResponsabilidades { get; set; }
        public DbSet<TBSecretariasResponsabilidades_Historico> TBSecretariasResponsabilidades_Historico { get; set; }
        public DbSet<TBTipoLista> TBTipoListas { get; set; }
        public DbSet<TBUsuario> TBUsuarios { get; set; }
        public DbSet<TBUsuario_Historico> TBUsuario_Historico { get; set; }
        public DbSet<V_Consult_Logradouro_Desv_Reg_Adm> V_Consult_Logradouro_Desv_Reg_Adm { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetClaimMap());
            modelBuilder.Configurations.Add(new AspNetClientMap());
            modelBuilder.Configurations.Add(new AspNetControllerMap());
            modelBuilder.Configurations.Add(new AspNetModuloMap());
            modelBuilder.Configurations.Add(new AspNetPerfilMap());
            modelBuilder.Configurations.Add(new AspNetPermissaoMap());
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetTipoPermissaoMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new TBArquivoMap());
            modelBuilder.Configurations.Add(new TBClassificacaoResiduoMap());
            modelBuilder.Configurations.Add(new TBColetaEventualMap());
            modelBuilder.Configurations.Add(new TBColetaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBColetaExecutadaMap());
            modelBuilder.Configurations.Add(new TBColetaExecutadaDetalhadaMap());
            modelBuilder.Configurations.Add(new TBColetaExecutadaDetalhadaHistoricoMap());
            modelBuilder.Configurations.Add(new TBColetaExecutadaHistoricoMap());
            modelBuilder.Configurations.Add(new TBColetaOrdinariaMap());
            modelBuilder.Configurations.Add(new TBColetaOrdinariaHistoricoMap());
            modelBuilder.Configurations.Add(new TBDestinacaoRejeitoMap());
            modelBuilder.Configurations.Add(new TBDisposicaoFinalResiduoMap());
            modelBuilder.Configurations.Add(new TBEmpresaMap());
            modelBuilder.Configurations.Add(new TBEnderecoMap());
            modelBuilder.Configurations.Add(new TBEnderecoBairroMap());
            modelBuilder.Configurations.Add(new TBEnderecoCidadeMap());
            modelBuilder.Configurations.Add(new TBEnderecoEstadoMap());
            modelBuilder.Configurations.Add(new TBEnderecoLogradouroMap());
            modelBuilder.Configurations.Add(new TBEnderecosColetaEventualMap());
            modelBuilder.Configurations.Add(new TBEnderecosColetaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBEquipamentoColetaEventualMap());
            modelBuilder.Configurations.Add(new TBEquipamentoColetaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBEquipamentoColetaOrdinariaMap());
            modelBuilder.Configurations.Add(new TBEquipamentoColetaOrdinariaHistoricoMap());
            modelBuilder.Configurations.Add(new TBEquipamentoLimpezaEventualMap());
            modelBuilder.Configurations.Add(new TBEquipamentoLimpezaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBEquipamentoLimpezaExecutadaMap());
            modelBuilder.Configurations.Add(new TBEquipamentoLimpezaExecutadaHistoricoMap());
            modelBuilder.Configurations.Add(new TBFaleConoscoMap());
            modelBuilder.Configurations.Add(new TBFeiraLivreMap());
            modelBuilder.Configurations.Add(new TBFeiraLivreHistoricoMap());
            modelBuilder.Configurations.Add(new TBLicencaOperacaoMap());
            modelBuilder.Configurations.Add(new TBLimpezaEventualMap());
            modelBuilder.Configurations.Add(new TBLimpezaEventualHistoricoMap());
            modelBuilder.Configurations.Add(new TBLimpezaExecutadaMap());
            modelBuilder.Configurations.Add(new TBLimpezaExecutadaHistoricoMap());
            modelBuilder.Configurations.Add(new TBLimpezaOrdinariaMap());
            modelBuilder.Configurations.Add(new TBLimpezaOrdinariaHistoryMap());
            modelBuilder.Configurations.Add(new TBLogEventoMap());
            modelBuilder.Configurations.Add(new TBPorteEmpresaMap());
            modelBuilder.Configurations.Add(new TBPrefeituraMap());
            modelBuilder.Configurations.Add(new TBPrefeitura_HistoricoMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicoMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicosEquipamentoMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicosEquipamentosHistoricoMap());
            modelBuilder.Configurations.Add(new TBPrestadoraServicosHistoricoMap());
            modelBuilder.Configurations.Add(new TBRamoMap());
            modelBuilder.Configurations.Add(new TBRamoEmpresaMap());
            modelBuilder.Configurations.Add(new TBRegiaoAdministrativaMap());
            modelBuilder.Configurations.Add(new TBRegiaoAdministrativaHistoricoMap());
            modelBuilder.Configurations.Add(new TBRegiaoAdministrativaLogradouroMap());
            modelBuilder.Configurations.Add(new TBRegiaoAdministrativaLogradouroHistoricoMap());
            modelBuilder.Configurations.Add(new TBRejeitosVinculadoMap());
            modelBuilder.Configurations.Add(new TBResiduoMap());
            modelBuilder.Configurations.Add(new TBResiduoAtividadeMap());
            modelBuilder.Configurations.Add(new TBResiduoClasseMap());
            modelBuilder.Configurations.Add(new TBResiduoClassificadoMap());
            modelBuilder.Configurations.Add(new TBResiduoListaMap());
            modelBuilder.Configurations.Add(new TBResiduosColetadoMap());
            modelBuilder.Configurations.Add(new TBResiduosColetadosItemMap());
            modelBuilder.Configurations.Add(new TBResiduosDestinadoreMap());
            modelBuilder.Configurations.Add(new TBResiduosDestinadoresItemMap());
            modelBuilder.Configurations.Add(new TBResiduosDestinadorRejeitoMap());
            modelBuilder.Configurations.Add(new TBResiduosGeradoMap());
            modelBuilder.Configurations.Add(new TBResiduosGeradosItemMap());
            modelBuilder.Configurations.Add(new TBResiduosTratadoMap());
            modelBuilder.Configurations.Add(new TBResponsabilidadeMap());
            modelBuilder.Configurations.Add(new TBRotaMap());
            modelBuilder.Configurations.Add(new TBRotasDescricaoMap());
            modelBuilder.Configurations.Add(new TBRotasDescricaoHistoricoMap());
            modelBuilder.Configurations.Add(new TBRotasHistoricoMap());
            modelBuilder.Configurations.Add(new TBSecretariaMap());
            modelBuilder.Configurations.Add(new TBSecretaria_HistoricoMap());
            modelBuilder.Configurations.Add(new TBSecretariasResponsabilidadeMap());
            modelBuilder.Configurations.Add(new TBSecretariasResponsabilidades_HistoricoMap());
            modelBuilder.Configurations.Add(new TBTipoListaMap());
            modelBuilder.Configurations.Add(new TBUsuarioMap());
            modelBuilder.Configurations.Add(new TBUsuario_HistoricoMap());
            modelBuilder.Configurations.Add(new V_Consult_Logradouro_Desv_Reg_AdmMap());
        }
    }
}
