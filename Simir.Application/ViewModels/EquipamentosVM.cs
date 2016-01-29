using System;
using System.Collections.Generic;
using System.Linq;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class EquipamentoVM
    {
        public int EquipamentoID { get; set; }
        public string nmEquipamento { get; set; }
        public string qtEquipamento { get; set; }
        public int Status { get; set; }

        public static IList<EquipamentoVM> ToView<T>(ICollection<T> collection)
            where T : TBPrestadoraServicosEquipamento
        {
            return collection.Select(x => ToView(x)).ToList();
        }

        public static EquipamentoVM ToView(TBPrestadoraServicosEquipamento item)
        {
            return new EquipamentoVM
            {
                EquipamentoID = item.PrestadoraServicosEquipamentosID,
                nmEquipamento = item.nmEquipamento,
                qtEquipamento = item.qtEquipamento.ToString(),
                Status = 1
            };
        }

        public static void ToEquipamento<Tipo>(ref Tipo equip, EquipamentoVM item)
            where Tipo : TBPrestadoraServicosEquipamento, new()
        {
            if (equip == null)
            {
                equip = new Tipo();
                equip.PrestadoraServicosEquipamentosID = 0;
            }

            equip.nmEquipamento = item.nmEquipamento;
            equip.qtEquipamento = Int32.Parse(item.qtEquipamento);
        }

        public static IList<EquipamentoVM> ToViewLimpezaEventual<T>(ICollection<T> collection)
            where T : TBEquipamentoLimpezaEventual
        {
            return collection.Select(x => LimpezaEventual(x)).ToList();
        }

        public static EquipamentoVM LimpezaEventual(TBEquipamentoLimpezaEventual item)
        {
            return new EquipamentoVM
            {
                EquipamentoID = item.EquipamentoLimpezaEventualID,
                nmEquipamento = item.nmTipoEquipamento,
                qtEquipamento = item.Quantidade.ToString(),
                Status = 1
            };
        }
    }
}