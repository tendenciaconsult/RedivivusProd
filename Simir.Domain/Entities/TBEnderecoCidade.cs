namespace Simir.Domain.Entities
{
    public class TBEnderecoCidade
    {
        public int EnderecoCidadeID { get; set; }
        public string nmCidade { get; set; }
        public int EnderecoEstadoID { get; set; }
        //public virtual ICollection<TBEndereco> TBEndereco { get; set; }
        //public virtual ICollection<TBEnderecoBairro> TBEnderecoBairro { get; set; }
        public virtual TBEnderecoEstado TBEnderecoEstado { get; set; }
    }
}