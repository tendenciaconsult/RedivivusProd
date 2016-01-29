using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBLimpezaEventual
    {
        public int LimpezaEventualID { get; set; }
        public int PrefeituraID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public int RegiaoAdministrativaID { get; set; }
        public int? EnderecoBairroID { get; set; }
        public DateTime? dtInicio { get; set; }
        public DateTime? dtFim { get; set; }
        public int? qtTintasUtilizados { get; set; }
        public int? EnderecoLogradouroID { get; set; }
        public bool? bAtivo { get; set; }
        public string nmOutroLogradouro { get; set; }
        public string nmProgramacao { get; set; }
        public int? qtGaris { get; set; }
        public int? TipoProgramacao { get; set; }
        public bool? bServicoOrdinario { get; set; }
        public bool bFeiraLivre { get; set; }
        public string nmTipoProgramacao { get; set; }
        public virtual TBEnderecoBairro TBEnderecoBairro { get; set; }
        public virtual TBEnderecoLogradouro TBEnderecoLogradouro { get; set; }
        public virtual TBLimpezaExecutada TBLimpezaExecutada { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
        public virtual TBRegiaoAdministrativa TBRegiaoAdministrativa { get; set; }
        public virtual ICollection<TBEquipamentoLimpezaEventual> Equipamentos { get; set; }
    }
}