using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels.ColetaTransporteMVs
{
    public class ColetaTransporteVM
    {
        public ColetaTransporteVM()
        {
            TipoListaValor = "-1";
            TipoListaDescricao = "Classifique o tipo de lista...";

            RamoValor = "-1";
            RamoDescricao = "Classifique a Atividade...";

            ClassificacaoResiduoValor = "-1";
            ClassificacaoResiduoDescricao = "Classifique o resíduo...";

            Residuos = new List<ResiduosEditVM>();
        }
        public int ColetaTransporteID { get; set; }

        [Display(Name = "Mês Referência")]
        [StringLength(7)]
        [InputMask("99/9999")]
        [Required(ErrorMessage = "Mês Referência é obrigatório")]
        [RegularExpression(@"^\d{2}/\d{4}$", ErrorMessage = "Data inválida")]
        public string DataColeta { get; set; }


        [Display(Name = "Realizou Transbordo?")]
        public bool RealizouTransbordo { get; set; }

        [Display(Name = "CNPJ da empresa de Transbordo")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        [CustomValidationCNPJ]
        public string TransbordoCnpj { get; set; }


        [Display(Name = "Tipo de Lista")]
        [StringLength(20)]
        public string TipoListaValor { get; set; }

        public string TipoListaDescricao { get; set; }

        [Display(Name = "Atividade")]
        [StringLength(20)]
        public string RamoValor { get; set; }

        public string RamoDescricao { get; set; }

        [Display(Name = "Classificação dos RSS, RSU e RCC")]
        [StringLength(30)]
        public string ClassificacaoResiduoValor { get; set; }

        public string ClassificacaoResiduoDescricao { get; set; }
        public IList<ResiduosEditVM> Residuos { get; set; }

        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        [CustomValidationCNPJ]
        public string GeradoraCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string GeradoraSocial { get; set; }

        [Display(Name = "Nome do Responsável")]
        public string NomeResponsavel { get; set; }

        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        [CustomValidationCNPJ]
        public string DestinoCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string DestinoRazaoSocial { get; set; }

        public ICollection<MtrVM> Mtrs { get; set; }

        public static ColetaTransporteVM Fake()
        {
            return new ColetaTransporteVM
            {
                Residuos = new List<ResiduosEditVM>
                {
                    new ResiduosEditVM
                    {
                        Nome = "Teste",
                        Descricao = "123 teste, teste, som",
                        Quantidade = 21333,
                        Medida = true
                    },
                    new ResiduosEditVM
                    {
                        Nome = "Teste2",
                        Descricao = "123 teste, teste, som",
                        Quantidade = 144,
                        Medida = true
                    }
                },
                Mtrs = new List<MtrVM>()
            };
        }

        internal static ColetaTransporteVM ToView(TBResiduosColetado model)
        {
            return new ColetaTransporteVM
            {
                DataColeta = model.dtMesReferencia.ToString("MM/yyyy"),
                ColetaTransporteID = model.ResiduosColetadosID,
                RealizouTransbordo = model.RealizouTransbordo,
                TransbordoCnpj = model.CNPJTransbordo,
                Residuos = ResiduosEditVM.ToView(model.Itens),
                GeradoraCnpj = model.CnpjGeradora,
                GeradoraSocial = model.nmRazaoSocialGeradora,
                NomeResponsavel = model.nmPessoaLiberouColeta,
                DestinoCnpj = model.CNPJDestinadora,
                DestinoRazaoSocial = model.RazaoSocialDestinadora
            };
        }


    }
}