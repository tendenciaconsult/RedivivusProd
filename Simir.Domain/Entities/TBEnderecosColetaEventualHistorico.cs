using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBEnderecosColetaEventualHistorico : Historico<TBEnderecosColetaEventual>
    {
        public int EnderecosColetaEventualHistoricoID { get; set; }
        public int EnderecosColetaEventualID { get; set; }
        public string nmSolicitante { get; set; }
        public string Telefone { get; set; }
        public string EnderecoColeta { get; set; }
        public string ItensColeta { get; set; }
        public bool bAtivo { get; set; }

        public override void To(TBEnderecosColetaEventual pricipal)
        {
            EnderecosColetaEventualID = pricipal.EnderecosColetaEventualID;
            nmSolicitante = pricipal.nmSolicitante;
            Telefone = pricipal.Telefone;
            EnderecoColeta = pricipal.EnderecoColeta;
            ItensColeta = pricipal.ItensColeta;
            bAtivo = pricipal.bAtivo;
        }
    }
}