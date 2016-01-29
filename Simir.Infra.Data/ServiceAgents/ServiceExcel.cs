using System;
using LinqToExcel;

namespace Simir.Infra.Data.ServiceAgents
{
    public class ServiceExcel : IDisposable
    {
        private readonly ExcelQueryFactory _excel;

        public ServiceExcel()
        {
            _excel =
                new ExcelQueryFactory(
                    @"E:\Mogai\Tendencia\03. Projeto do Sistema\Simir\Simir.Infra.Data\ServiceAgents\dtb_2013.xls");
        }

        /*
        public IEnumerable< LocalidadeUf> GetAllUf()
        {
            var query =
                (from row in _excel.Worksheet("dtb_2013")
                let item = new LocalidadeUf()
                {
                    LocalidadeUfId = row["Uf"].Cast<int>(),
                    Sigla = row["Nome_UF"].Cast<string>().Substring(0, 2).ToUpper(),
                    Nome = row["Nome_UF"].Cast<string>()
                }
                select item).ToList();

            return query.GroupBy(x => x.LocalidadeUfId).Select(y => y.FirstOrDefault());

        }
        public IEnumerable<LocalidadeMesorregiao> GetAllMesorregiao()
        {
            var query =
                (from row in _excel.Worksheet("dtb_2013")
                 let item = new LocalidadeMesorregiao()
                 {
                     LocalidadeMesorregiaoId = row["Mesorregião Geográfica"].Cast<int>(),
                     LocalidadeUfId = row["Uf"].Cast<int>(),
                     Nome = row["Nome_Mesorregião"].Cast<string>()
                 }
                 select item).ToList();

            return query.GroupBy(x => x.LocalidadeMesorregiaoId).Select(y => y.FirstOrDefault());
        }

        public IEnumerable<LocalidadeMicrorregiao> GetAllMicrorregiao()
        {
            var query =
                (from row in _excel.Worksheet("dtb_2013")
                 let item = new LocalidadeMicrorregiao()
                 {
                     LocalidadeMicrorregiaoId = row["Microrregião Geográfica"].Cast<int>(),
                     Nome = row["Nome_Microrregião"].Cast<string>(),
                     LocalidadeMesorregiaoId = row["Mesorregião Geográfica"].Cast<int>()
                 }
                 select item).ToList();

            return query.GroupBy(x => x.LocalidadeMicrorregiaoId).Select(y => y.FirstOrDefault());
        }

        public IEnumerable<LocalidadeMunicipio> GetAllMunicipio()
        {
            var query =
                (from row in _excel.Worksheet("dtb_2013")
                 let item = new LocalidadeMunicipio()
                 {
                     Nome = row["Nome_Município"].Cast<string>(),
                     LocalidadeMicrorregiaoId = row["Microrregião Geográfica"].Cast<int>(),
                     LocalidadeUfId = row["Uf"].Cast<int>()
                 }
                 let item2 = item.GeraId(row["Uf"].Cast<int>(),
                                        row["Município"].Cast<int>())
                 select item2).ToList();

            return query.GroupBy(x => new { x.LocalidadeMunicipioId}).Select(y => y.FirstOrDefault());
        }

        public IEnumerable<LocalidadeDistrito> GetAllDistrito()
        {
            var query =
                (from row in _excel.Worksheet("dtb_2013")
                 let item = new LocalidadeDistrito()
                 {
                     Nome = row["Nome_Distrito"].Cast<string>(),
                     SubNome = row["Nome_Subdistrito"].Cast<string>(),
                     LocalidadeMunicipioId = row["Uf"].Cast<int>()*100000 + row["Município"].Cast<int>()
                 }
                 let item2 = item.GeraCodigo(row["Uf"].Cast<int>(),
                                        row["Município"].Cast<int>(),
                                        row["Distrito"].Cast<int>(),
                                        row["Subdistrito"].Cast<int>())
                 select item2);

            return query;
        }
        */

        public void Dispose()
        {
            _excel.Dispose();
        }
    }
}