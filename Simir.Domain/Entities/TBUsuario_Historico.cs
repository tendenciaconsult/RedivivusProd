using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBUsuario_Historico : Historico<TBUsuario>
    {
        public int usuario_HistoricoID { get; set; }
        public int usuarioID { get; set; }
        public string nmUsuario { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string CPF { get; set; }
        public string matricula { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int? EnderecoID { get; set; }
        public int? PrefeituraID { get; set; }

        public override void To(TBUsuario pricipal)
        {
            usuarioID = pricipal.usuarioID;
            nmUsuario = pricipal.nmUsuario;
            Email = pricipal.Email;
            Cargo = pricipal.Cargo;
            CPF = pricipal.CPF;
            matricula = pricipal.matricula;
            Telefone = pricipal.Telefone;
            Celular = pricipal.Celular;
            EnderecoID = pricipal.EnderecoID;
            PrefeituraID = pricipal.PrefeituraID;
        }
    }
}