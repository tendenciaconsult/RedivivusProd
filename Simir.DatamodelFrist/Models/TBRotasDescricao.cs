using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRotasDescricao
    {
        public int RotasDescricaoID { get; set; }
        public Nullable<int> RotasID { get; set; }
        public Nullable<int> ExtensaoPercorrida { get; set; }
        public bool bAtivo { get; set; }
        public string nmDirecionamento { get; set; }
        public bool PEV { get; set; }
        public Nullable<int> EnderecoBairroID { get; set; }
        public Nullable<int> EnderecoLogradouroID { get; set; }
        public Nullable<int> RegiaoAdministrativaID { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
        public virtual TBRota TBRota { get; set; }
    }
}
