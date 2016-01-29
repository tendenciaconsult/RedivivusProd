using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBColetaExecutadaDetalhadaHistorico : Historico<TBColetaExecutadaDetalhada>
    {
        public int ColetaExecutadaDetalhadaHistoricoID { get; set; }
        public int? ColetaExecutadaDetalhadaID { get; set; }
        public string HoraChegadaRota { get; set; }
        public string LocalEnchimentoCaminhao { get; set; }
        public int? ExtensaoPercorridaEnchimento { get; set; }
        public string HoraEnchimento { get; set; }
        public string horaChegadaLocalDescarga { get; set; }
        public int? QtResiduo { get; set; }
        public string PlacaVeiculo { get; set; }
        public bool? bAtivo { get; set; }

        public override void To(TBColetaExecutadaDetalhada pricipal)
        {
            ColetaExecutadaDetalhadaID = pricipal.ColetaExecutadaDetalhadaID;
            HoraChegadaRota = pricipal.HoraChegadaRota;
            LocalEnchimentoCaminhao = pricipal.LocalEnchimentoCaminhao;
            ExtensaoPercorridaEnchimento = pricipal.ExtensaoPercorridaEnchimento;
            HoraEnchimento = pricipal.HoraEnchimento;
            horaChegadaLocalDescarga = pricipal.horaChegadaLocalDescarga;
            QtResiduo = pricipal.QtResiduo;
            PlacaVeiculo = pricipal.PlacaVeiculo;
            bAtivo = bAtivo;
        }
    }
}