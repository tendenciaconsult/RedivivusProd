using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRegiaoAdministrativaHistorico
    {
        public int RegiaoAdministrativaHistoricoID { get; set; }
        public Nullable<int> RegiaoAdministrativaID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public string nmRegiaoAdministrativa { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserID { get; set; }
        public bool bAtivo { get; set; }
    }
}
