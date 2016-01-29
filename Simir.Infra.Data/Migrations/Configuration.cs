//add-migration -StartUpProjectName:"Simir.WebInterfaceComAuth" criando
//Update-Database -StartUpProjectName:"Simir.WebInterfaceComAuth" -Verbose
//Update-Database -StartUpProjectName:"Simir.WebInterfaceComAuth" -Verbose
//Update-Database  -Verbose
//add-migration criando

using System.Data.Entity.Migrations;
using Simir.Infra.Data.Context;

namespace Simir.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimirContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimirContext context)
        {
            /*
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(r => r.Name == "Operador"))
            {
                var role = new IdentityRole { Name = "Operador" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Servidor"))
            {
                var role = new IdentityRole { Name = "Servidor" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "ServidorMaster"))
            {
                var role = new IdentityRole { Name = "ServidorMaster" };
                manager.Create(role);
            }
             */

            /*
            using (var excel = new ServiceExcelNaturezaJuridica())
            {
                context.NaturezaJuridicas.AddRange(excel.GetAllNaturezaJuridica());
            };
            //*/

            /*
            using (var excel = new ServiceExcel())
            {
                //context.LocalidadeUfs.AddRange(excel.GetAllUf());
                //context.LocalidadeMesorregioes.AddRange(excel.GetAllMesorregiao());
                //context.LocalidadeMicrorregioes.AddRange(excel.GetAllMicrorregiao());
                //context.LocalidadeMunicipios.AddRange(excel.GetAllMunicipio());
                //context.LocalidadeDistritos.AddRange(excel.GetAllDistrito());

            };
             
             * 
            using (var excel = new ServiceExcelLogradouro())
            {
                //context.LocalidadeLogradouroTipos.AddRange(excel.GetAllLogradouroTipo());

            };
            */
            /*
            using (var excel = new ServiceExcelRS())
            {
                
            
                context.TipoResiduoCapitulos.AddRange(excel.GetAllCapitulo());

                var sc = excel.GetAllSubcapitulo();
                foreach (var item in sc)
                {
                    item.TipoResiduoCapituloId = context.TipoResiduoCapitulos.First(x => x.Codigo == item.Codigo.Substring(0, 2)).TipoResiduoId;
                    context.TipoResiduoSubcapitulos.Add(item);

                }
                context.SaveChanges();
                 
                var d = excel.GetAllDetalhe();

                foreach (var item in d)
                {
                    item.TipoResiduoSubcapituloId = context.TipoResiduoSubcapitulos.First(x => x.Codigo == item.Codigo.Substring(0, 4)).TipoResiduoId;
                    context.TipoResiduoDetalhes.Add(item);
                }
                context.SaveChanges();
             }
                 * */
        }
    }
}