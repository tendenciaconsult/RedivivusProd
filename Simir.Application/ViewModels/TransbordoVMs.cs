using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class TransbordoCadastradosVM
    {
        public TransbordoCadastradosVM(TBTransbordo x)
        {
            TransbordoID = x.TransbordoID;
            nmFantasia = x.nmFantasiaTransbordo;
            CNPJ = x.CNPJ;
        }

        public int TransbordoID { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string nmFantasia { get; set; }

        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

    }
    public class TransbordoVM
    {
        public TransbordoVM()
        {
            Endereco = new EnderecoVM();

        }
        public int TransbordoID { get; set; }
        public int PrefeituraID { get; set; }
        public string Btn { get; set; }

        [Display(Name = "Razão Social")]
        [StringLength(200)]
        public string nmRazaoSocialTransbordo { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Obrigatório informar o nome fantasia.")]
        [StringLength(200)]
        public string nmFantasiaTransbordo { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        public string CNPJ { get; set; }

        [Display(Name = "Número da Licença Operacional")]
        [Required(ErrorMessage = "O número da Licença Operacional é obrigatória")]
        [StringLength(30)]
        public string numeroLicencaOp { get; set; }

        public virtual EnderecoVM Endereco { get; set; }

        internal static TransbordoVM ToView(TBTransbordo Item)
        {
            return new TransbordoVM
            {
                TransbordoID = Item.TransbordoID,
                PrefeituraID = Item.PrefeituraID,
                nmFantasiaTransbordo = Item.nmFantasiaTransbordo,
                nmRazaoSocialTransbordo = Item.nmRazaoSocialTransbordo,
                CNPJ = Item.CNPJ,
                numeroLicencaOp = Item.numeroLicencaOp,
                Endereco = EnderecoVM.ToView(Item.TBEndereco)
            };
        }
    }
}
