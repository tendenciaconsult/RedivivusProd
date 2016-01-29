using System;
using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBLimpezaOrdinariaHistory : Historico<TBLimpezaOrdinaria>
    {
        public int LimpezaOrdinariaHistoryID { get; set; }
        public int PrefeituraID { get; set; }
        public int? RegiaoAdministrativaID { get; set; }
        public int? PrestadoraServicosID { get; set; }
        public int? EnderecoBairroID { get; set; }
        public int? EnderecoLogradouroID { get; set; }
        public int? ExtensaoSargetas { get; set; }
        public bool bAtivo { get; set; }
        public int? FeiraLivreID { get; set; }
        public int TipoServico { get; set; }
        public string nmOutroServico { get; set; }
        public bool bSegunda { get; set; }
        public int? qtVarricaoSegunda { get; set; }
        public bool bSegundaFiscalizado { get; set; }
        public bool bTerca { get; set; }
        public int? qtVarricaoTerca { get; set; }
        public bool bTercaFiscalizado { get; set; }
        public bool bQuarta { get; set; }
        public int? qtVarricaoQuarta { get; set; }
        public bool bQuartaFiscalizado { get; set; }
        public bool bQuinta { get; set; }
        public int? qtVarricaoQuinta { get; set; }
        public bool bQuintaFiscalizado { get; set; }
        public bool bSexta { get; set; }
        public int? qtVarricaoSexta { get; set; }
        public bool bSextaFiscalizado { get; set; }
        public bool bSabado { get; set; }
        public int? qtVarricaoSabado { get; set; }
        public bool bSabadoFiscalizado { get; set; }
        public bool bDomingo { get; set; }
        public int? qtVarricaoDomingo { get; set; }
        public bool bDomingoFiscalizado { get; set; }
        public int? qtGarisSegunda { get; set; }
        public int? qtGarisTerca { get; set; }
        public int? qtGarisQuarta { get; set; }
        public int? qtGarisQuinta { get; set; }
        public int? qtGarisSexta { get; set; }
        public int? qtGarisSabado { get; set; }
        public int? qtGarisDomingo { get; set; }
        public string nmProgramacao { get; set; }

        public override void To(TBLimpezaOrdinaria pricipal)
        {
            nmProgramacao = pricipal.nmProgramacao;
            PrefeituraID = pricipal.PrefeituraID;
            RegiaoAdministrativaID = pricipal.RegiaoAdministrativaID;
            PrestadoraServicosID = pricipal.PrestadoraServicosID;
            EnderecoBairroID = pricipal.EnderecoBairroID;
            EnderecoLogradouroID = pricipal.EnderecoLogradouroID;
            ExtensaoSargetas = pricipal.ExtensaoSargetas;
            FeiraLivreID = pricipal.FeiraLivreID;
            TipoServico = Convert.ToInt32(pricipal.TipoServico);
            nmOutroServico = pricipal.nmOutroServico;
            bSegunda = pricipal.bSegunda;
            qtVarricaoSegunda = pricipal.qtVarricaoSegunda;
            bSegundaFiscalizado = pricipal.bSegundaFiscalizado;
            bTerca = pricipal.bTerca;
            qtVarricaoTerca = pricipal.qtVarricaoTerca;
            bTercaFiscalizado = pricipal.bTercaFiscalizado;
            bQuarta = pricipal.bQuarta;
            qtVarricaoQuarta = pricipal.qtVarricaoQuarta;
            bQuartaFiscalizado = pricipal.bQuartaFiscalizado;
            bQuinta = pricipal.bQuinta;
            qtVarricaoQuinta = pricipal.qtVarricaoQuinta;
            bQuintaFiscalizado = pricipal.bQuintaFiscalizado;
            bSexta = pricipal.bSexta;
            qtVarricaoSexta = pricipal.qtVarricaoSexta;
            bSextaFiscalizado = pricipal.bSextaFiscalizado;
            bSabado = pricipal.bSabado;
            qtVarricaoSabado = pricipal.qtVarricaoSabado;
            bSabadoFiscalizado = pricipal.bSabadoFiscalizado;
            bDomingo = pricipal.bDomingo;
            qtVarricaoDomingo = pricipal.qtVarricaoDomingo;
            bDomingoFiscalizado = pricipal.bDomingoFiscalizado;
            qtGarisSegunda = pricipal.qtGarisSegunda;
            qtGarisTerca = pricipal.qtGarisTerca;
            qtGarisQuarta = pricipal.qtGarisQuarta;
            qtGarisQuinta = pricipal.qtGarisQuinta;
            qtGarisSexta = pricipal.qtGarisSexta;
            qtGarisSabado = pricipal.qtGarisSabado;
            qtGarisDomingo = pricipal.qtGarisDomingo;
            bAtivo = pricipal.bAtivo;
        }
    }
}