using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Simir.WebInterfaceComAuth.Filters;
using Simir.Domain.Enuns;



namespace Simir.WebInterfaceComAuth.Areas.Limpeza.Controllers
{
    public class ConsultaServicosController : Controller
    {
        private readonly ILimpezaConsultaApp _LimpezaConsulta;
        private readonly ILimpezaEventualApp _ILimpezaEventualApp;
        private readonly IRegiaoAdministrativaApp _RegiaoAdministrativaApp;
        private readonly IEnderecoApp _enderecoApp;
        private readonly IPrestadoraServicoApp _prestadoraApp;
        

        public ConsultaServicosController(ILimpezaEventualApp ILimpezaEventualApp,
            IRegiaoAdministrativaApp RegiaoAdministrativaApp,
            IPrestadoraServicoApp prestadoraApp,
            ILimpezaConsultaApp LimpezaConsulta,
            IEnderecoApp enderecoApp)
        {
            _ILimpezaEventualApp = ILimpezaEventualApp;
            _RegiaoAdministrativaApp = RegiaoAdministrativaApp;
            _enderecoApp = enderecoApp;
            _prestadoraApp = prestadoraApp;
            _LimpezaConsulta = LimpezaConsulta;


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
        // GET: Limpeza/ConsultaServicos
        [MenuAuthorize]
        public ActionResult Index()
        {
            
            LimpezaConsultaVM modal = new LimpezaConsultaVM();
            //pra testar


            modal.TipoProgramacao = 1;
            modal.bEventual = true;
            modal.bOrdinaria = true;
            modal.dtInicio = Convert.ToDateTime(DateTime.Now).ToShortDateString();
            modal.dtFim = Convert.ToDateTime(DateTime.Now).ToShortDateString();
            modal.bGridCarregado = false;

            return View(modal);
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> ReturnRegiaoAdministrativa()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            var RegiaoAdministrativa = _RegiaoAdministrativaApp.GetHashRegiaoAdministrativa(prefeituraID);

            return Json(RegiaoAdministrativa, JsonRequestBehavior.AllowGet);
        }
        //Carrega o dropdown com o Logradouro
        [MenuAuthorize(Action = "Index")]
        public JsonResult ReturnLogradouro(int? id, int? id1)
        {
            int idBairro = 0;
            int idRegiaoAdministrativa = 0;

            if (id != null)
                idRegiaoAdministrativa = Convert.ToInt32(id);

            if (id1 != null)
                idBairro = Convert.ToInt32(id1);

            var Logradouro = _RegiaoAdministrativaApp.GetLogradouroByRegiaoAdministrativaANDBairro(idRegiaoAdministrativa, idBairro);

            return Json(Logradouro, JsonRequestBehavior.AllowGet);
        }
        //Carrega o dropdown do bairro
        [MenuAuthorize(Action = "Index")]
        public JsonResult ReturnBairros(int? id)
        {
            int idRegiaoAdministrativa = 0;
            if (id != null)
                idRegiaoAdministrativa = Convert.ToInt32(id);

            var Bairros = _RegiaoAdministrativaApp.GetBairrosByRegiaoAdministrativa(idRegiaoAdministrativa);

            return Json(Bairros, JsonRequestBehavior.AllowGet);

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
        public async Task<ActionResult> CarregaGrig(int? id, int? idRegiaoAdministrativa, int? idPrestadora,
            int? idLogradouro, int? idBairro, string dtInicio, string dtFim, int? TipoConsultaID,
            string Ordinario, string Eventual, int TipoProgramacao)
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

            int idRegiaoAdm = (string.IsNullOrEmpty(idRegiaoAdministrativa.ToString())) ? 0 : Convert.ToInt32(idRegiaoAdministrativa);
            int idPrestadoraServ = (string.IsNullOrEmpty(idPrestadora.ToString())) ? 0 : Convert.ToInt32(idPrestadora);
            int idRua = (string.IsNullOrEmpty(idLogradouro.ToString())) ? 0 : Convert.ToInt32(idLogradouro);
            int idMunicipio = (string.IsNullOrEmpty(idBairro.ToString())) ? 0 : Convert.ToInt32(idBairro);

            bOrdinaria = (Ordinario == "checked") ? true : false;
            bEventual = (Eventual == "checked") ? true : false;
            
            if (ModelState.IsValid)
            {
                if ((int)TipoConsultaID == 0)
                {
                    return RedirectToAction("GrigLimpezaEventual", new
                    {
                        idRegiaoAdministrativa = idRegiaoAdm,
                        idPrestadora = idPrestadoraServ,
                        idLogradouro = idRua,
                        idBairro = idMunicipio,
                        dtInicio = DataInicio,
                        dtFim = DataFinal,
                        bOrdinaria = bOrdinaria,
                        bEventual = bEventual,
                        TipoProgramacao = TipoProgramacao

                    });
                }
                if ((int)TipoConsultaID == 2)
                {
                    return RedirectToAction("GridLimpezaEventualNaoRealizada", new
                    {
                        idRegiaoAdministrativa = idRegiaoAdm,
                        idPrestadora = idPrestadoraServ,
                        idLogradouro = idRua,
                        idBairro = idMunicipio,
                        dtInicio = DataInicio,
                        dtFim = DataFinal,
                        bOrdinaria = bOrdinaria,
                        bEventual = bEventual,
                        TipoProgramacao = TipoProgramacao
                    });
                }

                if ((int)TipoConsultaID == 1)
                {
                    return RedirectToAction("GridLimpezaEventualRealizada", new
                    {
                        idRegiaoAdministrativa = idRegiaoAdm,
                        idPrestadora = idPrestadoraServ,
                        idLogradouro = idRua,
                        idBairro = idMunicipio,
                        dtInicio = DataInicio,
                        dtFim = DataFinal,
                        bOrdinaria = bOrdinaria,
                        bEventual = bEventual,
                        TipoProgramacao = TipoProgramacao
                    });
                }
                if ((int)TipoConsultaID == 3)
                {
                    return RedirectToAction("GridLimpezaEventualPendente", new
                    {
                        idRegiaoAdministrativa = idRegiaoAdm,
                        idPrestadora = idPrestadoraServ,
                        idLogradouro = idRua,
                        idBairro = idMunicipio,
                        dtInicio = DataInicio,
                        dtFim = DataFinal,
                        bOrdinaria = bOrdinaria,
                        bEventual = bEventual,
                        TipoProgramacao = TipoProgramacao
                    });
                }
            }

            return PartialView("CarregaGrigLimpezaEventual.cshtml");

        }

        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> GrigLimpezaEventual(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, int TipoProgramacao)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            bool Editavel = user.TemPermissao("Limpeza/ServicosEventuais/Index", TipoPermissao.Consultar);

            return PartialView(_LimpezaConsulta.CarregaGridLimpezaEventual(idRegiaoAdministrativa, idPrestadora,
            idLogradouro, idBairro, dtInicio, dtFim, bOrdinaria, bEventual, TipoProgramacao, Editavel));

        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> GridLimpezaEventualNaoRealizada(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, int TipoProgramacao)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            bool Editavel = user.TemPermissao("Limpeza/ExecucaoLimpeza/Index", TipoPermissao.Consultar);

            return PartialView(_LimpezaConsulta.CarregaGridLimpezaEventualNaoExecutado(idRegiaoAdministrativa, idPrestadora,
                    idLogradouro, idBairro, dtInicio, dtFim, bOrdinaria, bEventual, TipoProgramacao, Editavel));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> GridLimpezaEventualPendente(int idRegiaoAdministrativa, int idPrestadora,
           int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, int TipoProgramacao)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            bool Editavel = user.TemPermissao("Limpeza/ServicosEventuais/Index", TipoPermissao.Consultar);

            return PartialView(_LimpezaConsulta.CarregaGridLimpezaEventualPendente(idRegiaoAdministrativa, idPrestadora,
                    idLogradouro, idBairro, dtInicio, dtFim, bOrdinaria, bEventual, TipoProgramacao, Editavel));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> GridLimpezaEventualRealizada(int idRegiaoAdministrativa, int idPrestadora,
            int idLogradouro, int idBairro, DateTime dtInicio, DateTime dtFim, bool bOrdinaria, bool bEventual, int TipoProgramacao)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            bool Editavel = user.TemPermissao("Limpeza/ExecucaoLimpeza/Index", TipoPermissao.Consultar);

            return PartialView(_LimpezaConsulta.CarregaGridLimpezaEventualExecutado(idRegiaoAdministrativa, idPrestadora,
                    idLogradouro, idBairro, dtInicio, dtFim, bOrdinaria, bEventual, TipoProgramacao, Editavel));
        }
        [MenuAuthorize(Action = "Index")]
        public ActionResult CarregaTipoConsulta()
        {
            var TipoConsulta = _LimpezaConsulta.RetornaTipoConsulta();

            return Json(TipoConsulta, JsonRequestBehavior.AllowGet);
        }
        
    }
}