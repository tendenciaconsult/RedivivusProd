using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class Proc_Return_Total_Residuo_Diario
    {
        public string dtReferencia { get; set; }
        public string nmResiduoColetado { get; set; }
        public int? TotalResiduo { get; set; }
        public bool bColetaRealizada { get; set; }
    }
}
