using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBColetaEventual
    {
        public TBColetaEventual()
        {
            TBEnderecosColetaEventuals = new List<TBEnderecosColetaEventual>();
            TBEquipamentoColetaEventuals = new List<TBEquipamentoColetaEventual>();
        }

        public int ColetaEventualID { get; set; }
        public int PrefeituraID { get; set; }
        public int? PrestadoraServicosID { get; set; }
        public int? RotasID { get; set; }
        public DateTime dtColeta { get; set; }
        public int? DistanciaInicial { get; set; }
        public int? DistanciaFinal { get; set; }
        public int? qtGari { get; set; }
        public string nmColetaEventual { get; set; }
        public bool bColetaOrdinaria { get; set; }
        public int? qtColetaDia { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBColetaExecutada TBColetaExecutada { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
        public virtual TBRota TBRota { get; set; }
        public virtual ICollection<TBEnderecosColetaEventual> TBEnderecosColetaEventuals { get; set; }
        public virtual ICollection<TBEquipamentoColetaEventual> TBEquipamentoColetaEventuals { get; set; }
    }
}