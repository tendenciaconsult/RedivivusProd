using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBResiduosDestinadore
    {
        public int ResiduosDestinadoresID { get; set; }
        public int? EmpresaID { get; set; }
        public DateTime dtMesReferencia { get; set; }
        public bool RealizouTransbordo { get; set; }
        public string CNPJTransbordo { get; set; }
        public string nmRazaoSocialTransbordo { get; set; }
        public string CNPJTransportadora { get; set; }

        public bool DePrefeitura { get; set; }
        public string nmRazaoSocialTransportadora { get; set; }
        public virtual TBEmpresa Empresa { get; set; }
        public virtual ICollection<TBResiduosDestinadoreItem> Itens { get; set; }
    }

    public class TBResiduosDestinadoreItem
    {
        public int ResiduosDestinadoreItemID { get; set; }

        public int ResiduosDestinadorID { get; set; }

        public int ResiduoClassificadoID { get; set; }

        public bool emLitros { get; set; }

        public double qtResiduo { get; set; }

        public virtual TBResiduosDestinadore ResiduosDestinador { get; set; }

        public virtual TBResiduoClassificado ResiduoClassificado { get; set; }
    }
}