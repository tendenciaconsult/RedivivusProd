using System.ComponentModel.DataAnnotations;

namespace Simir.Application.ViewModels.DestinadorVMs
{
    public class RejeitosNaoTratadosVM
    {
        [Display(Name = "Selecionar")]
        public bool Selecionado { get; set; }

        [Display(Name = "Resíduo")]
        public string TipoResiduo { get; set; }

        [Display(Name = "Qtde. (Kg) Rejeito")]
        public int QtdeRejeito { get; set; }

        [Display(Name = "Qtde. a ser vinculada")]
        public int QtdeAVeincular { get; set; }
    }
}