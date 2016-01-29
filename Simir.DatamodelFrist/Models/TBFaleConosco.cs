using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBFaleConosco
    {
        public int FaleConoscoID { get; set; }
        public int PrefeituraID { get; set; }
        public string UserID { get; set; }
        public string nmSolicitante { get; set; }
        public string EmailContato { get; set; }
        public string TelefoneContato { get; set; }
        public int AssuntoID { get; set; }
        public string nmAssunto { get; set; }
        public string Mensagem { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
    }
}
