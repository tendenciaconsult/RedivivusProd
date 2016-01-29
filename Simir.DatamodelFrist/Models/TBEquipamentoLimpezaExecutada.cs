using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEquipamentoLimpezaExecutada
    {
        public int EquipamentoLimpezaExecutadaID { get; set; }
        public string nmTipoEquipamento { get; set; }
        public Nullable<int> Quantidade { get; set; }
        public bool bAtivo { get; set; }
        public int LimpezaExecutadaID { get; set; }
        public virtual TBLimpezaExecutada TBLimpezaExecutada { get; set; }
    }
}
