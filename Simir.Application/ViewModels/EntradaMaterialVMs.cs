using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Simir.Application.ViewModels
{
    public class EntradaMaterialBasicoVM
    {
        public int Id { get; set; }

        [DisplayName("Nome da Geradora")]
        public string NomeGeradora { get; set; }

        [DisplayName("Variedade")]
        public int TipoDiferentes { get; set; }

        [DisplayName("Data")]
        public DateTime DiaHora { get; set; }

        [DisplayName("Misturado?")]
        public string NivelMisturado { get; set; }

        [DisplayName("Local")]
        public string Local { get; set; }

        [DisplayName("Peso (em kg)")]
        public int PesoTotal { get; set; }
    }

    public class DetalheEntradaMaterialVM
    {
        [DisplayName("Geradora")]
        public string Geradora { get; set; }

        [DisplayName("Nível de mistura (0-9)")]
        public int NivelMisturado { get; set; }

        [DisplayName("Local Depositado")]
        public string Local { get; set; }

        [DisplayName("Data e Hora da Entrada")]
        public string DiaHora { get; set; }

        [DisplayName("Peso Total (em kg)")]
        public int PesoTotal { get; set; }

        public virtual IList<DetalheResiduoVM> Residuos { get; set; }
    }

    public class DetalheResiduoVM
    {
        [DisplayName("Peso (em kg)")]
        public int Peso { get; set; }

        [DisplayName("Tipo de resíduo")]
        public string TipoResiduo { get; set; }

        [DisplayName("É perigoso?")]
        public string IsPerigoso { get; set; }
    }

    public class NovaEntradaMaterialVM
    {
        [DisplayName("Geradora")]
        public int GeradoraId { get; set; }

        public virtual IList<ResiduoVM> Residuos { get; set; }

        [DisplayName("Nível de mistura (0-9)")]
        [Range(0, 9, ErrorMessage = "{0} não está entra {1} e {2}")]
        public int NivelMisturado { get; set; }

        [DisplayName("Local Depositado")]
        [Required]
        public string Local { get; set; }

        [DisplayName("Data e Hora da Entrada")]
        [Required]
        public DateTime DiaHora { get; set; }
    }


    public class ResiduoVM
    {
        public int ResiduoId { get; set; }

        [DisplayName("Peso (em kg)")]
        [Range(1, 2000000, ErrorMessage = "O peso deve ser maior que {1}kg e menor que {2}kg.")]
        public int Peso { get; set; }

        public bool Delete { get; set; }

        [DisplayName("Tipo de resíduo por capítulo")]
        public int TipoResiduoCapituloId { get; set; }

        [DisplayName("Tipo de resíduo por subcapítulo")]
        public int TipoResiduoSubcapituloId { get; set; }

        [DisplayName("Tipo de resíduo detalhado")]
        public int TipoResiduoDetalheId { get; set; }

        internal int GetIdMaiorDetalhe()
        {
            if (TipoResiduoDetalheId != 0)
                return TipoResiduoDetalheId;
            if (TipoResiduoSubcapituloId != 0)
                return TipoResiduoSubcapituloId;
            return TipoResiduoCapituloId;
        }
    }
}