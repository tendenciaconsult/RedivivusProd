using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    /*
    public class PessoaJuridicaBaseVM
    {

        [Required(ErrorMessage = "Digite o nome da empresa")]
        [DisplayName("Nome da Empresa")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o nome fantasia")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ")]
        [DisplayName("CNPJ")]
        [InputMask("99.999.999/9999-99")]
        public string Cnpj { get; set; }

        [DisplayName("Telefone")]
        [InputMask("(99)9999-9999")]
        public string Telefone1 { get; set; }

        [DisplayName("Telefone 2")]
        [InputMask("(99)9999-9999")]
        public string Telefone2 { get; set; }

        [DisplayName("Celular")]
        [InputMask("(99)99999-9999")]
        public string Telefone3 { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [Display(Name="E-mail para contato", Description = "este e-mail será utilizado para confrmar a conta.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(50)]
        public string Email { get; set; }


    }

    */


    public class EmpresaBuscaVM
    {
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Digite o nome da empresa")]
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ")]
        [DisplayName("CNPJ")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        public string Cnpj { get; set; }

        public static EmpresaBuscaVM ToView(TBEmpresa emp)
        {
            return new EmpresaBuscaVM
            {
                EmpresaId = emp.EmpresaID,
                Cnpj = emp.CNPJ,
                RazaoSocial = emp.nmRazaoSocial
            };
        }
    }


    public class EmpresaNovaVM
    {
        public EmpresaNovaVM()
        {
            Endereco = new EnderecoVM();

            RamoEmpresaValor = "";
            RamoEmpresaDescricao = "Selecione o tipo da empresa...";

            PorteEmpresaValor = "";
            PorteEmpresaDescricao = "Selecionar o Porte da empresa...";

            //TipoEmpresaOpcoes = new SelectList(new[] { "Google", "TV", "Radio", "A friend", "Crazy bloke down the pub" });

            //TipoEmpresaSelecionados = new[] { "Google" };
        }

        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Digite o nome da empresa")]
        [DisplayName("Razão Social")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o nome fantasia")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        [CustomValidationCNPJ]
        public string Cnpj { get; set; }

        [DisplayName("Telefone")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        [InputMask("(99)9999-9999")]
        public string Telefone { get; set; }

        [DisplayName("Celular")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{5}-?\d{4}$", ErrorMessage = "Celular inválido")]
        [InputMask("(99)99999-9999")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [Display(Name = "E-mail", Description = "Este e-mail será utilizado para confrmar a conta.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirmar E-mail é obrigatório")]
        [Display(Name = "Confirmar E-mail")]
        [Compare("Email", ErrorMessage = "O E-mail e a Confirmação do E-mail não conferem")]
        [StringLength(50)]
        public string EmailConfirme { get; set; }

        [Display(Name = "Tipo de Empresa")]
        [StringLength(20)]
        [Required(ErrorMessage = "Selecione o ramo principal da empresa")]
        public string RamoEmpresaValor { get; set; }

        public string RamoEmpresaDescricao { get; set; }

        [Display(Name = "Porte da Empresa")]
        [StringLength(40)]
        [Required(ErrorMessage = "Selecione o porte da empresa")]
        public string PorteEmpresaValor { get; set; }

        public string PorteEmpresaDescricao { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [StringLength(20)]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Inscrição Municipal", Description = "Inscrição Municipal (CCM)")]
        [StringLength(20)]
        public string InscricaoMunicipal { get; set; }

        [Display(Name = "CNAE", Description = "Código CNAE")]
        [StringLength(20)]
        [Ajuda("Preencha com o CNAE principal")]
        public string Cnae { get; set; }

        [Display(Name = "Nº Alvará de Funcionamento", Description = "Número de alvará de funcionamento")]
        [StringLength(20)]
        public string Alvara { get; set; }

        [Display(Name = @"Data de Emissão do Alvará")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = @"Data inválida")]
        public string dtEmissaoAlvara { get; set; }

        [Display(Name = "Indeterminado", Description = "Data de vencimento de Alvará de funcionamento")]
        public bool bVencIndeterminadoAlvara { get; set; }

        [Display(Name = @"Data de Vencimento do Alvará")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = @"Data inválida")]
        public string dtVencAlvara { get; set; }

        [Display(Name = "Gerador")]
        [Ajuda("Toda a empresa que gera Resíduo Sólido no município")]
        public bool TipoEmpresaGerador { get; set; }

        [Display(Name = "Coletor/Transportador")]
        [Ajuda("Empresas que realizão serviços de Coleta e/ou Transporte para prefeitura e/ou municípo")]
        public bool TipoEmpresaColetor { get; set; }

        [Display(Name = "Tratamento de Resíduo")]
        [Ajuda("Empresas que realizão serviços de tratamento de resíduo para prefeitura e/ou municípo")]
        public bool TipoEmpresaDestinacao { get; set; }

        [Display(Name = "Receptor/Disposição Final")]
        [Ajuda("Empresas que realizão serviços de disposição final do resíduo para prefeitura e/ou municípo")]
        public bool TipoEmpresaDestinadorFinal { get; set; }

        [RegularExpression(@"^(http[s]?://)?(www\.)?[a-zA-Z0-9-\.]+\.(com|org|net|mil|edu|ca|co.uk|com.au|gov|br)$",
            ErrorMessage = "Url inválida")]
        [Display(Name = "Site próprio", Description = "ex.: www.tendenciaconsult.com.br")]
        [StringLength(100)]
        public string Site { get; set; }

        public virtual EnderecoVM Endereco { get; set; }

        public TBEmpresa ToModel()
        {
            return new TBEmpresa
            {
                Celular = Celular,
                CNAE = Cnae,
                CNPJ = Cnpj,
                Email = Email,
                InscricaoEsdatudal = InscricaoEstadual,
                InscricaoMunicipal = InscricaoMunicipal,
                Alvara = Alvara,
                dtEmissaoAlvara = NullableHelper.ParseNullable<DateTime>(dtEmissaoAlvara, DateTime.TryParse),
                bVencIndeterminadoAlvara = bVencIndeterminadoAlvara,
                dtVencAlvara = NullableHelper.ParseNullable<DateTime>( dtVencAlvara, DateTime.TryParse),

                nmFantasia = NomeFantasia,
                nmRazaoSocial = Nome,
                PorteEmpresaID = Int32.Parse(PorteEmpresaValor),
                RamoEmpresaID = Int32.Parse(RamoEmpresaValor),
                Site = Site,
                Telefone = Telefone,
                bColetorResiduo = TipoEmpresaColetor,
                bDisposicaoFinalResiduo = TipoEmpresaDestinadorFinal,
                bGeradorResiduo = TipoEmpresaGerador,
                bTratamentoResiduo = TipoEmpresaDestinacao,
                AlvaraFuncionamento = Alvara,
                TBEndereco = EnderecoVM.ToModel(Endereco)
            };
        }
    }
}