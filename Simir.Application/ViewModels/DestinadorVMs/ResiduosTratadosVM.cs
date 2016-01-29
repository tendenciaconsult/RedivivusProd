using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels.DestinadorVMs
{
    public class ResiduosTratadosVM
    {

        public ResiduosTratadosVM()
        {
            TipoResiduoValor = "-1";
            TipoResiduoDescricao = "Selecione um tipo...";

            ResiduosNaoTratados = 0;
        }

        public int Id { get; set; }

        public double ResiduosNaoTratados { get; set; }
        public bool emLitros { get; set; }

        [Display(Name = "Resíduo")]
        [StringLength(200)]
        public string TipoResiduoValor { get; set; }

        public string TipoResiduoDescricao { get; set; }

        [Display(Name = "Data do Tratamento")]
        public int TipoDestinacao { get; set; }

        [Display(Name = "Especifique")]
        [StringLength(200)]
        public string Especifique { get; set; }

        [Display(Name = "Qtde. Reaproveitada")]
        [StringLength(20)]
        [InputMask("000000000", Final = "kg", IsReverso = true)]
        public string QuantidadeReaproveitada { get; set; }




        [Display(Name = "Qtde. Reaproveitada")]
        [InputMask("000000000", Final = "kg", IsReverso = true)]
        [MaximoValidator("ResiduosNaoTratados", "QuantidadeRejeitoInt", ErrorMessage = "A Quantidade de Reaproveitada somado com o Rejeitos não podem ser maior que a {1} kg")]
        public double QuantidadeReaproveitadaInt { get; set; }

        [Display(Name = "Qtde. Rejeito")]
        [InputMask("000000000", Final = "kg", IsReverso = true)]
        [MaximoValidator("ResiduosNaoTratados", "QuantidadeReaproveitadaInt", ErrorMessage = "A Quantidade de Rejeitos somado com o Reaproveitada não podem ser maior que a {1} kg")]
        public double QuantidadeRejeitoInt { get; set; }



        public ICollection<ResiduosRecebidosBasicoVM> ResiduosTratadosHistorico { get; set; }

        public static ResiduosTratadosVM Fake()
        {
            return new ResiduosTratadosVM
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



        internal static ResiduosTratadosVM ToView(TBResiduosTratado model)
        {
            return new ResiduosTratadosVM
            {
                Id = model.ResiduosTratadosID,
                Especifique = model.OutroTipoTratamento,
                QuantidadeReaproveitadaInt = model.qtResiduoTratado,
                QuantidadeRejeitoInt = model.qtRejeito,
                TipoDestinacao = (int)model.TipoTratamento,
                TipoResiduoValor = model.ResiduoClassificadoID.ToString(),
                TipoResiduoDescricao = model.ResiduoClassificado.Residuo.nmResiduo

            };
        }
    }
}