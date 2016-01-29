using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class AspNetPermissao
    {
        public int AspNetPermissaoId { get; set; }
        public int AspNetPerfilId { get; set; }
        public int AspNetModuloId { get; set; }
        public int AspNetTipoPermissaoId { get; set; }
        public virtual AspNetModulo AspNetModulo { get; set; }
        public virtual AspNetPerfil AspNetPerfil { get; set; }
    }
}
