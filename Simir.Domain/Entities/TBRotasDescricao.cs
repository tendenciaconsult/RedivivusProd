namespace Simir.Domain.Entities
{
    public class TBRotasDescricao
    {
        public int RotasDescricaoID { get; set; }
        public int? RotasID { get; set; }
        public int? ExtensaoPercorrida { get; set; }
        public bool bAtivo { get; set; }
        public string nmDirecionamento { get; set; }
        public bool PEV { get; set; }
        public int? EnderecoBairroID { get; set; }
        public int? EnderecoLogradouroID { get; set; }
        public int? RegiaoAdministrativaID { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
        public virtual TBRota TBRota { get; set; }
    }
}
