using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;

namespace Simir.Application.ViewModels.DestinadorVMs
{
    public class RejeitosVM
    {
        public RejeitosVM()
        {
            RejeitosNaoTratados = 0;
        }
        public int Id { get; set; }
        public double RejeitosNaoTratados { get; set; }

        [Display(Name = "Qtde. a ser vinculada")]
        [InputMask("000000000", Final = "kg", IsReverso = true)]
        [MaximoValidator("RejeitosNaoTratados", "naotem", ErrorMessage = "A Quantidade de Rejeitos não podem ser maior que a {1}")]
        public double RejeitosASerViculado { get; set; }


        [Display(Name = "CNPJ")]
        public string ColetoraCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string ColetoraSocial { get; set; }


        [Display(Name = "CNPJ")]
        public string DestinoFinalCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string DestinoFinalSocial { get; set; }

        public ICollection<ResiduosRecebidosBasicoVM> ResiduosTratadosHistorico { get; set; }

        public static RejeitosVM Fake()
        {
            return new RejeitosVM
            {
                
                ResiduosTratadosHistorico = new List<ResiduosRecebidosBasicoVM>
                {
                    new ResiduosRecebidosBasicoVM
                    {
                        DataColetada = "01/01/2015",
                        Quantidade = 10000
                    },
                    new ResiduosRecebidosBasicoVM
                    {
                        DataColetada = "02/01/2015",
                        Quantidade = 10304
                    }
                }
            };
        }

        internal static RejeitosVM ToView(Domain.Entities.TBResiduosDestinadorRejeito model)
        {
            return new RejeitosVM
            {
                Id = model.ResiduosDestinadorRejeitoID,
                RejeitosASerViculado = model.qtRejeitoVinculado,
                ColetoraCnpj = model.CNPJTransportadora,
                ColetoraSocial = model.nmRazaoSocialTransportadora,
                DestinoFinalCnpj = model.CNPJDestinadoraFinal,
                DestinoFinalSocial = model.nmRazaoSocialDestinadoraFinal
            };
        }

    }
}