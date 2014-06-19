using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DataAccess;
using MvcProyecto.Models;

namespace MvcProyecto.Controllers
{
    public class filtroProductController : Controller
    {
        private SalePointEntities db = new SalePointEntities();// Nos ayuda a conectarnos a la db y esta linea se obtuvo del RestController

        //
        // GET: /Search/

        public ActionResult Index()
        {
            // get data from db
            var products = db.product.ToList();

            // create model
            var model = new filtroProductModels();

            // fill restaurants in model
            model.Product = products;

            // return model to the view
            return View(model);
        }

        //public List<Restaurant> Restaurants { get; set; }


        //
        // POST: /Search/
        [HttpPost]
        public ActionResult Index(filtroProductModels model)
        {
            var search = model.SearchText;

            if (string.IsNullOrEmpty(search))
            {
                model.Product = db.product.ToList();
            }
            else
            {
                // fill restaurants in model
                model.Product = db.product.Where(x => x.family_product.description.Contains(search)).ToList();
            }

            // return model to the view
            return View(model);
        }

    }
}
