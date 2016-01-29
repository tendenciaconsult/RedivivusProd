using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduosDestinadoresItem
    {
        public int ResiduosDestinadoresItemID { get; set; }
        public int ResiduoClassificadoID { get; set; }
        public bool emLitros { get; set; }
        public double qtResiduo { get; set; }
        public Nullable<int> ResiduosDestinadoresID { get; set; }
        public virtual TBResiduoClassificado TBResiduoClassificado { get; set; }
        public virtual TBResiduosDestinadore TBResiduosDestinadore { get; set; }
    }
}
