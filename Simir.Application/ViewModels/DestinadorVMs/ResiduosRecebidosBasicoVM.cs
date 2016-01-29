using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels.DestinadorVMs
{
    public class ResiduosRecebidosBasicoVM
    {
        public int Id { get; set; }

        [Display(Name = @"Data da Coleta")]
        public string DataColetada { get; set; }


        [Display(Name = @"Qtde")]
        public double Quantidade { get; set; }

        [Display(Name = @"Empresa Transportadora")]
        public string EmpresaTransportadora { get; set; }

        [Display(Name = @"Empresa Transbordo")]
        public string EmpresaTransbordo { get; set; }

        [Display(Name = @"Realizou Transbordo?")]
        public bool Transbordou { get; set; }



        internal static ICollection<ResiduosRecebidosBasicoVM> ToView(IList<TBResiduosDestinadore> list)
        {
            return list.Select(ToView).ToList();
        }

        private static ResiduosRecebidosBasicoVM ToView(TBResiduosDestinadore model)
        {
            return new ResiduosRecebidosBasicoVM()
            {
                Id = model.ResiduosDestinadoresID,
                Quantidade = model.Itens.Sum(x=>x.qtResiduo),
                EmpresaTransportadora = model.nmRazaoSocialTransportadora,
                EmpresaTransbordo = model.nmRazaoSocialTransbordo,
                Transbordou = model.RealizouTransbordo,
                DataColetada = model.dtMesReferencia.ToString("MM/yy")
            };
        }
    }
}