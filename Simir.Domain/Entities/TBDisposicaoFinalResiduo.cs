using System;

namespace Simir.Domain.Entities
{
    public class TBDisposicaoFinalResiduo
    {
        public int DisposicaoFinalResiduoID { get; set; }
        public int EmpresaID { get; set; }
        public string CNPJTransportadora { get; set; }
        public string nmRazaoSocialTransportadora { get; set; }
        public DateTime dtRecebimento { get; set; }
        public double qtRejeito { get; set; }
        public bool bAterroControlado { get; set; }
        public DateTime dtMesReferencia { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
    }
}