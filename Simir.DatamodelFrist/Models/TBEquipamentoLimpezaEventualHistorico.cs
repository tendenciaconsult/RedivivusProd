using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEquipamentoLimpezaEventualHistorico
    {
        public int EquipamentoLimpezaEventualHistoricoID { get; set; }
        public Nullable<int> LimpezaEventualID { get; set; }
        public string nmTipoEquipamento { get; set; }
        public Nullable<int> Quantidade { get; set; }
        public System.DateTime dtAlteracao { get; set; }
        public string userID { get; set; }
        public bool bAtivo { get; set; }
    }
}
