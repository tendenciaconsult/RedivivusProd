using System;
using Simir.Domain.Helpers;

namespace Simir.Domain.Entities
{
    public class TBPrefeitura
    {
        public int PrefeituraID { get; set; }
        public string nmPrefeitura { get; set; }
        public string nmPrefeito { get; set; }
        public string CNPJ { get; set; }
        public string Site { get; set; }
        public int? qtHabitantesUrbanos { get; set; }
        public int? qthabitantesTotalAtendido { get; set; }
        public int? qthabitantesAtendidoColetaDomiciliar { get; set; }
        public int? qthabitantesAtendidoColetaSeletiva { get; set; }
        public int? EnderecoID { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }

        internal bool Validar()
        {
            if (Help.CnpjValido(CNPJ))
            {
                return true;
            }
            throw new ArgumentException(MensagensErro.cnpjInvalido, "Cnpj");
        }
    }
}