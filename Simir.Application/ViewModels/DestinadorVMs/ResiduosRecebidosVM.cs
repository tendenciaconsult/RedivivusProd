using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels.DestinadorVMs
{
    public class ResiduosRecebidosVM
    {
        public ResiduosRecebidosVM()
        {
            TipoListaValor = "-1";
            TipoListaDescricao = "Classifique o tipo de lista...";

            RamoValor = "-1";
            RamoDescricao = "Classifique o ramo...";

            ClassificacaoResiduoValor = "-1";
            ClassificacaoResiduoDescricao = "Classifique o resíduo...";

            Residuos = new List<ResiduosEditVM>();
        }
        public int ResiduosRecebidosID { get; set; }

        [Display(Name = "Tipo de Lista")]
        [StringLength(20)]
        public string TipoListaValor { get; set; }
        public string TipoListaDescricao { get; set; }

        [Display(Name = "Ramo")]
        [StringLength(20)]
        public string RamoValor { get; set; }
        public string RamoDescricao { get; set; }

        [Display(Name = "Classificação dos RSS, RSU e RCC")]
        [StringLength(30)]
        public string ClassificacaoResiduoValor { get; set; }
        public string ClassificacaoResiduoDescricao { get; set; }

        public IList<ResiduosEditVM> Residuos { get; set; }


        [Display(Name = "CNPJ")]
        public string TransportadoraCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string TransportadoraSocial { get; set; }


        [Display(Name = "De onde veio o resíduo?")]
        public bool DePrefeitura { get; set; }

        [Display(Name = "Realizou Transbordo?")]
        public bool RealizouTransbordo { get; set; }

        [Display(Name = "CNPJ")]
        public string TransbordoCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string TransbordoSocial { get; set; }

        [Display(Name = @"Mês Referência")]
        [StringLength(7)]
        [InputMask("99/9999")]
        [Required(ErrorMessage = @"Mês Referência é obrigatório")]
        [RegularExpression(@"^\d{2}/\d{4}$", ErrorMessage = @"Data inválida")]
        public string DataEntrega { get; set; }
        

        public static ResiduosRecebidosVM Fake()
        {
            return new ResiduosRecebidosVM
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
                }
            };
        }

        internal static ResiduosRecebidosVM ToView(TBResiduosDestinadore model)
        {
            return new ResiduosRecebidosVM
            {
                DataEntrega = model.dtMesReferencia.ToString("MM/yyyy"),
                ResiduosRecebidosID = model.ResiduosDestinadoresID,
                RealizouTransbordo = model.RealizouTransbordo,
                TransbordoCnpj = model.CNPJTransbordo,
                TransbordoSocial = model.nmRazaoSocialTransbordo,
                Residuos = ResiduosEditVM.ToView(model.Itens),
                TransportadoraCnpj = model.CNPJTransportadora,
                TransportadoraSocial = model.nmRazaoSocialTransportadora,
                DePrefeitura = model.DePrefeitura
            };
        }
    }
}