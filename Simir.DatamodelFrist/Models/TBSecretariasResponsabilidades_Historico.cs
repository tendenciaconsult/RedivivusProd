using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBSecretariasResponsabilidades_Historico
    {
        public int SecretariasResponsabilidades_HistoricoID { get; set; }
        public int SecretariasResponsabilidadesID { get; set; }
        public Nullable<int> ResponsabilidadesID { get; set; }
        public Nullable<int> SecretariaID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public string nmOutros { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
