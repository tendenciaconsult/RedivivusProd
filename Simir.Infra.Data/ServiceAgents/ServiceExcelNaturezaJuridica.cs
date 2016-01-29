using System;
using LinqToExcel;

namespace Simir.Infra.Data.ServiceAgents
{
    public class ServiceExcelNaturezaJuridica : IDisposable
    {
        private readonly ExcelQueryFactory _excel;

        public ServiceExcelNaturezaJuridica()
        {
            _excel =
                new ExcelQueryFactory(
                    @"E:\Mogai\Tendencia\03. Projeto do Sistema\Simir\Simir.Infra.Data\ServiceAgents\Tipos_naturezaJuridica.xls");
        }

        /*
        public IEnumerable<NaturezaJuridica> GetAllNaturezaJuridica()
        {
            var query =
                (from row in _excel.Worksheet("dtb_2013")
                 where row["a"].Cast<string>() != null
                 let item = new NaturezaJuridica()
                {
                    NaturezaJuridicaId = int.Parse(Regex.Replace(row["a"].Cast<string>(), @"\D","")),
                    Nome = row["b"].Cast<string>(),
                    //Nome = Regex.Match(row["a"].Cast<string>(), @"\d+").Value,
                    Representante = row["c"].Cast<string>(),
                    Qualificacao = row["e"].Cast<string>().Substring(3),
                    NaturezaJuridicaTipo = (NaturezaJuridicaTipo)int.Parse(row["a"].Cast<string>().Substring(0,1))
                }
                select item);

            return query;

        }*/

        public void Dispose()
        {
            _excel.Dispose();
        }
    }
}