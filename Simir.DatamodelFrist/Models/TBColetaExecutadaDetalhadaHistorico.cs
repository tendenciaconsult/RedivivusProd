using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBColetaExecutadaDetalhadaHistorico
    {
        public int ColetaExecutadaDetalhadaHistoricoID { get; set; }
        public Nullable<int> ColetaExecutadaDetalhadaID { get; set; }
        public string HoraChegadaRota { get; set; }
        public string LocalEnchimentoCaminhao { get; set; }
        public Nullable<int> ExtensaoPercorridaEnchimento { get; set; }
        public string HoraEnchimento { get; set; }
        public string horaChegadaLocalDescarga { get; set; }
        public Nullable<int> QtResiduo { get; set; }
        public string PlacaVeiculo { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public System.DateTime dtAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
