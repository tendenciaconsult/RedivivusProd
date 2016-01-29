using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBTransbordo
    {
        public int TransbordoID { get; set; }
        public int PrefeituraID { get; set; }
        public int EnderecoID { get; set; }
        public string nmFantasiaTransbordo { get; set; }
        public string nmRazaoSocialTransbordo { get; set; }
        public string CNPJ { get; set; }
        public string numeroLicencaOp { get; set; }
        public bool bAtivo { get; set; }        
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
    }
}
