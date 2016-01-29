namespace Simir.Domain.Entities
{
    public class TBEquipamentoColetaOrdinaria
    {
        public int EquipamentoColetaOrdinariaID { get; set; }
        public int ColetaOrdinariaID { get; set; }
        public string nmEquipamento { get; set; }
        public int? qtEquipamento { get; set; }
        public decimal? Volume { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBColetaOrdinaria TBColetaOrdinaria { get; set; }
    }
}