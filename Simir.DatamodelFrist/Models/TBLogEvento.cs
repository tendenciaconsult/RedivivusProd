using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBLogEvento
    {
        public int LogEventosID { get; set; }
        public string UserId { get; set; }
        public string nmUsuario { get; set; }
        public System.DateTime dtDataAcao { get; set; }
        public string Acao { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
    }
}
