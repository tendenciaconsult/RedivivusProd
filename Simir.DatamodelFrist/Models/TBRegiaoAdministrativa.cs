using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRegiaoAdministrativa
    {
        public TBRegiaoAdministrativa()
        {
            this.TBFeiraLivres = new List<TBFeiraLivre>();
            this.TBLimpezaEventuals = new List<TBLimpezaEventual>();
            this.TBLimpezaOrdinarias = new List<TBLimpezaOrdinaria>();
            this.TBRegiaoAdministrativaLogradouroes = new List<TBRegiaoAdministrativaLogradouro>();
            this.TBRotasDescricaos = new List<TBRotasDescricao>();
        }

        public int RegiaoAdministrativaID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public string nmRegiaoAdministrativa { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public virtual ICollection<TBFeiraLivre> TBFeiraLivres { get; set; }
        public virtual ICollection<TBLimpezaEventual> TBLimpezaEventuals { get; set; }
        public virtual ICollection<TBLimpezaOrdinaria> TBLimpezaOrdinarias { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual ICollection<TBRegiaoAdministrativaLogradouro> TBRegiaoAdministrativaLogradouroes { get; set; }
        public virtual ICollection<TBRotasDescricao> TBRotasDescricaos { get; set; }
    }
}
