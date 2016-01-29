namespace Simir.Domain.Entities
{
    public class TBEquipamentoLimpezaExecutada
    {
        public int EquipamentoLimpezaExecutadaID { get; set; }
        public int LimpezaExecutadaID { get; set; }
        public string nmTipoEquipamento { get; set; }
        public int? Quantidade { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBLimpezaExecutada TBLimpezaExecutada { get; set; }
    }
}