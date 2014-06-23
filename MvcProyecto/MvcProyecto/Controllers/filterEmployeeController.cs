using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DataAccess;
using MvcProyecto.Models;
using System.Data;


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
        public ActionResult Create()
        {
            ViewBag.postType = new SelectList(db.postType, "id", "description");
            return View();
        }

        //
        // POST: /employee/Create

        [HttpPost]
        public ActionResult Create(EMPLOYEE employee)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEE.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.postType = new SelectList(db.postType, "id", "description", employee.postType);
            return View(employee);
        }

        //
        // GET: /employee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EMPLOYEE employee = db.EMPLOYEE.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.postType = new SelectList(db.postType, "id", "description", employee.postType);
            return View(employee);
        }

        //
        // POST: /employee/Edit/5

        [HttpPost]
        public ActionResult Edit(EMPLOYEE employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.postType = new SelectList(db.postType, "id", "description", employee.postType);
            return View(employee);
        }

        //
        // GET: /employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EMPLOYEE employee = db.EMPLOYEE.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLOYEE employee = db.EMPLOYEE.Find(id);
            db.EMPLOYEE.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
