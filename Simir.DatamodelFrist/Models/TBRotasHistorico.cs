using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRotasHistorico
    {
        public int RotasHistoricoID { get; set; }
        public Nullable<int> RotasID { get; set; }
        public string nmRota { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public Nullable<int> DistanciaGaragemRota { get; set; }
        public Nullable<int> DistanciaRotaDescarregamento { get; set; }
        public Nullable<int> ExtensaoRota { get; set; }
        public Nullable<int> qtPopulacaoAtendida { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserID { get; set; }
        public bool bAtivo { get; set; }
        public Nullable<int> LocalDestinoID { get; set; }
        public string nmLocalDestino { get; set; }
    }
}
