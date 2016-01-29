namespace Simir.Domain.Entities
{
    public class TBEnderecoLogradouro
    {
        public int EnderecoLogradouroID { get; set; }
        public string nmLogradouro { get; set; }
        public int EnderecoBairroID { get; set; }
        public string CEP { get; set; }
        //public virtual ICollection<TBEndereco> TBEndereco { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
    }
}