using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class AspNetModulo
    {
        public AspNetModulo()
        {
            this.AspNetModulo1 = new List<AspNetModulo>();
            this.AspNetPermissaos = new List<AspNetPermissao>();
        }

        public int AspNetModuloId { get; set; }
        public string Nome { get; set; }
        public string Display { get; set; }
        public Nullable<int> AspNetControllerId { get; set; }
        public string Discriminator { get; set; }
        public Nullable<int> ModuloPaiId { get; set; }
        public int Nivel { get; set; }
        public bool bVisivelDisplay { get; set; }
        public virtual AspNetController AspNetController { get; set; }
        public virtual ICollection<AspNetModulo> AspNetModulo1 { get; set; }
        public virtual AspNetModulo AspNetModulo2 { get; set; }
        public virtual ICollection<AspNetPermissao> AspNetPermissaos { get; set; }
    }
}
