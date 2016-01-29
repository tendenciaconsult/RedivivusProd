using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBFeiraLivre
    {
        public TBFeiraLivre()
        {
            this.TBLimpezaOrdinarias = new List<TBLimpezaOrdinaria>();
        }

        public int FeiraLivreID { get; set; }
        public int PrefeituraID { get; set; }
        public string nmProgramacao { get; set; }
        public int RegiaoAdministrativaID { get; set; }
        public int BairroID { get; set; }
        public int LogradouroID { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
        public virtual ICollection<TBLimpezaOrdinaria> TBLimpezaOrdinarias { get; set; }
    }
}
