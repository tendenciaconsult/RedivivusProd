using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBPrefeitura_Historico
    {
        public int Prefeitura_HistoricoID { get; set; }
        public int PrefeituraID { get; set; }
        public string nmPrefeitura { get; set; }
        public string nmPrefeito { get; set; }
        public string CNPJ { get; set; }
        public string Site { get; set; }
        public Nullable<int> qtHabitantesHurbanos { get; set; }
        public Nullable<int> qthabitantesRurais { get; set; }
        public Nullable<int> EnderecoID { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
