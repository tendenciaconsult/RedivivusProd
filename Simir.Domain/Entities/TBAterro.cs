using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBAterro
    {
        public int AterroID { get; set; }
        public int PrefeituraID { get; set; }
        public int EnderecoID { get; set; }
        public string nmFantasiaAterro { get; set; }
        public string nmRazaoSocialAterro { get; set; }
        public string CNPJ { get; set; }
        public string numeroLicencaOp { get; set; }
        public bool AterroControlado { get; set; }
        
        public bool bAtivo { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
    }
}
