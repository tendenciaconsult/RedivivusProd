using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEquipamentoColetaOrdinariaHistorico
    {
        public int EquipamentoColetaOrdinariaHistoricoID { get; set; }
        public int EquipamentoColetaOrdinariaID { get; set; }
        public string nmEquipamento { get; set; }
        public Nullable<int> qtEquipamento { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public bool bAtivo { get; set; }
        public System.DateTime dtAlteracao { get; set; }
        public string UserID { get; set; }
    }
}
