using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DataAccess;
using MvcProyecto.Models;


namespace MvcProyecto.Controllers
{
    public class filterEmployeeController : Controller
    {
        //
        private SalePointEntities db = new SalePointEntities();// Nos ayuda a conectarnos a la db y esta linea se obtuvo del RestController

        // GET: /filterClient/

        public ActionResult Index()
        {
            // get data from db
            var employees = db.EMPLOYEE.ToList();

            // create model
            var model = new filterEmployeeModels();

            // fill restaurants in model
            model.employee = employees;

            // return model to the view
            return View(model);
        }

        //public List<Restaurant> Restaurants { get; set; }


        //
        // POST: /Search/
        [HttpPost]
        public ActionResult Index(filterEmployeeModels model)
        {
            var search = model.SearchText;

            if (string.IsNullOrEmpty(search))
            {
                model.employee = db.EMPLOYEE.ToList();
            }
            else
            {
                // fill restaurants in model
                model.employee = db.EMPLOYEE.Where(x => x.postType1.description.Contains(search)).ToList();
            }

            // return model to the view
            return View(model);
        }

    }
}
