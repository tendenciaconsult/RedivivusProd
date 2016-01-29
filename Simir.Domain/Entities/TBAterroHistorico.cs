using System;
using System.Security.Permissions;
using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBAterroHistorico : Historico<TBAterro>
    {
        public int AterroHistoricoID { get; set; }
        public int AterroID { get; set; }
        public int PrefeituraID { get; set; }
        public int EnderecoID { get; set; }
        public string nmFantasiaAterro { get; set; }
        public string nmRazaoSocialAterro { get; set; }
        public string CNPJ { get; set; }
        public string numeroLicencaOp { get; set; }
        public bool AterroControlado { get; set; }
        public bool bAtivo { get; set; }
        public override void To(TBAterro principal)
        {
            AterroID = principal.AterroID;
            PrefeituraID = principal.PrefeituraID;
            PrefeituraID = principal.PrefeituraID;
            EnderecoID = principal.EnderecoID;
            nmFantasiaAterro = principal.nmFantasiaAterro;
            nmRazaoSocialAterro = principal.nmRazaoSocialAterro;
            CNPJ = principal.CNPJ;
            numeroLicencaOp = principal.numeroLicencaOp;
            AterroControlado = principal.AterroControlado;
            bAtivo = principal.bAtivo;
        }
    }
}