using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBSecretaria_Historico
    {
        public int Secretaria_HistoricoID { get; set; }
        public int SecretariaID { get; set; }
        public string nmSecretaria { get; set; }
        public string nmSecretario { get; set; }
        public string Site { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public Nullable<int> EnderecoID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
