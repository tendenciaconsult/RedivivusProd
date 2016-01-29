using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class AspNetPerfil
    {
        public AspNetPerfil()
        {
            this.AspNetPermissaos = new List<AspNetPermissao>();
            this.AspNetUsers = new List<AspNetUser>();
        }

        public int AspNetPerfilId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual ICollection<AspNetPermissao> AspNetPermissaos { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
