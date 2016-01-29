using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBLimpezaOrdinaria
    {
        public int LimpezaOrdinariaID { get; set; }
        public int PrefeituraID { get; set; }
        public int RegiaoAdministrativaID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public Nullable<int> EnderecoBairroID { get; set; }
        public Nullable<int> EnderecoLogradouroID { get; set; }
        public Nullable<int> ExtensaoSargetas { get; set; }
        public bool bAtivo { get; set; }
        public Nullable<int> FeiraLivreID { get; set; }
        public string nmOutroServico { get; set; }
        public Nullable<int> TipoServico { get; set; }
        public bool bSegunda { get; set; }
        public Nullable<int> qtVarricaoSegunda { get; set; }
        public bool bSegundaFiscalizado { get; set; }
        public bool bTerca { get; set; }
        public Nullable<int> qtVarricaoTerca { get; set; }
        public bool bTercaFiscalizado { get; set; }
        public bool bQuarta { get; set; }
        public Nullable<int> qtVarricaoQuarta { get; set; }
        public bool bQuartaFiscalizado { get; set; }
        public bool bQuinta { get; set; }
        public Nullable<int> qtVarricaoQuinta { get; set; }
        public bool bQuintaFiscalizado { get; set; }
        public bool bSexta { get; set; }
        public Nullable<int> qtVarricaoSexta { get; set; }
        public bool bSextaFiscalizado { get; set; }
        public bool bSabado { get; set; }
        public Nullable<int> qtVarricaoSabado { get; set; }
        public bool bSabadoFiscalizado { get; set; }
        public bool bDomingo { get; set; }
        public Nullable<int> qtVarricaoDomingo { get; set; }
        public bool bDomingoFiscalizado { get; set; }
        public Nullable<int> qtGarisSegunda { get; set; }
        public Nullable<int> qtGarisTerca { get; set; }
        public Nullable<int> qtGarisQuarta { get; set; }
        public Nullable<int> qtGarisQuinta { get; set; }
        public Nullable<int> qtGarisSexta { get; set; }
        public Nullable<int> qtGarisSabado { get; set; }
        public Nullable<int> qtGarisDomingo { get; set; }
        public string nmProgramacao { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBFeiraLivre TBFeiraLivre { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
    }
}
