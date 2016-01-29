using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBColetaEventualHistorico
    {
        public int ColetaEventualHistoricoID { get; set; }
        public Nullable<int> ColetaEventualID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public Nullable<int> PrestadoraServicosID { get; set; }
        public Nullable<int> RotasID { get; set; }
        public Nullable<System.DateTime> dtColeta { get; set; }
        public Nullable<int> DistanciaInicial { get; set; }
        public Nullable<int> DistanciaFinal { get; set; }
        public Nullable<int> qtGari { get; set; }
        public string nmColetaEventual { get; set; }
        public Nullable<bool> bColetaOrdinaria { get; set; }
        public Nullable<int> qtColetaDia { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public System.DateTime dtAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
