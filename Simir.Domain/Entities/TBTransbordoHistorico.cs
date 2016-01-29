using System;
using System.Security.Permissions;
using Simir.Domain.Helpers;


namespace Simir.Domain.Entities
{
    public class TBTransbordoHistorico : Historico<TBTransbordo>
    {
        public int TrasnbordoHistoricoID { get; set; }
        public int TransbordoID { get; set; }
        public int PrefeituraID { get; set; }
        public int EnderecoID { get; set; }
        public string nmFantasiaTransbordo { get; set; }
        public string nmRazaoSocialTransbordo { get; set; }
        public string CNPJ { get; set; }
        public string numeroLicencaOp { get; set; }
        public bool bAtivo { get; set; }
        public override void To(TBTransbordo pricipal)
        {
            TransbordoID = pricipal.TransbordoID;
            PrefeituraID = pricipal.PrefeituraID;
            PrefeituraID = pricipal.PrefeituraID;
            EnderecoID = pricipal.EnderecoID;
            nmFantasiaTransbordo = pricipal.nmFantasiaTransbordo;
            nmRazaoSocialTransbordo = pricipal.nmRazaoSocialTransbordo;
            CNPJ = pricipal.CNPJ;
            numeroLicencaOp = pricipal.numeroLicencaOp;
            bAtivo = pricipal.bAtivo;
        }
    }
}
