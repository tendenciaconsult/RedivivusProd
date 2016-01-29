using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
namespace Simir.Application.ViewModels
{
    public class FaleConoscoVM
    {
        public string Btn { get; set; }
        public int PrefeituraID { get; set; }
        public string IdUsuario { get; set; }
        public string nmPrefeitura { get; set; }

        [Display(Name = "Assunto")]
        [Required(ErrorMessage = "Obrigatório informar o assunto")]
        public string AssuntoID { get; set; }
        public string nmAssunto { get; set; }

        [Display(Name = "Nome do solicitante")]
        [Required(ErrorMessage = "Obrigatório informar o nome do solicitante")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Email para contato")]
        [Required(ErrorMessage = "Obrigatório informar um email para contato")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Telefone para contato")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        [InputMask("(99)9999-9999")]
        public string Telefone { get; set; }


        [Display(Name = "Mensagem")]
        [Required(ErrorMessage = "Obrigatório uma mensagem de e-mail")]
        [StringLength(8000)]
        public string Descricao { get; set; }
    }
}
