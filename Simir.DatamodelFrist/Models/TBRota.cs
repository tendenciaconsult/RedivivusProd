using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRota
    {
        public TBRota()
        {
            this.TBColetaEventuals = new List<TBColetaEventual>();
            this.TBColetaOrdinarias = new List<TBColetaOrdinaria>();
            this.TBRotasDescricaos = new List<TBRotasDescricao>();
        }

        public int RotasID { get; set; }
        public string nmRota { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public Nullable<int> DistanciaGaragemRota { get; set; }
        public Nullable<int> DistanciaRotaDescarregamento { get; set; }
        public Nullable<int> ExtensaoRota { get; set; }
        public Nullable<int> qtPopulacaoAtendida { get; set; }
        public bool bAtivo { get; set; }
        public Nullable<int> LocalDestinoID { get; set; }
        public string nmLocalDestino { get; set; }
        public virtual ICollection<TBColetaEventual> TBColetaEventuals { get; set; }
        public virtual ICollection<TBColetaOrdinaria> TBColetaOrdinarias { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual ICollection<TBRotasDescricao> TBRotasDescricaos { get; set; }
    }
}
