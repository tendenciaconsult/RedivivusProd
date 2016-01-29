using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Cadastros.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoApp _enderecoApp;
        

        public EnderecoController(IEnderecoApp enderecoApp)
        {
            _enderecoApp = enderecoApp;
        }

        // GET: Cadastros/Localidade
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EnderecoEditaPanel(EnderecoVM model)
        {

            return View(model);
        }

        public ActionResult EnderecoDetalhePanel(EnderecoDetalheVM model)
        {

            return View("~/Views/Shared/_Panel.cshtml", model);
        }

        public ActionResult EnderecoDetalhe(EnderecoDetalheVM model)
        {

            return View(model);
        }
        

        public PartialViewResult EnderecoEdita(int id)
        {

            return PartialView("~/Areas/Cadastros/Views/Shared/_EnderecoEdita.cshtml", id);
        }

        [HttpPost]
        public PartialViewResult EnderecoEdita(EnderecoVM model)
        {

            return PartialView("~/Areas/Cadastros/Views/Shared/_EnderecoEdita.cshtml", model);
        }
        public JsonResult ConsultaCep(string id)
        {
            EnderecoVM end;
            try
            {
                end = _enderecoApp.ConsultaCep(id);
            }
            catch (ArgumentException ex)
            {
                string[] lines = Regex.Split(ex.Message, "\r\n");
                return Json(new { ErrorMessage = lines[0], Success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ErrorMessage = ex.Message, Success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = true, Dado = end }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetBairrosByMunicipio(int? id)
        {
            if (id == null)
                return Json(Enumerable.Empty<SelectListItem>(), JsonRequestBehavior.AllowGet);
            else
            {
                var tiposFake = _enderecoApp.GetBairrosByMunicipio((int)id);
                return Json(tiposFake, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetMunicipiosByUf(int? id)
        {
            if(id == null)
                return Json(Enumerable.Empty<SelectListItem>(), JsonRequestBehavior.AllowGet);
            else
            {
                var tiposFake = _enderecoApp.GetMunicipiosByUf((int)id);
                return Json(tiposFake, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetHashUf()
        {
            var tiposFake = _enderecoApp.GetUfs();
           // object[][] dddd = tiposFake.Select(x => new object[] { x.Key, x.Value }).ToArray();
            return Json(tiposFake, JsonRequestBehavior.AllowGet);

           // return Json(new SelectList(tiposFake, "Key", "Value"), JsonRequestBehavior.AllowGet);
        }



    }
}