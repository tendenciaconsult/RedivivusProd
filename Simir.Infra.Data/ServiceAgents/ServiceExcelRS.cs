using System;
using System.Text.RegularExpressions;
using LinqToExcel;

namespace Simir.Infra.Data.ServiceAgents
{
    public class ServiceExcelRS : IDisposable
    {
        private readonly ExcelQueryFactory _excel;

        public ServiceExcelRS()
        {
            _excel =
                new ExcelQueryFactory(
                    @"E:\Mogai\Tendencia\03. Projeto do Sistema\Simir\Simir.Infra.Data\ServiceAgents\Lista_RS.xlsx");
        }

        public void Dispose()
        {
            _excel.Dispose();
        }
    }


    internal class CapituloAux
    {
        //private string _id_str;
        private readonly string _codigo;
        private readonly string _descri;
        private readonly bool _isPerigoso;

        public CapituloAux(string id_str, string descri)
        {
            id_str = id_str ?? "";
            _codigo = Regex.Replace(id_str, @"\D", "");
            if (_codigo.Length == 1) _codigo = "0" + _codigo;
            descri = descri ?? "";
            descri = descri.TrimStart(' ');
            if (descri.Length > 3 && descri.Substring(0, 3) == "(*)")
            {
                _isPerigoso = true;
                descri = descri.Remove(0, 3);
            }
            descri = descri.TrimStart(' ');
            _descri = descri.TrimEnd(' ', ':', '–', '-');
            /*
            if (descri.Length > 1
                && (descri.Substring(descri.Length - 1) == ":"
                    || descri.Substring(descri.Length - 1) == "–"))
                _descri = descri.Remove(descri.Length - 1);
            else
                _descri = descri;
             */
        }

        internal string Decricao()
        {
            return _descri;
        }

        internal int TipoResiduoCapituloId()
        {
            if (_codigo.Length == 1 || _codigo.Length == 2)
                return int.Parse(_codigo);
            return 0;
        }

        internal int TipoResiduoSubcapituloId()
        {
            if (_codigo.Length == 4)
                return int.Parse(_codigo);
            return 0;
        }

        internal int TipoResiduoDetalheId()
        {
            if (_codigo.Length == 6)
                return int.Parse(_codigo);
            return 0;
        }

        internal bool IsPerigoso()
        {
            return _isPerigoso;
        }

        internal int GetTipoResiduoCapituloId()
        {
            return TipoResiduoSubcapituloId()/100;
        }

        internal int GetTipoResiduoSubcapituloId()
        {
            return (TipoResiduoDetalheId()/100);
        }

        internal string Codigo()
        {
            return _codigo;
        }
    }
}