using System;
using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBRotasHistorico : Historico<TBRota>
    {
        public int RotasHistoricoID { get; set; }
        public int? RotasID { get; set; }
        public string nmRota { get; set; }
        public int? PrefeituraID { get; set; }
        public int? DistanciaGaragemRota { get; set; }
        public int? DistanciaRotaDescarregamento { get; set; }
        public int? ExtensaoRota { get; set; }
        public int? qtPopulacaoAtendida { get; set; }
        public bool bAtivo { get; set; }
        public int? LocalDestinoID { get; set; }
        public string nmLocalDestino { get; set; }

        public override void To(TBRota pricipal)
        {
            RotasID = pricipal.RotasID;
            nmRota = pricipal.nmRota;
            PrefeituraID = pricipal.PrefeituraID;
            DistanciaGaragemRota = Convert.ToInt32(pricipal.DistanciaGaragemRota);
            DistanciaRotaDescarregamento = Convert.ToInt32(pricipal.DistanciaRotaDescarregamento);
            ExtensaoRota = Convert.ToInt32(pricipal.ExtensaoRota);
            bAtivo = pricipal.bAtivo;
            qtPopulacaoAtendida = pricipal.qtPopulacaoAtendida;
            LocalDestinoID = pricipal.LocalDestinoID;
            nmLocalDestino = pricipal.nmLocalDestino;
        }
    }
}
