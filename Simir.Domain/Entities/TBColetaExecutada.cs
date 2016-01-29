using Simir.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Simir.Domain.Entities
{
    public class TBColetaExecutada
    {
        public TBColetaExecutada()
        {
            TBColetaExecutadaDetalhadas = new List<TBColetaExecutadaDetalhada>();
        }

        public int ColetaExecutadaID { get; set; }
        public string nmProgramacao { get; set; }
        public DateTime dtReferencia { get; set; }
        public int PrefeituraID { get; set; }
        public bool bColetaRealizada { get; set; }
        public string Motivo { get; set; }
        public string HoraSaidaGaragem { get; set; }
        public string HoraChegadaGaragem { get; set; }
        public int? qtGaris { get; set; }
        public int? ExtensaoPercorridaInicio { get; set; }
        public int? DistanciaDescargaGaragem { get; set; }

        public bool ColetaConvencional { get; set; }

        public TipoColeta TipoColetaConvencional { get; set; }

        public string TipoColetaEspecifica { get; set; }

        public bool RealizaTransbordo { get; set; }


        public int? TransbordoID { get; set; }
        public TBTransbordo Transbordo { get; set; }


        public bool RealizaAterro { get; set; }

        public int? AterroID { get; set; }
        public TBAterro Aterro { get; set; }


        public int? DestinadorID{ get; set; }
        public TBPrestadoraServico Destinador { get; set; }

        //public int? ResiduoColetadoID { get; set; }
        public string nmResiduoColetado { get; set; }
        public string Observacao { get; set; }
        public bool bAtivo { get; set; }
        [NotMapped]
        public int TotalColetado { get { return TBColetaExecutadaDetalhadas.Sum(x => (int) x.QtResiduo); }}
        public virtual ICollection<TBColetaExecutadaDetalhada> TBColetaExecutadaDetalhadas { get; set; }
        public virtual TBColetaEventual TBColetaEventual { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
    }
}