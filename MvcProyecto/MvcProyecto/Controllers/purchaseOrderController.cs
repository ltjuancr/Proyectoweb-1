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
    public class purchaseOrderController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /purchaseOrder/

        public ActionResult Index()
        {
            var purchaseorder = db.purchaseOrder.Include(p => p.supplier1);
            return View(purchaseorder.ToList());
        }

        //
        // GET: /purchaseOrder/Details/5

        public ActionResult Details(int id = 0)
        {
            purchaseOrder purchaseorder = db.purchaseOrder.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        //
        // GET: /purchaseOrder/Create

        public ActionResult Create()
        {
            ViewBag.supplier = new SelectList(db.supplier, "id", "company");
            return View();
        }

        //
        // POST: /purchaseOrder/Create

        [HttpPost]
        public ActionResult Create(purchaseOrder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.purchaseOrder.Add(purchaseorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.supplier = new SelectList(db.supplier, "id", "company", purchaseorder.supplier);
            return View(purchaseorder);
        }

        //
        // GET: /purchaseOrder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            purchaseOrder purchaseorder = db.purchaseOrder.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.supplier = new SelectList(db.supplier, "id", "company", purchaseorder.supplier);
            return View(purchaseorder);
        }

        //
        // POST: /purchaseOrder/Edit/5

        [HttpPost]
        public ActionResult Edit(purchaseOrder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.supplier = new SelectList(db.supplier, "id", "company", purchaseorder.supplier);
            return View(purchaseorder);
        }

        //
        // GET: /purchaseOrder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            purchaseOrder purchaseorder = db.purchaseOrder.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        //
        // POST: /purchaseOrder/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            purchaseOrder purchaseorder = db.purchaseOrder.Find(id);
            db.purchaseOrder.Remove(purchaseorder);
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