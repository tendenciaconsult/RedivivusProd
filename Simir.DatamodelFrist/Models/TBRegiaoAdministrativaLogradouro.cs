using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRegiaoAdministrativaLogradouro
    {
        public int RegiaoAdministrativaLogradouroID { get; set; }
        public Nullable<int> RegiaoAdministrativaID { get; set; }
        public Nullable<int> EnderecoLogradouroID { get; set; }
        public Nullable<int> EnderecoBairroID { get; set; }
        public Nullable<int> qtSargetas { get; set; }
        public Nullable<bool> bTotalmenteAsfaltado { get; set; }
        public Nullable<int> qtSemPavimento { get; set; }
        public Nullable<int> qtAsfalto { get; set; }
        public Nullable<int> qtBloco { get; set; }
        public string nmOutroPavimento { get; set; }
        public Nullable<int> qtOutroPavimento { get; set; }
        public Nullable<int> qtExtensaoTotal { get; set; }
        public Nullable<int> qtBocaLobo { get; set; }
        public Nullable<int> qtLarguraVia { get; set; }
        public Nullable<bool> bRealizaLimpezaMecanica { get; set; }
        public Nullable<bool> bRealizaLavagem { get; set; }
        public Nullable<bool> bPossuiAreaVerde { get; set; }
        public Nullable<bool> bLogradouroArborizado { get; set; }
        public Nullable<bool> bPraca { get; set; }
        public Nullable<bool> bParque { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public Nullable<int> qtArvores { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
    }
}
