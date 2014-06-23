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
    public class detailPurchaseOrderController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /detailPurchaseOrder/

        public ActionResult Index()
        {
            var detailpurchaseorder = db.detailPurchaseOrder.Include(d => d.product1).Include(d => d.purchaseOrder1);
            return View(detailpurchaseorder.ToList());
        }

        //
        // GET: /detailPurchaseOrder/Details/5

        public ActionResult Details(int id = 0)
        {
            detailPurchaseOrder detailpurchaseorder = db.detailPurchaseOrder.Find(id);
            if (detailpurchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(detailpurchaseorder);
        }

        //
        // GET: /detailPurchaseOrder/Create

        public ActionResult Create()
        {
            ViewBag.product = new SelectList(db.product, "id", "product_name");
            ViewBag.purchaseOrder = new SelectList(db.purchaseOrder, "id", "description");
            return View();
        }

        //
        // POST: /detailPurchaseOrder/Create

        [HttpPost]
        public ActionResult Create(detailPurchaseOrder detailpurchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.detailPurchaseOrder.Add(detailpurchaseorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product = new SelectList(db.product, "id", "product_name", detailpurchaseorder.product);
            ViewBag.purchaseOrder = new SelectList(db.purchaseOrder, "id", "description", detailpurchaseorder.purchaseOrder);
            return View(detailpurchaseorder);
        }

        //
        // GET: /detailPurchaseOrder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            detailPurchaseOrder detailpurchaseorder = db.detailPurchaseOrder.Find(id);
            if (detailpurchaseorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.product = new SelectList(db.product, "id", "product_name", detailpurchaseorder.product);
            ViewBag.purchaseOrder = new SelectList(db.purchaseOrder, "id", "description", detailpurchaseorder.purchaseOrder);
            return View(detailpurchaseorder);
        }

        //
        // POST: /detailPurchaseOrder/Edit/5

        [HttpPost]
        public ActionResult Edit(detailPurchaseOrder detailpurchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailpurchaseorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product = new SelectList(db.product, "id", "product_name", detailpurchaseorder.product);
            ViewBag.purchaseOrder = new SelectList(db.purchaseOrder, "id", "description", detailpurchaseorder.purchaseOrder);
            return View(detailpurchaseorder);
        }

        //
        // GET: /detailPurchaseOrder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            detailPurchaseOrder detailpurchaseorder = db.detailPurchaseOrder.Find(id);
            if (detailpurchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(detailpurchaseorder);
        }

        //
        // POST: /detailPurchaseOrder/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            detailPurchaseOrder detailpurchaseorder = db.detailPurchaseOrder.Find(id);
            db.detailPurchaseOrder.Remove(detailpurchaseorder);
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