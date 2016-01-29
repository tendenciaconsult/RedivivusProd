using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Microsoft.Reporting.WebForms;
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Helpers;
using Simir.WebInterfaceComAuth.Filters;
using Chart = DotNet.Highcharts.Options.Chart;

namespace Simir.WebInterfaceComAuth.Areas.ControleFiscalizacao.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly IRotasApp _Rotas;
        private readonly IRegiaoAdministrativaApp _RegiaoAdministrativaApp;
        private readonly IPrestadoraServicoApp _prestadoraApp;
        private readonly IControleFiscalizacaoApp _controle;

        public ConsultasController(IRotasApp Rotas,
            IRegiaoAdministrativaApp RegiaoAdministrativaApp,
            IControleFiscalizacaoApp controle,
            IPrestadoraServicoApp prestadoraApp)
        {
            _Rotas = Rotas;
            _RegiaoAdministrativaApp = RegiaoAdministrativaApp;
            _prestadoraApp = prestadoraApp;
            _controle = controle;
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: ControleFiscalizacao/Consultas
        [MenuAuthorize]
        public ActionResult Index()
        {
            ControleFiscalizacaoVM model = new ControleFiscalizacaoVM();

            model.dtInicio = DateTime.Now.ToShortDateString();
            model.dtFim = DateTime.Now.ToShortDateString();
            model.bColetaRealizada = true;
            model.bRelDiario = true;
            model.MesInicio = "01/" + DateTime.Now.Year;
            model.MesFim = "12/" + DateTime.Now.Year;

            return View(model);
        }
        public async Task<JsonResult> ReturnRegiaoAdministrativa()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            var RegiaoAdministrativa = _RegiaoAdministrativaApp.GetHashRegiaoAdministrativa(prefeituraID);

            return Json(RegiaoAdministrativa, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> ReturnPrestadoraServicos()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            var PrestadoraServicos = _prestadoraApp.ReturnPrestadoraServicosByPrefeitura(prefeituraID);

            return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public ActionResult CarregarResiduoColetado()
        {
            var TipoConsulta = _controle.RetornaResiduoColetado();

            return Json(TipoConsulta, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public ActionResult CarregaTipoConsulta()
        {
            var TipoConsulta = _controle.RetornaTipoConsulta();

            return Json(TipoConsulta, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> ReturnRotas()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            var PrestadoraServicos = _Rotas.GetRotasByPrefeitura(prefeituraID);

            return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
        }

        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> Consultar(int? id, int? idResiduoColetado, int? idRota, int? idPrestServ,
            string dtInicio, string dtFim, bool? ColetaRealizada, int? RelDiario, string MesInicio, string MesFim)
        {
            DateTime DataInicio;
            DateTime DataFinal;

            // Primeiro Dia: Criamos uma variavel DateTime com o ano atual, o mês selecionado e o dia igual a 1 
            DateTime MesRefInicio = new DateTime(Convert.ToDateTime(MesInicio).Year, Convert.ToDateTime(MesInicio).Month, 1);

            // Ultimo Dia: Criamos uma variavel DateTime com o ano atual, o mês atual e o dia é a quantidade de dias que o mês corrente possui.
            //A função DateTime.DaysInMonth recebe como parametro o ano(int) e o mês(int) e retorna a quantidade de dias(int). 
            DateTime MesRefFim = new DateTime(Convert.ToDateTime(MesFim).Year, Convert.ToDateTime(MesFim).Month, DateTime.DaysInMonth(Convert.ToDateTime(MesFim).Year, Convert.ToDateTime(MesFim).Month));


            int prefeituraID = User.Identity.GetPrefeituraID();

            if ((int)RelDiario == 1)
            {
                DataInicio = Convert.ToDateTime(dtInicio);
                DataFinal = Convert.ToDateTime(dtFim);
            }
            else
            {
                DataInicio = MesRefInicio;
                DataFinal = MesRefFim;
            }


            int idPrestadoraServ = (string.IsNullOrEmpty(idPrestServ.ToString())) ? 0 : Convert.ToInt32(idPrestServ);
            int RotaID = (string.IsNullOrEmpty(idRota.ToString())) ? 0 : Convert.ToInt32(idRota);


            //if ((int)id == 0)
            //{
            return RedirectToAction("TotalResiduoColetado", new
            {
                idResiduoColetado = (int)idResiduoColetado,
                idRota = RotaID,
                idPrestadoraServicos = idPrestadoraServ,
                dtInicio = DataInicio,
                dtFim = DataFinal,
                bColetaRealizada = ColetaRealizada,
                idPrefeitura = prefeituraID,
                bRelDiario = (RelDiario == 1) ? true : false,
            });
            //}
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> TotalResiduoColetado(int idResiduoColetado, int idRota, int idPrestadoraServicos,
            DateTime dtInicio, DateTime dtFim, bool bColetaRealizada, int idPrefeitura, bool bRelDiario)
        {
            if (bRelDiario)
            {
                return PartialView(_controle.TotalResiduoColetadoMesAno(idResiduoColetado, idRota, idPrestadoraServicos,
                                dtInicio, dtFim, bColetaRealizada, idPrefeitura));
            }
            else
            {
                return PartialView(_controle.TotalResiduoColetadoMesAno(idResiduoColetado, idRota, idPrestadoraServicos,
                                dtInicio, dtFim, bColetaRealizada, idPrefeitura));
            }
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> SalvarRelatorio(int? id, int? idResiduoColetado, int? idRota, int? idPrestServ,
           string dtInicio, string dtFim, bool? ColetaRealizada, int? RelDiario, string MesInicio, string MesFim, string ExtensaoRel)
        {

            try
            {

                DateTime DataInicio;
                DateTime DataFinal;

                // Primeiro Dia: Criamos uma variavel DateTime com o ano atual, o mês selecionado e o dia igual a 1 
                DateTime MesRefInicio = new DateTime(Convert.ToDateTime(MesInicio).Year, Convert.ToDateTime(MesInicio).Month, 1);

                // Ultimo Dia: Criamos uma variavel DateTime com o ano atual, o mês atual e o dia é a quantidade de dias que o mês corrente possui.
                //A função DateTime.DaysInMonth recebe como parametro o ano(int) e o mês(int) e retorna a quantidade de dias(int). 
                DateTime MesRefFim = new DateTime(Convert.ToDateTime(MesFim).Year, Convert.ToDateTime(MesFim).Month, DateTime.DaysInMonth(Convert.ToDateTime(MesFim).Year, Convert.ToDateTime(MesFim).Month));


                int prefeituraID = User.Identity.GetPrefeituraID();

                if ((int)RelDiario == 1)
                {
                    DataInicio = Convert.ToDateTime(dtInicio);
                    DataFinal = Convert.ToDateTime(dtFim);
                }
                else
                {
                    DataInicio = MesRefInicio;
                    DataFinal = MesRefFim;
                }


                int idPrestadoraServ = (string.IsNullOrEmpty(idPrestServ.ToString())) ? 0 : Convert.ToInt32(idPrestServ);
                int RotaID = (string.IsNullOrEmpty(idRota.ToString())) ? 0 : Convert.ToInt32(idRota);
                bool bColetaRealizada = ColetaRealizada != null && (bool)ColetaRealizada;

                if ((int)id == 0)
                {
                    var Result = _controle.Rel_TotalResiduoColetadoMesAno(Convert.ToInt32(idResiduoColetado), RotaID, idPrestadoraServ,
                          DataInicio, DataFinal, bColetaRealizada, prefeituraID).ToList();

                    if (Result.Count == 0)
                    {
                        goto RelatorioVazio;
                    }

                    return await GetRelatorio(ExtensaoRel,DataInicio,DataFinal,"Rel_ResiduoMensal.rdlc",Result);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            RelatorioVazio:
                {
                    TempData["Avis.RelatorioVazio"] = "Sem dados para gerar o relatório!";
                    return RedirectToAction("Index");
                }
            }


            catch (Exception)
            {

                throw;
            }

        }
        public async Task<ActionResult> GetRelatorio(string id, DateTime dtInicio, DateTime dtFim, string nmRelatorio, List<TotalResiduoColetadoMesAnoVM> cm)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), nmRelatorio);
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction("Index");
            }


            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            string nmProfeitura = (user.TBUsuario.TBPrefeitura.nmPrefeitura);

            ReportParameter p1 = new ReportParameter("dtInicio", dtInicio.ToString());
            ReportParameter p2 = new ReportParameter("dtFim", dtFim.ToString());
            ReportParameter p3 = new ReportParameter("nmPrefeitura", nmProfeitura);

            ReportDataSource rd = new ReportDataSource("RedivivusDataSet", cm);

            lr.SetParameters(new ReportParameter[] { p1, p2, p3 });

            lr.DataSources.Add(rd);

            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType);
        }

    }
}