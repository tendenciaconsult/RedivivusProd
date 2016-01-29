namespace Simir.Domain.Entities
{
    public class TBRegiaoAdministrativaLogradouro
    {
        public int RegiaoAdministrativaLogradouroID { get; set; }
        public int? RegiaoAdministrativaID { get; set; }
        public int? EnderecoLogradouroID { get; set; }
        public int? EnderecoBairroID { get; set; }
        public int? qtSargetas { get; set; }
        public bool? bTotalmenteAsfaltado { get; set; }
        public int? qtSemPavimento { get; set; }
        public int? qtAsfalto { get; set; }
        public int? qtBloco { get; set; }
        public string nmOutroPavimento { get; set; }
        public int? qtOutroPavimento { get; set; }
        public int? qtExtensaoTotal { get; set; }
        public int? qtBocaLobo { get; set; }
        public int? qtLarguraVia { get; set; }
        public bool? bRealizaLimpezaMecanica { get; set; }
        public bool? bRealizaLavagem { get; set; }
        public bool? bPossuiAreaVerde { get; set; }
        public bool? bLogradouroArborizado { get; set; }
        public bool? bPraca { get; set; }
        public bool? bParque { get; set; }
        public int? qtArvores { get; set; }
        public bool? bAtivo { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
    }
}