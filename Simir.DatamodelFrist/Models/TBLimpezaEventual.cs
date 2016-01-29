using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBLimpezaEventual
    {
        public int LimpezaEventualID { get; set; }
        public int PrefeituraID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public int RegiaoAdministrativaID { get; set; }
        public Nullable<int> EnderecoBairroID { get; set; }
        public Nullable<System.DateTime> dtInicio { get; set; }
        public Nullable<System.DateTime> dtFim { get; set; }
        public Nullable<int> qtTintasUtilizados { get; set; }
        public Nullable<int> EnderecoLogradouroID { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public string nmOutroLogradouro { get; set; }
        public string nmProgramacao { get; set; }
        public Nullable<int> qtGaris { get; set; }
        public Nullable<int> TipoProgramacao { get; set; }
        public Nullable<bool> bServicoOrdinario { get; set; }
        public bool bFeiraLivre { get; set; }
        public string nmTipoProgramacao { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBLimpezaExecutada TBLimpezaExecutada { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
    }
}
