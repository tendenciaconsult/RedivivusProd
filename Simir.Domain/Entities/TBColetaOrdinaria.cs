using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBColetaOrdinaria
    {
        public TBColetaOrdinaria()
        {
            TBEquipamentoColetaOrdinarias = new List<TBEquipamentoColetaOrdinaria>();
        }

        public int ColetaOrdinariaID { get; set; }
        public int RotasID { get; set; }
        public int PrestadoraServicosID { get; set; }
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
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
        public virtual TBRota TBRota { get; set; }
        public virtual ICollection<TBEquipamentoColetaOrdinaria> TBEquipamentoColetaOrdinarias { get; set; }
    }
}