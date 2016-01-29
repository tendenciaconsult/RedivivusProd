using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEnderecoCidade
    {
        public TBEnderecoCidade()
        {
            this.TBEnderecoes = new List<TBEndereco>();
            this.TBEnderecoBairroes = new List<TBEnderecoBairro>();
        }

        public int EnderecoCidadeID { get; set; }
        public string nmCidade { get; set; }
        public int EnderecoEstadoID { get; set; }
        public virtual ICollection<TBEndereco> TBEnderecoes { get; set; }
        public virtual ICollection<TBEnderecoBairro> TBEnderecoBairroes { get; set; }
        public virtual TBEnderecoEstado TBEnderecoEstado { get; set; }
    }
}
