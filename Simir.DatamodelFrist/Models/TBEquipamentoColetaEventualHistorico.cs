using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEquipamentoColetaEventualHistorico
    {
        public int EquipamentoColetaEventualHistoricoID { get; set; }
        public Nullable<int> EquipamentoColetaEventualID { get; set; }
        public string nmEquipamento { get; set; }
        public Nullable<int> qtEquipamento { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public bool bAtivo { get; set; }
        public System.DateTime dtAlteracao { get; set; }
        public string UserID { get; set; }
    }
}
