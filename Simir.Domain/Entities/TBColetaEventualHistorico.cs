using System;
using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBColetaEventualHistorico : Historico<TBColetaEventual>
    {
        public int ColetaEventualHistoricoID { get; set; }
        public int? ColetaEventualID { get; set; }
        public int? PrefeituraID { get; set; }
        public int? PrestadoraServicosID { get; set; }
        public int? RotasID { get; set; }
        public DateTime? dtColeta { get; set; }
        public int? DistanciaInicial { get; set; }
        public int? DistanciaFinal { get; set; }
        public int? qtGari { get; set; }
        public string nmColetaEventual { get; set; }
        public bool? bColetaOrdinaria { get; set; }
        public int? qtColetaDia { get; set; }
        public bool? bAtivo { get; set; }

        public override void To(TBColetaEventual pricipal)
        {
            ColetaEventualID = pricipal.ColetaEventualID;
            PrefeituraID = pricipal.PrefeituraID;
            PrestadoraServicosID = pricipal.PrestadoraServicosID;
            RotasID = pricipal.RotasID;
            dtColeta = pricipal.dtColeta;
            DistanciaInicial = pricipal.DistanciaInicial;
            DistanciaFinal = pricipal.DistanciaFinal;
            qtGari = pricipal.qtGari;
            nmColetaEventual = pricipal.nmColetaEventual;
            bColetaOrdinaria = pricipal.bColetaOrdinaria;
            qtColetaDia = pricipal.qtColetaDia;
            bAtivo = pricipal.bAtivo;
        }
    }
}