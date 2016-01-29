using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEnderecoEstado
    {
        public TBEnderecoEstado()
        {
            this.TBEnderecoes = new List<TBEndereco>();
            this.TBEnderecoCidades = new List<TBEnderecoCidade>();
        }

        public int EnderecoEstadoID { get; set; }
        public string nmEstado { get; set; }
        public string Abraviacao { get; set; }
        public virtual ICollection<TBEndereco> TBEnderecoes { get; set; }
        public virtual ICollection<TBEnderecoCidade> TBEnderecoCidades { get; set; }
    }
}
