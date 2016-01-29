using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBFeiraLivreHistorico : Historico<TBFeiraLivre>
    {
        public int FeiraLivreHistoricoID { get; set; }
        public int FeiraLivreID { get; set; }
        public int PrefeituraID { get; set; }
        public string nmProgramacao { get; set; }
        public int RegiaoAdministrativaID { get; set; }
        public int BairroID { get; set; }
        public int LogradouroID { get; set; }
        public bool bAtivo { get; set; }

        public override void To(TBFeiraLivre pricipal)
        {
            FeiraLivreID = pricipal.FeiraLivreID;
            PrefeituraID = pricipal.PrefeituraID;
            nmProgramacao = pricipal.nmProgramacao;
            RegiaoAdministrativaID = pricipal.RegiaoAdministrativaID;
            BairroID = pricipal.BairroID;
            LogradouroID = pricipal.LogradouroID;
            bAtivo = pricipal.bAtivo;
        }
    }
}