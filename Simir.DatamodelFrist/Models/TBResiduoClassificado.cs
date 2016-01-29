using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduoClassificado
    {
        public TBResiduoClassificado()
        {
            this.TBResiduosGeradosItems = new List<TBResiduosGeradosItem>();
            this.TBResiduosColetadosItems = new List<TBResiduosColetadosItem>();
            this.TBResiduosDestinadoresItems = new List<TBResiduosDestinadoresItem>();
            this.TBResiduosTratados = new List<TBResiduosTratado>();
        }

        public int ResiduoClassificadoID { get; set; }
        public int ResiduoListaID { get; set; }
        public int ResiduoAtividadeID { get; set; }
        public int ResiduoClasseID { get; set; }
        public int ResiduoID { get; set; }
        public virtual TBResiduo TBResiduo { get; set; }
        public virtual TBResiduoAtividade TBResiduoAtividade { get; set; }
        public virtual TBResiduoClasse TBResiduoClasse { get; set; }
        public virtual ICollection<TBResiduosGeradosItem> TBResiduosGeradosItems { get; set; }
        public virtual ICollection<TBResiduosColetadosItem> TBResiduosColetadosItems { get; set; }
        public virtual ICollection<TBResiduosDestinadoresItem> TBResiduosDestinadoresItems { get; set; }
        public virtual ICollection<TBResiduosTratado> TBResiduosTratados { get; set; }
        public virtual TBResiduoLista TBResiduoLista { get; set; }
    }
}
