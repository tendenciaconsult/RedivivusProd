using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBUsuario
    {
        public TBUsuario()
        {
            this.AspNetUsers = new List<AspNetUser>();
        }

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
        public bool bAtivo { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
    }
}
