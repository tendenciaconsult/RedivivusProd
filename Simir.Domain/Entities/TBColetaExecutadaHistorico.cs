using System;
using Simir.Domain.Helpers;
using Simir.Domain.Enuns;

namespace Simir.Domain.Entities
{
    public class TBColetaExecutadaHistorico : Historico<TBColetaExecutada>
    {
        public int ColetaExecutadaHistoricoID { get; set; }
        public int? ColetaExecutadaID { get; set; }
        public string nmProgramacao { get; set; }
        public DateTime dtReferencia { get; set; }
        public int PrefeituraID { get; set; }
        public int ColetaEventualID { get; set; }
        public bool bColetaRealizada { get; set; }
        public string Motivo { get; set; }
        public string HoraSaidaGaragem { get; set; }
        public string HoraChegadaGaragem { get; set; }
        public int? qtGaris { get; set; }
        public int? ExtensaoPercorridaInicio { get; set; }
        public int? DistanciaDescargaGaragem { get; set; }
        public string nmResiduoColetado { get; set; }
        public string Observacao { get; set; }
        public bool bAtivo { get; set; }


        public TipoColeta TipoColetaConvencional { get; set; }
        public string TipoColetaEspecifica { get; set; }
        public bool RealizaTransbordo { get; set; }
        public int? TransbordoID { get; set; }
        public bool RealizaAterro { get; set; }
        public int? AterroID { get; set; }
        public int? DestinadorID { get; set; }

        public override void To(TBColetaExecutada pricipal)
        {
            ColetaExecutadaID = pricipal.ColetaExecutadaID;
            nmProgramacao = pricipal.nmProgramacao;
            dtReferencia = pricipal.dtReferencia;
            PrefeituraID = pricipal.PrefeituraID;
            bColetaRealizada = pricipal.bColetaRealizada;
            Motivo = pricipal.Motivo;
            HoraSaidaGaragem = pricipal.HoraSaidaGaragem;
            HoraChegadaGaragem = pricipal.HoraChegadaGaragem;
            qtGaris = pricipal.qtGaris;
            ExtensaoPercorridaInicio = pricipal.ExtensaoPercorridaInicio;
            DistanciaDescargaGaragem = pricipal.ColetaExecutadaID;
            nmResiduoColetado = pricipal.nmResiduoColetado;
            Observacao = pricipal.Observacao;
            bAtivo = pricipal.bAtivo;

            TipoColetaConvencional = pricipal.TipoColetaConvencional;
            TipoColetaEspecifica = pricipal.TipoColetaEspecifica;
            RealizaTransbordo = pricipal.RealizaTransbordo;
            TransbordoID = pricipal.TransbordoID;
            AterroID = pricipal.AterroID;
            DestinadorID = pricipal.DestinadorID;
            RealizaAterro = pricipal.RealizaAterro;
        }
    }
}