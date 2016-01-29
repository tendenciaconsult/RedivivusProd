using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class AspNetController
    {
        public AspNetController()
        {
            this.AspNetModuloes = new List<AspNetModulo>();
        }

        public int AspNetControllerId { get; set; }
        public string Nome { get; set; }
        public string Display { get; set; }
        public virtual ICollection<AspNetModulo> AspNetModuloes { get; set; }
    }
}
