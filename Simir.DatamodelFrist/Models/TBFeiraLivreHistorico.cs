using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBFeiraLivreHistorico
    {
        public int FeiraLivreHistoricoID { get; set; }
        public int FeiraLivreID { get; set; }
        public int PrefeituraID { get; set; }
        public string nmProgramacao { get; set; }
        public int RegiaoAdministrativaID { get; set; }
        public int BairroID { get; set; }
        public int LogradouroID { get; set; }
        public bool bAtivo { get; set; }
        public System.DateTime dtAlteracao { get; set; }
        public string UserID { get; set; }
    }
}
