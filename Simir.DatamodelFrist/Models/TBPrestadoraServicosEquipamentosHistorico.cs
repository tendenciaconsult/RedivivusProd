using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBPrestadoraServicosEquipamentosHistorico
    {
        public int PrestadoraServicosEquipamentosHistoricoID { get; set; }
        public int PrestadoraServicosEquipamentosID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public string nmEquipamento { get; set; }
        public int qtEquipamento { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public string Discriminator { get; set; }
        public bool bAtivo { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
