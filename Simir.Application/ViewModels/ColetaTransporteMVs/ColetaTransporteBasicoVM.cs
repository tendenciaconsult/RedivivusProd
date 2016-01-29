using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels.ColetaTransporteMVs
{
    public class ColetaTransporteBasicoVM
    {

        
        public int Id { get; set; }

        [Display(Name = "Data da Coleta")]
        public string DataColetada { get; set; }

        [Display(Name = "Qtde")]
        public double Quantidade { get; set; }

        [Display(Name = "Empresa Geradora")]
        public string EmpresaGeradora { get; set; }

        [Display(Name = "Empresa de Destino")]
        public string EmpresaDestino { get; set; }

        [Display(Name = "Realizou Transbordo?")]
        public bool Transbordou { get; set; }

        internal static IList<ColetaTransporteBasicoVM> ToView(IList<TBResiduosColetado> list)
        {
            return list.Select(ToView).ToList();
        }

        private static ColetaTransporteBasicoVM ToView(TBResiduosColetado arg)
        {
            return new ColetaTransporteBasicoVM
            {
                DataColetada = arg.dtMesReferencia.ToString("MM/yy"),
                EmpresaDestino = arg.RazaoSocialDestinadora,
                EmpresaGeradora = arg.nmRazaoSocialGeradora,
                Quantidade = arg.Itens.Sum(x=>x.qtResiduo),
                Transbordou = arg.RealizouTransbordo,
                Id = arg.ResiduosColetadosID
            };
        }
    }
}