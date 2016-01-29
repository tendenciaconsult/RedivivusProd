using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEquipamentoLimpezaExecutadaHistorico
    {
        public int EquipamentoLimpezaExecutadaHistorico { get; set; }
        public Nullable<int> EquipamentoLimpezaExecutadaID { get; set; }
        public string nmTipoEquipamento { get; set; }
        public Nullable<int> Quantidade { get; set; }
        public bool bAtivo { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserID { get; set; }
    }
}
