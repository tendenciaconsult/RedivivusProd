namespace Simir.Domain.Entities
{
    public class TBLimpezaOrdinaria
    {
        public int LimpezaOrdinariaID { get; set; }
        public int PrefeituraID { get; set; }
        public int RegiaoAdministrativaID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public int? EnderecoBairroID { get; set; }
        public int? EnderecoLogradouroID { get; set; }
        public int? ExtensaoSargetas { get; set; }
        public bool bAtivo { get; set; }
        public int? FeiraLivreID { get; set; }
        public string nmOutroServico { get; set; }
        public int? TipoServico { get; set; }
        public bool bSegunda { get; set; }
        public int? qtVarricaoSegunda { get; set; }
        public bool bSegundaFiscalizado { get; set; }
        public bool bTerca { get; set; }
        public int? qtVarricaoTerca { get; set; }
        public bool bTercaFiscalizado { get; set; }
        public bool bQuarta { get; set; }
        public int? qtVarricaoQuarta { get; set; }
        public bool bQuartaFiscalizado { get; set; }
        public bool bQuinta { get; set; }
        public int? qtVarricaoQuinta { get; set; }
        public bool bQuintaFiscalizado { get; set; }
        public bool bSexta { get; set; }
        public int? qtVarricaoSexta { get; set; }
        public bool bSextaFiscalizado { get; set; }
        public bool bSabado { get; set; }
        public int? qtVarricaoSabado { get; set; }
        public bool bSabadoFiscalizado { get; set; }
        public bool bDomingo { get; set; }
        public int? qtVarricaoDomingo { get; set; }
        public bool bDomingoFiscalizado { get; set; }
        public int? qtGarisSegunda { get; set; }
        public int? qtGarisTerca { get; set; }
        public int? qtGarisQuarta { get; set; }
        public int? qtGarisQuinta { get; set; }
        public int? qtGarisSexta { get; set; }
        public int? qtGarisSabado { get; set; }
        public int? qtGarisDomingo { get; set; }
        public string nmProgramacao { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBFeiraLivre TBFeiraLivre { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
    }
}