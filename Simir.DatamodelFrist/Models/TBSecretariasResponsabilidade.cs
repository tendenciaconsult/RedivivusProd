using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBSecretariasResponsabilidade
    {
        public int SecretariasResponsabilidadesID { get; set; }
        public Nullable<int> ResponsabilidadesID { get; set; }
        public Nullable<int> SecretariaID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public string nmOutros { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBResponsabilidade TBResponsabilidade { get; set; }
        public virtual TBSecretaria TBSecretaria { get; set; }
    }
}
