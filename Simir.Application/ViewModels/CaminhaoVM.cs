using System;
using System.Collections.Generic;
using System.Linq;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels
{
    public class CaminhaoVM
    {
        public int EquipamentoID { get; set; }
        public string nmEquipamento { get; set; }
        public string qtEquipamento { get; set; }
        public string Volume { get; set; }
        public int Status { get; set; }

        internal static IList<CaminhaoVM> ToView(ICollection<TBPrestadoraServicosCaminhao> collection)
        {
            return collection.Select(x => ToView(x)).ToList();
        }

        internal static CaminhaoVM ToView(TBPrestadoraServicosCaminhao item)
        {
            return new CaminhaoVM
            {
                EquipamentoID = item.PrestadoraServicosEquipamentosID,
                nmEquipamento = item.nmEquipamento,
                qtEquipamento = item.qtEquipamento.ToString(),
                Volume = item.Volume.ToString(),
                Status = 1
            };
        }

        internal static void ToEquipamento(ref TBPrestadoraServicosCaminhao equip, CaminhaoVM item)
        {
            if (equip == null)
            {
                equip = new TBPrestadoraServicosCaminhao();
                equip.PrestadoraServicosEquipamentosID = 0;
            }

            equip.nmEquipamento = item.nmEquipamento;
            equip.qtEquipamento = Int32.Parse(item.qtEquipamento);
            equip.Volume = Int32.Parse(item.Volume);
        }

        internal static IList<CaminhaoVM> ToViewColetaOrdinaria(ICollection<TBEquipamentoColetaOrdinaria> collection)
        {
            return collection.Select(x => ToViewColetaOrdinaria(x)).ToList();
        }

        internal static CaminhaoVM ToViewColetaOrdinaria(TBEquipamentoColetaOrdinaria item)
        {
            return new CaminhaoVM
            {
                EquipamentoID = item.EquipamentoColetaOrdinariaID,
                nmEquipamento = item.nmEquipamento,
                qtEquipamento = item.qtEquipamento.ToString(),
                Volume = item.Volume.ToString(),
                Status = 1
            };
        }

        internal static IList<CaminhaoVM> ToViewColetaEventual(ICollection<TBEquipamentoColetaEventual> collection)
        {
            return collection.Select(x => ToViewColetaEventual(x)).ToList();
        }

        internal static CaminhaoVM ToViewColetaEventual(TBEquipamentoColetaEventual item)
        {
            return new CaminhaoVM
            {
                EquipamentoID = item.EquipamentoColetaEventualID,
                nmEquipamento = item.nmEquipamento,
                qtEquipamento = item.qtEquipamento.ToString(),
                Volume = item.Volume.ToString(),
                Status = 1
            };
        }
    }
}