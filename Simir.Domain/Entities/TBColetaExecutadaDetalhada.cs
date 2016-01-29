namespace Simir.Domain.Entities
{
    public class TBColetaExecutadaDetalhada
    {
        public int ColetaExecutadaDetalhadaID { get; set; }
        public int ColetaExecutadaID { get; set; }
        public string HoraChegadaRota { get; set; }
        public string LocalEnchimentoCaminhao { get; set; }
        public int? ExtensaoPercorridaEnchimento { get; set; }
        public string HoraEnchimento { get; set; }
        public string horaChegadaLocalDescarga { get; set; }
        public int? QtResiduo { get; set; }
        public string PlacaVeiculo { get; set; }
        public bool bLitro { get; set; }
        public bool? bAtivo { get; set; }
        public virtual TBColetaExecutada TBColetaExecutada { get; set; }
    }
}