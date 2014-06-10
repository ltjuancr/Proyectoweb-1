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
    public class supplierController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /supplier/

        public ActionResult Index()
        {
            return View(db.supplier.ToList());
        }

        //
        // GET: /supplier/Details/5

        public ActionResult Details(int id = 0)
        {
            supplier supplier = db.supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // GET: /supplier/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /supplier/Create

        [HttpPost]
        public ActionResult Create(supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.supplier.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        //
        // GET: /supplier/Edit/5

        public ActionResult Edit(int id = 0)
        {
            supplier supplier = db.supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // POST: /supplier/Edit/5

        [HttpPost]
        public ActionResult Edit(supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        //
        // GET: /supplier/Delete/5

        public ActionResult Delete(int id = 0)
        {
            supplier supplier = db.supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // POST: /supplier/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            supplier supplier = db.supplier.Find(id);
            db.supplier.Remove(supplier);
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