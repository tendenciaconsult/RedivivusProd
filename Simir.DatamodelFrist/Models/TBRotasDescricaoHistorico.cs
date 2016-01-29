using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRotasDescricaoHistorico
    {
        public int RotasDescricaoHistoricoID { get; set; }
        public Nullable<int> RotasDescricaoID { get; set; }
        public Nullable<int> RotasID { get; set; }
        public Nullable<int> ExtensaoPercorrida { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserID { get; set; }
        public bool bAtivo { get; set; }
        public string nmDirecionamento { get; set; }
        public bool PEV { get; set; }
        public Nullable<int> EnderecoBairroID { get; set; }
        public Nullable<int> EnderecoLogradouroID { get; set; }
        public Nullable<int> RegiaoAdministrativaID { get; set; }
    }
}
