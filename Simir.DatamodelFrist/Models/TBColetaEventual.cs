using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBColetaEventual
    {
        public TBColetaEventual()
        {
            this.TBEnderecosColetaEventuals = new List<TBEnderecosColetaEventual>();
            this.TBEquipamentoColetaEventuals = new List<TBEquipamentoColetaEventual>();
        }

        public int ColetaEventualID { get; set; }
        public int PrefeituraID { get; set; }
        public Nullable<int> PrestadoraServicosID { get; set; }
        public Nullable<int> RotasID { get; set; }
        public System.DateTime dtColeta { get; set; }
        public Nullable<int> DistanciaInicial { get; set; }
        public Nullable<int> DistanciaFinal { get; set; }
        public Nullable<int> qtGari { get; set; }
        public string nmColetaEventual { get; set; }
        public bool bColetaOrdinaria { get; set; }
        public Nullable<int> qtColetaDia { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
        public virtual TBRota TBRota { get; set; }
        public virtual ICollection<TBEnderecosColetaEventual> TBEnderecosColetaEventuals { get; set; }
        public virtual ICollection<TBEquipamentoColetaEventual> TBEquipamentoColetaEventuals { get; set; }
    }
}
