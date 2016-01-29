using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class Proc_ReturnListaMenu
    {
        public int? AspNetPermissaoId { get; set; }
        public int? ModuloID { get; set; }
        public string MenuPai { get; set; }
        public string MenuFilho { get; set; }
        public bool? Consultar { get; set; }
        public bool? Incluir { get; set; }
        public bool? Alterar { get; set; }
        public bool? Excluir { get; set; }
        public bool? Imprimir { get; set; }

    }
}
