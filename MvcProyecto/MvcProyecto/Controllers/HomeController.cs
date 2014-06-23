using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DataAccess;
using MvcProyecto.Models;

namespace MvcProyecto.Controllers
{
    public class HomeController : Controller
    {

        private SalePointEntities db = new SalePointEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome";

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }
    }
}
