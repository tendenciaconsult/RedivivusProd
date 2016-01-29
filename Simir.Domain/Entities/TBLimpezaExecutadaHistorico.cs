using System;
using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBLimpezaExecutadaHistorico : Historico<TBLimpezaExecutada>
    {
        public int LimpezaExecutadaHistoricoID { get; set; }
        public int LimpezaExecutadaID { get; set; }
        public string nmLimpezaExecutada { get; set; }
        public DateTime dtProgramacao { get; set; }
        public bool ProgramacaoRealizada { get; set; }
        public string nmMotivoNaoExecucao { get; set; }
        public DateTime? dtInicio { get; set; }
        public DateTime? dtFim { get; set; }
        public int? qtGaris { get; set; }
        public int? qtSupervisor { get; set; }
        public int? qtEncarregado { get; set; }
        public string sObservacao { get; set; }

        public override void To(TBLimpezaExecutada pricipal)
        {
            LimpezaExecutadaID = pricipal.LimpezaExecutadaID;
            nmLimpezaExecutada = pricipal.nmLimpezaExecutada;
            dtProgramacao = pricipal.dtProgramacao;
            ProgramacaoRealizada = pricipal.ProgramacaoRealizada;
            nmMotivoNaoExecucao = pricipal.nmMotivoNaoExecucao;
            dtInicio = pricipal.dtInicio;
            dtFim = pricipal.dtFim;
            qtGaris = pricipal.qtGaris;
            qtSupervisor = pricipal.qtSupervisor;
            qtEncarregado = pricipal.qtEncarregado;
            sObservacao = pricipal.sObservacao;
        }
    }
}