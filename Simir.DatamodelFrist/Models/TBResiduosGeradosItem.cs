using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduosGeradosItem
    {
        public int ResiduosGeradosItemID { get; set; }
        public int ResiduosGeradosID { get; set; }
        public int ResiduoClassificadoID { get; set; }
        public bool emLitros { get; set; }
        public double qtResiduo { get; set; }
        public virtual TBResiduoClassificado TBResiduoClassificado { get; set; }
        public virtual TBResiduosGerado TBResiduosGerado { get; set; }
    }
}
