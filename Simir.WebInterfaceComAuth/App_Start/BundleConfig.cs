using System.Web;
using System.Web.Optimization;

namespace Simir.WebInterfaceComAuth
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap-datepicker*",
                        "~/Scripts/locales/bootstrap-datepicker.pt-BR.min.js",
                        "~/Scripts/jquery.pulse.min.js",
                        "~/Scripts/jBox.min.js",
                        "~/Scripts/jquery.form.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/dataTables/datatables.min.js",
                        "~/Scripts/bootstrap-clockpicker.js",
                        "~/Scripts/bootstrap-clockpicker.min.js",
                        "~/Scripts/jquery-clockpicker.js",
                        "~/Scripts/jquery-clockpicker.min.js",
                         
                        //"~/Scripts/jquery.maskedinput.js",
                        //"~/Scripts/jquery.mask.min.js",
                        //"~/Scripts/jquery.unobtrusive.min.js",
                        "~/Scripts/jquery.metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/HighChart").Include(
                "~/Scripts/Highcharts-4.0.1/js/highcharts.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.mask.min.js",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/meuscript").Include(
                        "~/Scripts/ScriptHelpers.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/morris/raphael-2.1.0.min.js",
                      "~/Scripts/morris/morris.js"
                      //"~/Scripts/custom.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      
                      "~/Content/jBox.css",
                      "~/Content/themes/NoticeBorder.css",
                      "~/Content/css/font-awesome.css",
                      "~/Scripts/morris/morris-0.4.3.min.css",
                      "~/Content/bootstrap-datepicker*",
                      "~/Content/bootstrap-clockpicker.css",
                      "~/Content/bootstrap-clockpicker.min.css",
                      "~/Content/jquery-clockpicker.css",
                      "~/Content/jquery-clockpicker.min.css",
                      "~/Scripts/dataTables/datatables.min.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/custom0").Include(
                      "~/Content/css/custom.css"

                      ));
            bundles.Add(new StyleBundle("~/Content/custom1").Include(
                      "~/Content/css/custom2.css"

                      ));

            bundles.Add(new ScriptBundle("~/bundles/tabela").Include(
                      "~/Scripts/dataTables/jquery.dataTables.js",
                      "~/Scripts/dataTables/dataTables.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/tabela").Include(
                     "~/Scripts/dataTables/dataTables.bootstrap.css"));


        }
    }
}
