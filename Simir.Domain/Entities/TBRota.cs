using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public sealed class TBRota
    {
        public TBRota()
        {
            TBColetaEventuals = new List<TBColetaEventual>();
            TBColetaOrdinarias = new List<TBColetaOrdinaria>();
            TBRotasDescricaos = new List<TBRotasDescricao>();
        }

        public int RotasID { get; set; }
        public string nmRota { get; set; }
        public int? PrefeituraID { get; set; }
        public int? DistanciaGaragemRota { get; set; }
        public int? DistanciaRotaDescarregamento { get; set; }
        public int? ExtensaoRota { get; set; }
        public int? qtPopulacaoAtendida { get; set; }
        public bool bAtivo { get; set; }
        public int? LocalDestinoID { get; set; }
        public string nmLocalDestino { get; set; }
        public ICollection<TBColetaEventual> TBColetaEventuals { get; set; }
        public ICollection<TBColetaOrdinaria> TBColetaOrdinarias { get; set; }
        public TBPrefeitura TBPrefeitura { get; set; }
        public ICollection<TBRotasDescricao> TBRotasDescricaos { get; set; }
    }
}
