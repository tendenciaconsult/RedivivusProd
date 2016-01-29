using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEquipamentoColetaOrdinaria
    {
        public int EquipamentoColetaOrdinariaID { get; set; }
        public int ColetaOrdinariaID { get; set; }
        public string nmEquipamento { get; set; }
        public Nullable<int> qtEquipamento { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBColetaOrdinaria TBColetaOrdinaria { get; set; }
    }
}
