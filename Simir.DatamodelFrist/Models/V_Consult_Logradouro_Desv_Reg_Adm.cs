using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class V_Consult_Logradouro_Desv_Reg_Adm
    {
        public string nmBairro { get; set; }
        public string nmLogradouro { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public int EnderecoCidadeID { get; set; }
        public int RegiaoAdministrativaID { get; set; }
    }
}
