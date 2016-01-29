using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBDestinacaoRejeito
    {
        public TBDestinacaoRejeito()
        {
            this.TBRejeitosVinculados = new List<TBRejeitosVinculado>();
        }

        public int DestinacaoRejeitoID { get; set; }
        public Nullable<int> EmpresaID { get; set; }
        public System.DateTime dtDataRegistro { get; set; }
        public string CNPJDestinadoraFinal { get; set; }
        public string nmRazaoSocialDestinadoraFinal { get; set; }
        public double qtRejeitoVinculado { get; set; }
        public string CNPJTransportadora { get; set; }
        public string nmRazaoSocialTransportadora { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
        public virtual ICollection<TBRejeitosVinculado> TBRejeitosVinculados { get; set; }
    }
}
