using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class PrefeituraVM
    {
        public int PrefeituraID { get; set; }

        [Display(Name = "Nome da Prefeitura")]
        public string Nome { get; set; }

        [Display(Name = "Nome do Prefeito")]
        public string Prefeito { get; set; }

        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Display(Name = "Site próprio", Description = "ex.: www.tendenciaconsult.com.br")]
        public string Site { get; set; }

        [Display(Name = "Habitantes Urbanos")]
        public int qtHabitantesUrbanos { get; set; }

        [Display(Name = "População total atendida")]
        public int qthabitantesTotalAtendido { get; set; }

        [Display(Name = "Atendida porta-a-porta")]
        public int qthabitantesAtendidoColetaDomiciliar { get; set; }

        [Display(Name = "Atendida com coleta seletiva")]
        public int qthabitantesAtendidoColetaSeletiva { get; set; }

        [Display(Name = "Endereço")]
        public string EnderecoCurto { get; set; }

        public static PrefeituraVM Fake
        {
            get { return new PrefeituraVM(); }
        }

        public static PrefeituraVM ToView(TBPrefeitura prefeitura)
        {
            return new PrefeituraVM
            {
                PrefeituraID = prefeitura.PrefeituraID,
                Nome = prefeitura.nmPrefeitura,
                Prefeito = prefeitura.nmPrefeito,
                CNPJ = prefeitura.CNPJ,
                Site = prefeitura.Site,
                qtHabitantesUrbanos = prefeitura.qtHabitantesUrbanos == null? 0: (int)prefeitura.qtHabitantesUrbanos,
                qthabitantesTotalAtendido = prefeitura.qthabitantesTotalAtendido == null ? 0 : (int)prefeitura.qthabitantesTotalAtendido,
                qthabitantesAtendidoColetaDomiciliar = prefeitura.qthabitantesAtendidoColetaDomiciliar == null ? 0 : (int)prefeitura.qthabitantesAtendidoColetaDomiciliar,
                qthabitantesAtendidoColetaSeletiva = prefeitura.qthabitantesAtendidoColetaSeletiva == null ? 0 : (int)prefeitura.qthabitantesAtendidoColetaSeletiva,
                EnderecoCurto = EnderecoVM.ToViewSimples(prefeitura.TBEndereco)
            };
        }
    }

    public class PrefeituraEditarVM
    {
        public int PrefeituraID { get; set; }

        [Display(Name = "Nome da Prefeitura")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Nome do Prefeito", Description = "Atual Prefeito")]
        [StringLength(100)]
        public string Prefeito { get; set; }

        [Required(ErrorMessage = "Digite o CNPJ")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        [CustomValidationCNPJ]
        public string CNPJ { get; set; }

        [RegularExpression(@"^(http[s]?://)?(www\.)?[a-zA-Z0-9-\.]+\.(com|org|net|mil|edu|ca|co.uk|com.au|gov|br)$",
            ErrorMessage = "Url inválida")]
        [Display(Name = "Site próprio", Description = "ex.: www.tendenciaconsult.com.br")]
        [StringLength(100)]
        public string Site { get; set; }

        [Display(Name = "Quantidade de Habitantes Urbanos")]
        [InputMask("99999999", IsReverso = true, Final = "pessoas")]
        public double qtHabitantesUrbanos { get; set; }

        [MaximoValidator("qtHabitantesUrbanos", "naotem", ErrorMessage = "A População total atendida no município não podem ser maior que a {1}")]
        [Display(Name = "População total atendida no município")]
        [InputMask("99999999", IsReverso = true, Final = "pessoas")]
        public double qthabitantesTotalAtendido { get; set; }

        [MaximoValidator("qthabitantesTotalAtendido", "naotem", ErrorMessage = "A População urbana atendida pelo serviço de coleta domiciliar direta, ou seja, porta-a-porta não podem ser maior que a {1}")]
        [Display(Name = "População urbana atendida pelo serviço de coleta domiciliar direta, ou seja, porta-a-porta")]
        [InputMask("99999999", IsReverso = true, Final = "pessoas")]
        public double qthabitantesAtendidoColetaDomiciliar { get; set; }

        [MaximoValidator("qthabitantesTotalAtendido", "naotem", ErrorMessage = "A População urbana do município atendida com a coleta seletiva do tipo porta-a-porta executada pela Prefeitura (ou SLU) não podem ser maior que a {1}")]
        [Display(Name = "População urbana do município atendida com a coleta seletiva do tipo porta-a-porta executada pela Prefeitura (ou SLU)")]
        [InputMask("99999999", IsReverso = true, Final = "pessoas")]
        public double qthabitantesAtendidoColetaSeletiva { get; set; }

        public virtual EnderecoVM Endereco { get; set; }

        internal static PrefeituraEditarVM ToView(TBPrefeitura prefeitura)
        {
            return new PrefeituraEditarVM
            {
                PrefeituraID = prefeitura.PrefeituraID,
                Nome = prefeitura.nmPrefeitura,
                Prefeito = prefeitura.nmPrefeito,
                CNPJ = prefeitura.CNPJ,
                Site = prefeitura.Site,
                qtHabitantesUrbanos = prefeitura.qtHabitantesUrbanos == null ? 0 : (int)prefeitura.qtHabitantesUrbanos,
                qthabitantesTotalAtendido = prefeitura.qthabitantesTotalAtendido == null ? 0 : (int)prefeitura.qthabitantesTotalAtendido,
                qthabitantesAtendidoColetaDomiciliar = prefeitura.qthabitantesAtendidoColetaDomiciliar == null ? 0 : (int)prefeitura.qthabitantesAtendidoColetaDomiciliar,
                qthabitantesAtendidoColetaSeletiva = prefeitura.qthabitantesAtendidoColetaSeletiva == null ? 0 : (int)prefeitura.qthabitantesAtendidoColetaSeletiva,
                Endereco = EnderecoVM.ToView(prefeitura.TBEndereco)
            };
        }
    }
}