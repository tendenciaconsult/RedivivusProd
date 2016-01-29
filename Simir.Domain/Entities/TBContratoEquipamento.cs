using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Entities
{
    public class TBContratoEquipamento
    {
        public int ContratoEquipamentoID { get; set; }
        public string Tipo { get; set; }
        public int? Quantidade { get; set; }
        
        public bool bAtivo { get; set; }

        public int ContratoID { get; set; }
        public virtual TBContrato Contrato { get; set; }
    }
}
