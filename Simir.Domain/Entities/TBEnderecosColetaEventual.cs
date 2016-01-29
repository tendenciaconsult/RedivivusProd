namespace Simir.Domain.Entities
{
    public class TBEnderecosColetaEventual
    {
        public int EnderecosColetaEventualID { get; set; }
        public int ColetaEventualID { get; set; }
        public string nmSolicitante { get; set; }
        public string Telefone { get; set; }
        public string EnderecoColeta { get; set; }
        public string ItensColeta { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBColetaEventual TBColetaEventual { get; set; }
    }
}