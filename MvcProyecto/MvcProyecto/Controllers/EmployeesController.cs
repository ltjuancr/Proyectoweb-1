using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DataAccess;

namespace MvcProyecto.Controllers
{
    public class EmployeesController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /Employees/

        public ActionResult Index()
        {
            return View(db.EMPLOYEES.ToList());
        }

        //
        // GET: /Employees/Details/5

        public ActionResult Details(string id = null)
        {
            EMPLOYEES employees = db.EMPLOYEES.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        //
        // GET: /Employees/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employees/Create

        [HttpPost]
        public ActionResult Create(EMPLOYEES employees)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEES.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employees);
        }

        //
        // GET: /Employees/Edit/5

        public ActionResult Edit(string id = null)
        {
            EMPLOYEES employees = db.EMPLOYEES.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        //
        // POST: /Employees/Edit/5

        [HttpPost]
        public ActionResult Edit(EMPLOYEES employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        //
        // GET: /Employees/Delete/5

        public ActionResult Delete(string id = null)
        {
            EMPLOYEES employees = db.EMPLOYEES.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        //
        // POST: /Employees/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            EMPLOYEES employees = db.EMPLOYEES.Find(id);
            db.EMPLOYEES.Remove(employees);
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