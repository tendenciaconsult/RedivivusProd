using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBEquipamentoColetaEventualHistorico : Historico<TBEquipamentoColetaEventual>
    {
        public int EquipamentoColetaEventualHistoricoID { get; set; }
        public int? EquipamentoColetaEventualID { get; set; }
        public string nmEquipamento { get; set; }
        public int? qtEquipamento { get; set; }
        public decimal? Volume { get; set; }
        public bool bAtivo { get; set; }

        public override void To(TBEquipamentoColetaEventual pricipal)
        {
            EquipamentoColetaEventualID = pricipal.EquipamentoColetaEventualID;
            nmEquipamento = pricipal.nmEquipamento;
            qtEquipamento = pricipal.qtEquipamento;
            Volume = pricipal.Volume;
            bAtivo = pricipal.bAtivo;
        }
    }
}