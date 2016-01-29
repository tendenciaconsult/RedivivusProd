using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEnderecosColetaEventualHistorico
    {
        public int EnderecosColetaEventualHistoricoID { get; set; }
        public int EnderecosColetaEventualID { get; set; }
        public string nmSolicitante { get; set; }
        public string Telefone { get; set; }
        public string EnderecoColeta { get; set; }
        public string ItensColeta { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserId { get; set; }
        public bool bAtivo { get; set; }
    }
}
