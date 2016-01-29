using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBPrestadoraServicosEquipamento
    {
        public int PrestadoraServicosEquipamentosID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public string nmEquipamento { get; set; }
        public int qtEquipamento { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public string Discriminator { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
    }
}
