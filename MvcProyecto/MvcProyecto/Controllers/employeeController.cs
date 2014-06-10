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
    public class employeeController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /employee/

        public ActionResult Index()
        {
            var employee = db.EMPLOYEE.Include(e => e.postType1);
            return View(employee.ToList());
        }

        //
        // GET: /employee/Details/5

        public ActionResult Details(int id = 0)
        {
            EMPLOYEE employee = db.EMPLOYEE.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /employee/Create

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