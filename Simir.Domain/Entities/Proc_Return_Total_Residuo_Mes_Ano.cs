using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Entities
{
    public class Proc_Return_Total_Residuo_Mes_Ano
    {
        public string MesRef { get; set; }
        public string nmResiduoColetado { get; set; }
        public int? TotalResiduo { get; set; }
        public bool bColetaRealizada { get; set; }
    }
}
