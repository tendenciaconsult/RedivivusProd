using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBUsuario_Historico
    {
        public int usuario_HistoricoID { get; set; }
        public int usuarioID { get; set; }
        public string nmUsuario { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string CPF { get; set; }
        public string matricula { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Nullable<int> EnderecoID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserId { get; set; }
        public bool bAtivo { get; set; }
    }
}
