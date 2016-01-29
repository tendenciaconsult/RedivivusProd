using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class SecretariaVM
    {
        public SecretariaVM()
        {
            Secretarias = new List<SecretariaBasicoVM>();
            ResponsabilidadesTodas = new List<SelectListItem>();
            ResponsabilidadesSuas = new List<SelectListItem>();
            Endereco = new EnderecoVM();
        }

        public string Btn { get; set; }
        public int SecretariaID { get; set; }

        [Required(ErrorMessage = "Digite o nome da Secretaria")]
        [Display(Name = "Nome da Secretaria")]
        [StringLength(250)]
        public string NomeSecretaria { get; set; }

        [Required(ErrorMessage = "Digite o nome do Secretário(a)")]
        [Display(Name = "Nome da Secretário(a)")]
        [StringLength(250)]
        public string NomeSecretario { get; set; }

        [RegularExpression(@"^(http[s]?://)?(www\.)?[a-zA-Z0-9-\.]+\.(com|org|net|mil|edu|ca|co.uk|com.au|gov|br)$",
            ErrorMessage = "Url inválida")]
        [Display(Name = "Site próprio da secretaria")]
        [StringLength(100)]
        public string SiteSecretaria { get; set; }

        [DisplayName("Telefone 1")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        [InputMask("(99)9999-9999")]
        public string Telefone1 { get; set; }

        [DisplayName("Telefone 2")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        [InputMask("(99)9999-9999")]
        public string Telefone2 { get; set; }

        [Display(Name = "E-mail", Description = "Este e-mail será utilizado para confrmar a conta.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(50)]
        public string Email { get; set; }

        public string[] ResponsabilidadesTodasIDs { get; set; }
        public IEnumerable<SelectListItem> ResponsabilidadesTodas { get; set; }
        public string[] ResponsabilidadesSuasIDs { get; set; }
        public IEnumerable<SelectListItem> ResponsabilidadesSuas { get; set; }
        public virtual EnderecoVM Endereco { get; set; }
        public ICollection<SecretariaBasicoVM> Secretarias { get; set; }

        internal static SecretariaVM ToView(TBSecretaria secretaria)
        {
            return new SecretariaVM
            {
                SecretariaID = secretaria.SecretariaID,
                NomeSecretaria = secretaria.nmSecretaria,
                NomeSecretario = secretaria.nmSecretario,
                Email = secretaria.Email,
                Telefone1 = secretaria.Telefone1,
                Telefone2 = secretaria.Telefone2,
                SiteSecretaria = secretaria.Site,
                Endereco = EnderecoVM.ToView(secretaria.TBEndereco)
            };
        }
    }

    public class SecretariaBasicoVM
    {
        public SecretariaBasicoVM(TBSecretaria x)
        {
            SecretariaID = x.SecretariaID;
            NomeSecretaria = x.nmSecretaria;
            NomeSecretario = x.nmSecretario;
        }

        public int SecretariaID { get; set; }

        [Display(Name = "Nome da Secretaria")]
        public string NomeSecretaria { get; set; }

        [Display(Name = "Nome da Secretário(a)")]
        public string NomeSecretario { get; set; }
    }
}