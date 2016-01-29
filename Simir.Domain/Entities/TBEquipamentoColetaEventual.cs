namespace Simir.Domain.Entities
{
    public class TBEquipamentoColetaEventual
    {
        public int EquipamentoColetaEventualID { get; set; }
        public int ColetaEventualID { get; set; }
        public string nmEquipamento { get; set; }
        public int? qtEquipamento { get; set; }
        public decimal? Volume { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBColetaEventual TBColetaEventual { get; set; }
    }
}