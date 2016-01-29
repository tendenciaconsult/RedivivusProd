using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBSecretariasResponsabilidade_Historico : Historico<TBSecretariasResponsabilidade>
    {
        public int SecretariasResponsabilidades_HistoricoID { get; set; }
        public int SecretariasResponsabilidadesID { get; set; }
        public int? ResponsabilidadesID { get; set; }
        public int? SecretariaID { get; set; }
        public int? PrefeituraID { get; set; }
        public string nmOutros { get; set; }

        public override void To(TBSecretariasResponsabilidade pricipal)
        {
            SecretariasResponsabilidadesID = pricipal.SecretariasResponsabilidadesID;
            ResponsabilidadesID = pricipal.ResponsabilidadesID;
            SecretariaID = pricipal.SecretariaID;
            PrefeituraID = pricipal.PrefeituraID;
            nmOutros = pricipal.nmOutros;
        }
    }
}