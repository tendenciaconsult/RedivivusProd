using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;


namespace Simir.Application.ViewModels
{

    public class AterroCadastradosVM
    {
        public AterroCadastradosVM(TBAterro x)
        {
            AterroID = x.AterroID;
            nmFantasia = x.nmFantasiaAterro;
            bAterroControlado = (x.AterroControlado == true) ? "Aterro Controlado" : "Aterro Sanitário";
            CNPJ = x.CNPJ;
        }

        public int AterroID { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string nmFantasia { get; set; }

        [Display(Name = "Tipos de Aterros")]
        public string bAterroControlado { get; set; }

        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }
    }

    public class AterroVM
    {

        public AterroVM()
        {
            Endereco = new EnderecoVM();

        }
        public int AterroID { get; set; }
        public int PrefeituraID { get; set; }

        [Display(Name = "Aterro Controlado?")]
        public bool bAterroControlado { get; set; }
        
        public string Btn { get; set; }

        [Display(Name = "Razão Social")]
        [StringLength(200)]
        public string nmRazaoSocialAterro { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Obrigatório informar o nome fantasia.")]
        [StringLength(200)]
        public string nmFantasiaAterro { get; set; }

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

        internal static AterroVM ToView(TBAterro Item)
        {
            return new AterroVM
            {
                AterroID = Item.AterroID,
                PrefeituraID = Item.PrefeituraID,
                nmFantasiaAterro = Item.nmFantasiaAterro,
                nmRazaoSocialAterro = Item.nmRazaoSocialAterro,
                CNPJ = Item.CNPJ,
                numeroLicencaOp = Item.numeroLicencaOp,
                Endereco = EnderecoVM.ToView(Item.TBEndereco)
            };
        }

    }
}
