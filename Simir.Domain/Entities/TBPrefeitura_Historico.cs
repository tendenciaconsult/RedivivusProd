using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBPrefeitura_Historico : Historico<TBPrefeitura>
    {
        public int Prefeitura_HistoricoID { get; set; }
        public int PrefeituraID { get; set; }
        public string nmPrefeitura { get; set; }
        public string nmPrefeito { get; set; }
        public string CNPJ { get; set; }
        public string Site { get; set; }
        public int? qtHabitantesHurbanos { get; set; }
        public int? qthabitantesTotalAtendido { get; set; }
        public int? qthabitantesAtendidoColetaDomiciliar { get; set; }
        public int? qthabitantesAtendidoColetaSeletiva { get; set; }
        public int? EnderecoID { get; set; }

        public override void To(TBPrefeitura pre)
        {
            PrefeituraID = pre.PrefeituraID;
            nmPrefeitura = pre.nmPrefeitura;
            nmPrefeito = pre.nmPrefeito;
            CNPJ = pre.CNPJ;
            Site = pre.Site;
            qtHabitantesHurbanos = pre.qtHabitantesUrbanos;
            qthabitantesTotalAtendido = pre.qthabitantesTotalAtendido;
            qthabitantesAtendidoColetaDomiciliar = pre.qthabitantesAtendidoColetaDomiciliar;
            qthabitantesAtendidoColetaSeletiva = pre.qthabitantesAtendidoColetaSeletiva;
            EnderecoID = pre.EnderecoID;
        }
    }
}