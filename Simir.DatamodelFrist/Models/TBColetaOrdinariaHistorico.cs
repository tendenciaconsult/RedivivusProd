using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBColetaOrdinariaHistorico
    {
        public int ColetaOrdinariaHistoricoID { get; set; }
        public int ColetaOrdinariaID { get; set; }
        public Nullable<int> RotasID { get; set; }
        public Nullable<int> PrestadoraServicosID { get; set; }
        public string nmColetaOrdinaria { get; set; }
        public bool bSegunda { get; set; }
        public bool bTerca { get; set; }
        public bool bQuarta { get; set; }
        public bool bQuinta { get; set; }
        public bool bSexta { get; set; }
        public bool bSabado { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserID { get; set; }
        public bool bAtivo { get; set; }
        public int PrefeituraID { get; set; }
        public Nullable<bool> bSegundaFiscalizado { get; set; }
        public Nullable<bool> bTercaFiscalizado { get; set; }
        public Nullable<bool> bQuartaFiscalizado { get; set; }
        public Nullable<bool> bQuintaFiscalizado { get; set; }
        public Nullable<bool> bSextaFiscalizado { get; set; }
        public Nullable<bool> bSabadoFiscalizado { get; set; }
        public Nullable<bool> bDomingo { get; set; }
        public Nullable<bool> bDomingoFiscalizado { get; set; }
        public Nullable<int> qtGarisSegunda { get; set; }
        public Nullable<int> qtGarisTerca { get; set; }
        public Nullable<int> qtGarisQuarta { get; set; }
        public Nullable<int> qtGarisQuinta { get; set; }
        public Nullable<int> qtGarisSexta { get; set; }
        public Nullable<int> qtGarisSabado { get; set; }
        public Nullable<int> qtGarisDomingo { get; set; }
        public Nullable<int> qtColetaSegunda { get; set; }
        public Nullable<int> qtColetaTerca { get; set; }
        public Nullable<int> qtColetaQuarta { get; set; }
        public Nullable<int> qtColetaQuinta { get; set; }
        public Nullable<int> qtColetaSexta { get; set; }
        public Nullable<int> qtColetaSabado { get; set; }
        public Nullable<int> qtColetaDomingo { get; set; }
    }
}
