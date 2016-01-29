using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduosColetado
    {
        public TBResiduosColetado()
        {
            this.TBResiduosColetadosItems = new List<TBResiduosColetadosItem>();
        }

        public int ResiduosColetadosID { get; set; }
        public int EmpresaID { get; set; }
        public bool RealizouTransbordo { get; set; }
        public string CnpjGeradora { get; set; }
        public string nmRazaoSocialGeradora { get; set; }
        public string nmPessoaLiberouColeta { get; set; }
        public string CNPJDestinadora { get; set; }
        public string RazaoSocialDestinadora { get; set; }
        public bool DestinadoraFinal { get; set; }
        public System.DateTime dtMesReferencia { get; set; }
        public string CNPJTransbordo { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
        public virtual ICollection<TBResiduosColetadosItem> TBResiduosColetadosItems { get; set; }
    }
}
