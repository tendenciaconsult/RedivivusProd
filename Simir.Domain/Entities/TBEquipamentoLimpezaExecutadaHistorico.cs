using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBEquipamentoLimpezaExecutadaHistorico : Historico<TBEquipamentoLimpezaExecutada>
    {
        public int EquipamentoLimpezaExecutadaHistorico { get; set; }
        public int? EquipamentoLimpezaExecutadaID { get; set; }
        public string nmTipoEquipamento { get; set; }
        public int? Quantidade { get; set; }
        public bool bAtivo { get; set; }

        public override void To(TBEquipamentoLimpezaExecutada pricipal)
        {
            EquipamentoLimpezaExecutadaID = pricipal.EquipamentoLimpezaExecutadaID;
            nmTipoEquipamento = pricipal.nmTipoEquipamento;
            Quantidade = pricipal.Quantidade;
            bAtivo = pricipal.bAtivo;
        }
    }
}