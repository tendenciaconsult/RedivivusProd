using System.Linq;
using Simir.Domain.Entities;
using Simir.Application.Helpers;
using System.Collections.Generic;
using System;

namespace Simir.Application.ViewModels.ContratoVMs
{
    public class ContratoEquipamentoVM
    {
        public int ID { get; set; }
        public string TipoEquipamento { get; set; }
        public string Quantidade { get; set; }
        public int Status { get; set; }

        internal static TBContratoEquipamento ToModel(ContratoEquipamentoVM item)
        {
            return new TBContratoEquipamento()
            {
                ContratoID = item.ID,
                Tipo = item.TipoEquipamento,
                Quantidade = NullableHelper.ParseNullable<int>(item.Quantidade, int.TryParse)
            };
        }

        internal static IList<ContratoEquipamentoVM> ToView(IList<TBContratoEquipamento> list)
        {
            return list.Select(x => ToView(x)).ToList();
        }

        private static ContratoEquipamentoVM ToView(TBContratoEquipamento x)
        {
            return new ContratoEquipamentoVM()
            {
                ID = x.ContratoID,
                TipoEquipamento = x.Tipo,
                Quantidade = x.Quantidade.ToString(),
                Status = 1
            };
        }
    }
}