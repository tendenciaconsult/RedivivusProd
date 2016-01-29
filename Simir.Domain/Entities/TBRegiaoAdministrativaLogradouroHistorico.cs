using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBRegiaoAdministrativaLogradouroHistorico : Historico<TBRegiaoAdministrativaLogradouro>
    {
        public int RegiaoAdministrativaLogradouroHistoricoID { get; set; }
        public int? RegiaoAdministrativaLogradouroID { get; set; }
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

        public override void To(TBRegiaoAdministrativaLogradouro pricipal)
        {
            RegiaoAdministrativaLogradouroID = pricipal.RegiaoAdministrativaLogradouroID;
            EnderecoLogradouroID = pricipal.EnderecoLogradouroID;
            EnderecoBairroID = pricipal.EnderecoBairroID;
            qtSargetas = pricipal.qtSargetas;
            bTotalmenteAsfaltado = pricipal.bTotalmenteAsfaltado;
            qtSemPavimento = pricipal.qtSemPavimento;
            qtAsfalto = pricipal.qtAsfalto;
            qtBloco = pricipal.qtBloco;
            nmOutroPavimento = pricipal.nmOutroPavimento;
            qtOutroPavimento = pricipal.qtOutroPavimento;
            qtExtensaoTotal = pricipal.qtExtensaoTotal;
            qtBocaLobo = pricipal.qtBocaLobo;
            qtLarguraVia = pricipal.qtLarguraVia;
            bRealizaLimpezaMecanica = pricipal.bRealizaLimpezaMecanica;
            bRealizaLavagem = pricipal.bRealizaLavagem;
            bPossuiAreaVerde = pricipal.bPossuiAreaVerde;
            bLogradouroArborizado = pricipal.bLogradouroArborizado;
            bPraca = pricipal.bPraca;
            bParque = pricipal.bParque;
            qtArvores = pricipal.qtArvores;
        }
    }
}