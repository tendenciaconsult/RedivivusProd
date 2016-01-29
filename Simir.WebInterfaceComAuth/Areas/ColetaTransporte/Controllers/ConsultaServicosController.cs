using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using System;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Simir.WebInterfaceComAuth.Filters;
using Simir.Domain.Enuns;

namespace Simir.WebInterfaceComAuth.Areas.ColetaTransporte.Controllers
{

    public class ConsultaServicosController : Controller
    {
        private readonly IColetaEventualApp _ColetaEventual;
        private readonly IColetaExecutadaApp _ColetaExecutada;
        private readonly IColetaConsultaApp _ColetaConsulta;
        private readonly IRotasApp _Rotas;
        private readonly IPrestadoraServicoApp _prestadoraApp;

        public ConsultaServicosController(IColetaEventualApp ColetaEventual,
                                        IPrestadoraServicoApp prestadoraApp,
                                        IColetaConsultaApp ColetaConsulta,
                                        IRotasApp Rota,
                                        IColetaExecutadaApp ColetaExecutada)
        {
            _ColetaEventual = ColetaEventual;
            _ColetaExecutada = ColetaExecutada;
            _Rotas = Rota;
            _prestadoraApp = prestadoraApp;
            _ColetaConsulta = ColetaConsulta;

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
        // GET: ColetaTransporte/ConsultaColeta
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            ColetaConsultaVM modal = new ColetaConsultaVM();

            modal.bOrdinaria = true;
            modal.bEventual = true;
            modal.dtInicio = Convert.ToDateTime(DateTime.Now).ToShortDateString();
            modal.dtFim = Convert.ToDateTime(DateTime.Now).ToShortDateString();

            return View(modal);
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
        public async Task<JsonResult> ReturnRotas()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            var PrestadoraServicos = _Rotas.GetRotasByPrefeitura(prefeituraID);

            return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public ActionResult CarregaTipoConsulta()
        {
            var TipoConsulta = _ColetaConsulta.RetornaTipoConsulta();

            return Json(TipoConsulta, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> CarregaGrig(int? id,  int? idPrestServ, int? idRota, string dtInicio, string dtFim,
                                                    string Ordinario, string Eventual)
        {
            DateTime DataInicio;
            DateTime DataFinal;
            bool bOrdinaria;
            bool bEventual;

            if (dtInicio == "")
                DataInicio = DateTime.MinValue;
            else
                DataInicio = Convert.ToDateTime(dtInicio);

            if (dtFim == "")
                DataFinal = DateTime.MaxValue;
            else
                DataFinal = Convert.ToDateTime(dtFim);

            bOrdinaria = (Ordinario == "checked") ? true : false;
            bEventual = (Eventual == "checked") ? true : false;

            int idPrestadoraServ = (string.IsNullOrEmpty(idPrestServ.ToString())) ? 0 : Convert.ToInt32(idPrestServ);
            int RotaID = (string.IsNullOrEmpty(idRota.ToString())) ? 0 : Convert.ToInt32(idRota);


                if ((int)id == 0)
                {
                    return RedirectToAction("GrigColetaEventual", new
                    {
                        idPrestadora = idPrestadoraServ,
                        RotaID = RotaID,
                        dtInicio = DataInicio,
                        dtFim = DataFinal,
                        bOrdinaria = bOrdinaria,
                        bEventual = bEventual,
                    });
                }
                if ((int)id == 1)
                {
                    return RedirectToAction("GridColetaEventualRealizada", new
                    {
                        idPrestadora = idPrestadoraServ,
                        RotaID = RotaID,
                        dtInicio = DataInicio,
                        dtFim = DataFinal,
                        bOrdinaria = bOrdinaria,
                        bEventual = bEventual,
                    });
                }
                if ((int)id == 2)
                {
                    return RedirectToAction("GridColetaEventualNaoRealizada", new
                    {
                        idPrestadora = idPrestadoraServ,
                        RotaID = RotaID,
                        dtInicio = DataInicio,
                        dtFim = DataFinal,
                        bOrdinaria = bOrdinaria,
                        bEventual = bEventual,
                    });
                }
                if ((int)id == 3)
                {
                    return RedirectToAction("GridColetaEventualPendente", new
                    {
                        idPrestadora = idPrestadoraServ,
                        RotaID = RotaID,
                        dtInicio = DataInicio,
                        dtFim = DataFinal,
                        bOrdinaria = bOrdinaria,
                        bEventual = bEventual,
                    });
                }
            

            return PartialView("GrigColetaEventual.cshtml");

        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> GrigColetaEventual(int idPrestadora,
            int RotaID, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual)
        {

            return PartialView(_ColetaConsulta.CarregaGrigColetaEventual(idPrestadora,
            RotaID, dtInicio,  dtFim, bOrdinaria, bEventual));

        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> GridColetaEventualRealizada(int idPrestadora,
            int RotaID, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            bool Editavel = user.TemPermissao("ColetaTransporte/ExecucaoColeta/Index", TipoPermissao.Consultar);

            return PartialView(_ColetaConsulta.CarregaGridColetaEventualRealizada(idPrestadora,
            RotaID, dtInicio, dtFim, bOrdinaria, bEventual, Editavel));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> GridColetaEventualNaoRealizada(int idPrestadora,
            int RotaID, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            bool Editavel = user.TemPermissao("ColetaTransporte/ExecucaoColeta/Index", TipoPermissao.Consultar);

            return PartialView(_ColetaConsulta.CarregaGridColetaEventualNaoRealizada(idPrestadora,
            RotaID, dtInicio, dtFim, bOrdinaria, bEventual, Editavel));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> GridColetaEventualPendente(int idPrestadora,
            int RotaID, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            bool Editavel = user.TemPermissao("ColetaTransporte/ServicosEventuais/Index", TipoPermissao.Consultar);

            return PartialView(_ColetaConsulta.CarregaGridColetaEventualPendente(idPrestadora,
            RotaID, dtInicio, dtFim, bOrdinaria, bEventual, Editavel));
        }
    }
}