namespace Simir.Domain.Entities
{
    public class TBEndereco
    {
        public int EnderecoID { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string nmLogradouro { get; set; }
        public int EnderecoBairroID { get; set; }
        public int EnderecoCidadeID { get; set; }
        public int EnderecoEstadoID { get; set; }
        public string CEP { get; set; }
        //public virtual ICollection<TBEmpresa> TBEmpresa { get; set; }
        //public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoCidade TBEnderecoCidade { get; set; }
        public virtual TBEnderecoEstado TBEnderecoEstado { get; set; }
    }
}