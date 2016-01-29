using System;
using LinqToExcel;

namespace Simir.Infra.Data.ServiceAgents
{
    public class ServiceExcelLogradouro : IDisposable
    {
        private readonly ExcelQueryFactory _excel;

        public ServiceExcelLogradouro()
        {
            _excel =
                new ExcelQueryFactory(
                    @"E:\Mogai\Tendencia\03. Projeto do Sistema\Simir\Simir.Infra.Data\ServiceAgents\Tipos_Logradouros.xls");
        }

        /*
        public IEnumerable<LocalidadeLogradouroTipo> GetAllLogradouroTipo()
        {
            var query =
                (from row in _excel.Worksheet("p1")
                 let item = new LocalidadeLogradouroTipo()
                {
                    LocalidadeLogradouroTipoId = row["Código"].Cast<int>(),
                    Nome = row["Descrição"].Cast<string>(),
                }
                select item);

            return query;

        }
         * */

        public void Dispose()
        {
            _excel.Dispose();
        }
    }
}