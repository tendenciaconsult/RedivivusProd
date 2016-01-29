using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBEquipamentoLimpezaEventualHistorico : Historico<TBEquipamentoLimpezaEventual>
    {
        public int EquipamentoLimpezaEventualHistoricoID { get; set; }
        public int? LimpezaEventualID { get; set; }
        public string nmTipoEquipamento { get; set; }
        public int? Quantidade { get; set; }
        public bool bAtivo { get; set; }

        public override void To(TBEquipamentoLimpezaEventual pricipal)
        {
            LimpezaEventualID = pricipal.LimpezaEventualID;
            nmTipoEquipamento = pricipal.nmTipoEquipamento;
            Quantidade = pricipal.Quantidade;
            bAtivo = pricipal.bAtivo;
        }
    }
}