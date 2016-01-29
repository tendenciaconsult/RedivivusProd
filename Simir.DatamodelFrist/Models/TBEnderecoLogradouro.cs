using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEnderecoLogradouro
    {
        public TBEnderecoLogradouro()
        {
            this.TBFeiraLivres = new List<TBFeiraLivre>();
            this.TBLimpezaEventuals = new List<TBLimpezaEventual>();
            this.TBLimpezaOrdinarias = new List<TBLimpezaOrdinaria>();
            this.TBRegiaoAdministrativaLogradouroes = new List<TBRegiaoAdministrativaLogradouro>();
            this.TBRotasDescricaos = new List<TBRotasDescricao>();
        }

        public int EnderecoLogradouroID { get; set; }
        public string nmLogradouro { get; set; }
        public int EnderecoBairroID { get; set; }
        public string CEP { get; set; }
        public int tipo { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual ICollection<TBFeiraLivre> TBFeiraLivres { get; set; }
        public virtual ICollection<TBLimpezaEventual> TBLimpezaEventuals { get; set; }
        public virtual ICollection<TBLimpezaOrdinaria> TBLimpezaOrdinarias { get; set; }
        public virtual ICollection<TBRegiaoAdministrativaLogradouro> TBRegiaoAdministrativaLogradouroes { get; set; }
        public virtual ICollection<TBRotasDescricao> TBRotasDescricaos { get; set; }
    }
}
