using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBColetaOrdinariaHistorico : Historico<TBColetaOrdinaria>
    {
        public int ColetaOrdinariaHistoricoID { get; set; }
        public int ColetaOrdinariaID { get; set; }
        public int? RotasID { get; set; }
        public int? PrestadoraServicosID { get; set; }
        public string nmColetaOrdinaria { get; set; }
        public bool bSegunda { get; set; }
        public bool bTerca { get; set; }
        public bool bQuarta { get; set; }
        public bool bQuinta { get; set; }
        public bool bSexta { get; set; }
        public bool bSabado { get; set; }
        public bool bAtivo { get; set; }
        public int PrefeituraID { get; set; }
        public int? qtColetaSegunda { get; set; }
        public bool? bSegundaFiscalizado { get; set; }
        public int? qtColetaTerca { get; set; }
        public bool? bTercaFiscalizado { get; set; }
        public int? qtColetaQuarta { get; set; }
        public bool? bQuartaFiscalizado { get; set; }
        public int? qtColetaQuinta { get; set; }
        public bool? bQuintaFiscalizado { get; set; }
        public int? qtColetaSexta { get; set; }
        public bool? bSextaFiscalizado { get; set; }
        public int? qtColetaSabado { get; set; }
        public bool? bSabadoFiscalizado { get; set; }
        public bool? bDomingo { get; set; }
        public int? qtColetaDomingo { get; set; }
        public bool? bDomingoFiscalizado { get; set; }
        public int? qtGarisSegunda { get; set; }
        public int? qtGarisTerca { get; set; }
        public int? qtGarisQuarta { get; set; }
        public int? qtGarisQuinta { get; set; }
        public int? qtGarisSexta { get; set; }
        public int? qtGarisSabado { get; set; }
        public int? qtGarisDomingo { get; set; }

        public override void To(TBColetaOrdinaria pricipal)
        {
            ColetaOrdinariaID = pricipal.ColetaOrdinariaID;
            RotasID = pricipal.RotasID;
            PrestadoraServicosID = pricipal.PrestadoraServicosID;
            nmColetaOrdinaria = pricipal.nmColetaOrdinaria;
            bSegunda = pricipal.bSegunda;
            bTerca = pricipal.bTerca;
            bQuarta = pricipal.bQuarta;
            bQuinta = pricipal.bQuinta;
            bSexta = pricipal.bSexta;
            bSabado = pricipal.bSabado;
            bAtivo = pricipal.bAtivo;
            PrefeituraID = pricipal.PrefeituraID;


            qtColetaSegunda = pricipal.qtColetaSegunda;
            bSegundaFiscalizado = pricipal.bSegundaFiscalizado;
            qtColetaTerca = pricipal.qtColetaTerca;
            bTercaFiscalizado = pricipal.bTercaFiscalizado;
            qtColetaQuarta = pricipal.qtColetaQuarta;
            bQuartaFiscalizado = pricipal.bQuartaFiscalizado;
            qtColetaQuinta = pricipal.qtColetaQuinta;
            bQuintaFiscalizado = pricipal.bQuintaFiscalizado;
            qtColetaSexta = pricipal.qtColetaSexta;
            bSextaFiscalizado = pricipal.bSextaFiscalizado;
            qtColetaSabado = pricipal.qtColetaSabado;
            bSabadoFiscalizado = pricipal.bSabadoFiscalizado;
            bDomingo = pricipal.bDomingo;
            qtColetaDomingo = pricipal.qtColetaDomingo;
            bDomingoFiscalizado = pricipal.bDomingoFiscalizado;
            qtGarisSegunda = pricipal.qtGarisSegunda;
            qtGarisTerca = pricipal.qtGarisTerca;
            qtGarisQuarta = pricipal.qtGarisQuarta;
            qtGarisQuinta = pricipal.qtGarisQuinta;
            qtGarisSexta = pricipal.qtGarisSexta;
            qtGarisSabado = pricipal.qtGarisSabado;
            qtGarisDomingo = pricipal.qtGarisDomingo;
        }
    }
}