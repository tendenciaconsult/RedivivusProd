using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBRegiaoAdministrativa
    {
        public TBRegiaoAdministrativa()
        {
            TBRegiaoAdministrativaLogradouroes = new List<TBRegiaoAdministrativaLogradouro>();
        }

        public int RegiaoAdministrativaID { get; set; }
        public int? PrefeituraID { get; set; }
        public string nmRegiaoAdministrativa { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual ICollection<TBRegiaoAdministrativaLogradouro> TBRegiaoAdministrativaLogradouroes { get; set; }
    }
}