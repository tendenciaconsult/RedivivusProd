using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBLimpezaEventualHistorico
    {
        public int LimpezaEventualHistoricoID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public Nullable<int> PrestadoraServicosID { get; set; }
        public Nullable<int> RegiaoAdministrativaID { get; set; }
        public Nullable<int> EnderecoBairroID { get; set; }
        public Nullable<System.DateTime> dtInicio { get; set; }
        public Nullable<System.DateTime> dtFim { get; set; }
        public Nullable<int> qtTintasUtilizados { get; set; }
        public Nullable<int> EnderecoLogradouroID { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public string nmOutroLogradouro { get; set; }
        public string nmProgramacao { get; set; }
        public Nullable<int> qtGaris { get; set; }
        public System.DateTime dtAlteracao { get; set; }
        public string userID { get; set; }
        public Nullable<int> TipoProgramacao { get; set; }
        public Nullable<bool> bServicoOrdinario { get; set; }
        public Nullable<bool> bFeiraLivre { get; set; }
        public string nmTipoProgramacao { get; set; }
    }
}
