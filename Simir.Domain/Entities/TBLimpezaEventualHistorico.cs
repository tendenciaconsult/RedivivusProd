using System;
using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBLimpezaEventualHistorico : Historico<TBLimpezaEventual>
    {
        public int LimpezaEventualHistoricoID { get; set; }
        public int? PrefeituraID { get; set; }
        public int? PrestadoraServicosID { get; set; }
        public int? RegiaoAdministrativaID { get; set; }
        public int? EnderecoBairroID { get; set; }
        public DateTime? dtInicio { get; set; }
        public DateTime? dtFim { get; set; }
        public int? qtTintasUtilizados { get; set; }
        public int? EnderecoLogradouroID { get; set; }
        public int? TipoProgramacao { get; set; }
        public bool? bAtivo { get; set; }
        public string nmOutroLogradouro { get; set; }
        public string nmProgramacao { get; set; }
        public int? qtGaris { get; set; }
        public bool? bServicoOrdinario { get; set; }
        public bool? bFeiraLivre { get; set; }
        public string nmTipoProgramacao { get; set; }

        public override void To(TBLimpezaEventual pricipal)
        {
            PrefeituraID = pricipal.PrefeituraID;
            PrestadoraServicosID = pricipal.PrestadoraServicosID;
            RegiaoAdministrativaID = pricipal.RegiaoAdministrativaID;
            EnderecoBairroID = pricipal.EnderecoBairroID;
            dtInicio = pricipal.dtInicio;
            dtFim = pricipal.dtFim;
            qtTintasUtilizados = pricipal.qtTintasUtilizados;
            EnderecoLogradouroID = pricipal.EnderecoLogradouroID;
            bAtivo = pricipal.bAtivo;
            nmOutroLogradouro = pricipal.nmOutroLogradouro;
            nmProgramacao = pricipal.nmProgramacao;
            qtGaris = pricipal.qtGaris;
            TipoProgramacao = pricipal.TipoProgramacao;
            bServicoOrdinario = pricipal.bServicoOrdinario;
            bFeiraLivre = pricipal.bFeiraLivre;
            nmTipoProgramacao = pricipal.nmTipoProgramacao;
        }
    }
}