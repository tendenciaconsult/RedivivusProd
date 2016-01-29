namespace Simir.Domain.Entities
{
    public class TBResiduoVinculado
    {
        public int ResiduoVinculadoID { get; set; }
        public int? DestinacaoRejeitoID { get; set; }
        public int? ResiduoID { get; set; }
        public double qtRejeitoVinculado { get; set; }
        public virtual TBResiduosDestinadorRejeito TBDestinacaoRejeito { get; set; }
        public virtual TBResiduo TBResiduo { get; set; }
    }
}