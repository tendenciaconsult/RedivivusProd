using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduosDestinadorRejeito
    {
        public int ResiduosDestinadorRejeitoID { get; set; }
        public int EmpresaID { get; set; }
        public string CNPJDestinadoraFinal { get; set; }
        public string nmRazaoSocialDestinadoraFinal { get; set; }
        public double qtRejeitoVinculado { get; set; }
        public string CNPJTransportadora { get; set; }
        public string nmRazaoSocialTransportadora { get; set; }
        public bool emLitros { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
    }
}
