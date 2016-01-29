using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduosColetadosItem
    {
        public int ResiduosColetadosItemID { get; set; }
        public int ResiduosColetadosID { get; set; }
        public int ResiduoClassificadoID { get; set; }
        public bool emLitros { get; set; }
        public double qtResiduo { get; set; }
        public virtual TBResiduoClassificado TBResiduoClassificado { get; set; }
        public virtual TBResiduosColetado TBResiduosColetado { get; set; }
    }
}
