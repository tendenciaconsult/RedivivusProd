using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Application.Helpers;

namespace Simir.Application.ViewModels.ContratoVMs
{
    public class ContratoVeiculoVM
    {
        public int ID { get; set; }

        public string Tipo { get; set; }
        public string Placa { get; set; }
        public string Capacidade { get; set; }
        public string DataFabrica { get; set; }
        public string DataLimiteUso { get; set; }
        public int Status { get; set; }

        internal static TBContratoVeiculo ToModel(ContratoVeiculoVM item)
        {
            return new TBContratoVeiculo()
            {
                ContratoID = item.ID,
                Tipo = item.Tipo,
                Placa = item.Placa,
                Capacidade = NullableHelper.ParseNullable<int>(item.Capacidade, int.TryParse),
                DataFabrica = NullableHelper.ParseNullable<DateTime>(item.DataFabrica, DateTime.TryParse),
                DataLimiteUso = NullableHelper.ParseNullable<DateTime>(item.DataLimiteUso, DateTime.TryParse)

            };
        }

        internal static IList<ContratoVeiculoVM> ToView(List<TBContratoVeiculo> list)
        {
            return list.Select(x => ToView(x)).ToList();
        }

        private static ContratoVeiculoVM ToView(TBContratoVeiculo x)
        {
            return new ContratoVeiculoVM(){
                ID = x.ContratoVeiculoID,
                Tipo = x.Tipo,
                Placa = x.Placa,
                Capacidade = x.Capacidade.ToString(),
                DataFabrica = x.DataFabrica.ToString(),
                DataLimiteUso = x.DataLimiteUso.ToString(),
                Status = 1
            };
        }
    }
}
