using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEquipamentoColetaEventual
    {
        public int EquipamentoColetaEventualID { get; set; }
        public int ColetaEventualID { get; set; }
        public string nmEquipamento { get; set; }
        public Nullable<int> qtEquipamento { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBColetaEventual TBColetaEventual { get; set; }
    }
}
