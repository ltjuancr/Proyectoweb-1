using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DataAccess;

namespace MvcProyecto.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private SalePointEntities DB = new SalePointEntities();

        public ActionResult Index()
        {
            var name = "Maria";
            var pass = "1234";
            var consulta = (from UserName in DB.EMPLOYEE where UserName.name == name && UserName.password==pass select UserName);

            return View();
        }

    }
}
