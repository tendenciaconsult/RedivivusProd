using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBEnderecoBairro
    {
        public TBEnderecoBairro()
        {
            this.TBEnderecoes = new List<TBEndereco>();
            this.TBEnderecoLogradouroes = new List<TBEnderecoLogradouro>();
            this.TBFeiraLivres = new List<TBFeiraLivre>();
            this.TBLimpezaEventuals = new List<TBLimpezaEventual>();
            this.TBLimpezaOrdinarias = new List<TBLimpezaOrdinaria>();
            this.TBRegiaoAdministrativaLogradouroes = new List<TBRegiaoAdministrativaLogradouro>();
            this.TBRotasDescricaos = new List<TBRotasDescricao>();
        }

        public int EnderecoBairroID { get; set; }
        public string nmBairro { get; set; }
        public int EnderecoCidadeID { get; set; }
        public virtual ICollection<TBEndereco> TBEnderecoes { get; set; }
        public virtual TBEnderecoCidade TBEnderecoCidade { get; set; }
        public virtual ICollection<TBEnderecoLogradouro> TBEnderecoLogradouroes { get; set; }
        public virtual ICollection<TBFeiraLivre> TBFeiraLivres { get; set; }
        public virtual ICollection<TBLimpezaEventual> TBLimpezaEventuals { get; set; }
        public virtual ICollection<TBLimpezaOrdinaria> TBLimpezaOrdinarias { get; set; }
        public virtual ICollection<TBRegiaoAdministrativaLogradouro> TBRegiaoAdministrativaLogradouroes { get; set; }
        public virtual ICollection<TBRotasDescricao> TBRotasDescricaos { get; set; }
    }
}
