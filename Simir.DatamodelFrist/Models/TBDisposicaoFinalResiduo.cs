using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBDisposicaoFinalResiduo
    {
        public int DisposicaoFinalResiduoID { get; set; }
        public int EmpresaID { get; set; }
        public string CNPJTransportadora { get; set; }
        public string nmRazaoSocialTransportadora { get; set; }
        public System.DateTime dtRecebimento { get; set; }
        public double qtRejeito { get; set; }
        public bool bAterroControlado { get; set; }
        public string CNPJTransbordo { get; set; }
        public System.DateTime dtMesReferencia { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
    }
}
