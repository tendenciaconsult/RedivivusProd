using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Entities
{
    public class TBContratoVeiculo
    {
        public int ContratoVeiculoID { get; set; }
        public string Tipo { get; set; }
        public string Placa { get; set; }
        public int? Capacidade { get; set; }
        public DateTime? DataFabrica { get; set; }
        public DateTime? DataLimiteUso { get; set; }

        public bool bAtivo { get; set; }

        public int ContratoID { get; set; }
        public virtual TBContrato Contrato { get; set; }
    }
}
