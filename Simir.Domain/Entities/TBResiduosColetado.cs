using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBResiduosColetado
    {
        public int ResiduosColetadosID { get; set; }
        public int EmpresaID { get; set; }
        public DateTime dtMesReferencia { get; set; }
        public bool RealizouTransbordo { get; set; }
        public string CNPJTransbordo { get; set; }
        public string CnpjGeradora { get; set; }
        public string nmRazaoSocialGeradora { get; set; }
        public string nmPessoaLiberouColeta { get; set; }
        public string CNPJDestinadora { get; set; }
        public string RazaoSocialDestinadora { get; set; }
        public bool DestinadoraFinal { get; set; }
        public virtual TBEmpresa Empresa { get; set; }
        public virtual ICollection<TBResiduosColetadoItem> Itens { get; set; }
    }
}