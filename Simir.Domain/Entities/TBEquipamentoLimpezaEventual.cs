namespace Simir.Domain.Entities
{
    public class TBEquipamentoLimpezaEventual
    {
        public int EquipamentoLimpezaEventualID { get; set; }
        public int? LimpezaEventualID { get; set; }
        public string nmTipoEquipamento { get; set; }
        public int? Quantidade { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBLimpezaEventual LimpezaEventual { get; set; }
    }
}