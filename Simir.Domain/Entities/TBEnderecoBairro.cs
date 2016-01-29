namespace Simir.Domain.Entities
{
    public class TBEnderecoBairro
    {
        public int EnderecoBairroID { get; set; }
        public string nmBairro { get; set; }
        public int EnderecoCidadeID { get; set; }
        //public virtual ICollection<TBEndereco> TBEndereco { get; set; }
        public virtual TBEnderecoCidade TBEnderecoCidade { get; set; }
    }
}