using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBEquipamentoColetaOrdinariaHistorico : Historico<TBEquipamentoColetaOrdinaria>
    {
        public int EquipamentoColetaOrdinariaHistoricoID { get; set; }
        public int EquipamentoColetaOrdinariaID { get; set; }
        public string nmEquipamento { get; set; }
        public int? qtEquipamento { get; set; }
        public decimal? Volume { get; set; }
        public bool bAtivo { get; set; }

        public override void To(TBEquipamentoColetaOrdinaria pricipal)
        {
            EquipamentoColetaOrdinariaID = pricipal.EquipamentoColetaOrdinariaID;
            nmEquipamento = pricipal.nmEquipamento;
            qtEquipamento = pricipal.qtEquipamento;
            Volume = pricipal.Volume;
            bAtivo = pricipal.bAtivo;
        }
    }
}