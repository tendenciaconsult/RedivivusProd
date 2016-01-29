using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRejeitosVinculado
    {
        public int RejeitosVinculadosID { get; set; }
        public Nullable<int> DestinacaoRejeitoID { get; set; }
        public Nullable<int> ResiduoID { get; set; }
        public double qtRejeitoVinculado { get; set; }
        public virtual TBDestinacaoRejeito TBDestinacaoRejeito { get; set; }
        public virtual TBResiduo TBResiduo { get; set; }
    }
}
