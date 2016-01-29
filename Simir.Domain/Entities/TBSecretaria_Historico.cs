using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBSecretaria_Historico : Historico<TBSecretaria>
    {
        public int Secretaria_HistoricoID { get; set; }
        public int SecretariaID { get; set; }
        public string nmSecretaria { get; set; }
        public string nmSecretario { get; set; }
        public string Site { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public int? EnderecoID { get; set; }
        public int? PrefeituraID { get; set; }

        public override void To(TBSecretaria pricipal)
        {
            SecretariaID = pricipal.SecretariaID;
            nmSecretaria = pricipal.nmSecretaria;
            nmSecretario = pricipal.nmSecretario;
            Site = pricipal.Site;
            Telefone1 = pricipal.Telefone1;
            Telefone2 = pricipal.Telefone2;
            Email = pricipal.Email;
            EnderecoID = pricipal.EnderecoID;
            PrefeituraID = pricipal.PrefeituraID;
        }
    }
}