using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEnderecosColetaEventual
    {
        public int EnderecosColetaEventualID { get; set; }
        public int ColetaEventualID { get; set; }
        public string nmSolicitante { get; set; }
        public string Telefone { get; set; }
        public string EnderecoColeta { get; set; }
        public string ItensColeta { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBColetaEventual TBColetaEventual { get; set; }
    }
}
