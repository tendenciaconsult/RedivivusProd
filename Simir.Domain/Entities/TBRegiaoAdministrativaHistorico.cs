using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBRegiaoAdministrativaHistorico : Historico<TBRegiaoAdministrativa>
    {
        public int RegiaoAdministrativaHistoricoID { get; set; }
        public int? RegiaoAdministrativaID { get; set; }
        public int? PrefeituraID { get; set; }
        public string nmRegiaoAdministrativa { get; set; }
        public bool bAtivo { get; set; }

        public override void To(TBRegiaoAdministrativa pricipal)
        {
            PrefeituraID = pricipal.PrefeituraID;
            RegiaoAdministrativaID = pricipal.RegiaoAdministrativaID;
            nmRegiaoAdministrativa = pricipal.nmRegiaoAdministrativa;
            bAtivo = pricipal.bAtivo;
        }
    }
}