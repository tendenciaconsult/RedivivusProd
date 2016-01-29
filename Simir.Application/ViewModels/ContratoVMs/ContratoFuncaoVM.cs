

using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Simir.Domain.Entities;
using Simir.Application.Helpers;
using System.Collections.Generic;

namespace Simir.Application.ViewModels.ContratoVMs
{
    public class ContratoFuncaoVM
    {
        public ContratoFuncaoVM()
        {
            

        }
        public int ID { get; set; }
        public string ContratoFuncaoTipo { get; set; }
        public string ContratoFuncaoSubTipoValor { get; set; }
        public string ContratoFuncaoSubTipoDescricao { get; set; }
        public string ValorPagoPorFunc { get; set; }
        public string EncargoPagoPorFunc { get; set; }
        public string Quantidade { get; set; }



        public int Status { get; set; }

        internal static TBServicoFuncionario ToModel(ContratoFuncaoVM item)
        {
            return new TBServicoFuncionario()
            {
                ContratoID = item.ID,
                qtFuncionarios = int.Parse( item.Quantidade),
                vlEncargoPorFuncionario =  NullableHelper.ParseNullable<decimal>(item.EncargoPagoPorFunc, Decimal.TryParse),
                vlPorFuncionario = NullableHelper.ParseNullable<decimal>(item.ValorPagoPorFunc, Decimal.TryParse),
                ServicoFuncaoSubtituloID = int.Parse(item.ContratoFuncaoSubTipoValor)
            };
        }

        internal static IList<ContratoFuncaoVM> ToView(IList<TBServicoFuncionario> enumerable)
        {
            return enumerable.Select(x => ToView(x)).ToList();
        }

        private static ContratoFuncaoVM ToView(TBServicoFuncionario x)
        {
            return new ContratoFuncaoVM()
            {
                ID = x.ContratoID,
                ContratoFuncaoTipo = x.ServicoFuncaoSubtitulo.ServicoFuncaoTitulo.nmServicoFuncaoTitulo,
                ContratoFuncaoSubTipoValor = x.ServicoFuncaoSubtituloID.ToString(),
                ContratoFuncaoSubTipoDescricao = x.ServicoFuncaoSubtitulo.nmServicoFuncaoSubtitulo,
                ValorPagoPorFunc = x.vlPorFuncionario.ToString(),
                EncargoPagoPorFunc = x.vlEncargoPorFuncionario.ToString(),
                Quantidade = x.qtFuncionarios.ToString(),
                Status = 1
            };
        }
    }
}
