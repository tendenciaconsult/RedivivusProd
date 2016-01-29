using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEquipamentoLimpezaEventual
    {
        public int EquipamentoLimpezaEventualID { get; set; }
        public Nullable<int> LimpezaEventualID { get; set; }
        public string nmTipoEquipamento { get; set; }
        public Nullable<int> Quantidade { get; set; }
        public bool bAtivo { get; set; }
    }
}
