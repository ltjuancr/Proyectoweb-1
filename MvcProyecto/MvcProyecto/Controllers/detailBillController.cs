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
    public class detailBillController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /detailBill/

        public ActionResult Index()
        {
            var detailbill = db.detailBill.Include(d => d.bill1).Include(d => d.product1);
            return View(detailbill.ToList());
        }

        //
        // GET: /detailBill/Details/5

        public ActionResult Details(int id = 0)
        {
            detailBill detailbill = db.detailBill.Find(id);
            if (detailbill == null)
            {
                return HttpNotFound();
            }
            return View(detailbill);
        }

        //
        // GET: /detailBill/Create

        public ActionResult Create()
        {
            ViewBag.bill = new SelectList(db.bill, "id", "payment_term");
            ViewBag.product = new SelectList(db.product, "id", "product_name");
            return View();
        }

        //
        // POST: /detailBill/Create

        [HttpPost]
        public ActionResult Create(detailBill detailbill)
        {
            if (ModelState.IsValid)
            {
                db.detailBill.Add(detailbill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bill = new SelectList(db.bill, "id", "payment_term", detailbill.bill);
            ViewBag.product = new SelectList(db.product, "id", "product_name", detailbill.product);
            return View(detailbill);
        }

        //
        // GET: /detailBill/Edit/5

        public ActionResult Edit(int id = 0)
        {
            detailBill detailbill = db.detailBill.Find(id);
            if (detailbill == null)
            {
                return HttpNotFound();
            }
            ViewBag.bill = new SelectList(db.bill, "id", "payment_term", detailbill.bill);
            ViewBag.product = new SelectList(db.product, "id", "product_name", detailbill.product);
            return View(detailbill);
        }

        //
        // POST: /detailBill/Edit/5

        [HttpPost]
        public ActionResult Edit(detailBill detailbill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailbill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bill = new SelectList(db.bill, "id", "payment_term", detailbill.bill);
            ViewBag.product = new SelectList(db.product, "id", "product_name", detailbill.product);
            return View(detailbill);
        }

        //
        // GET: /detailBill/Delete/5

        public ActionResult Delete(int id = 0)
        {
            detailBill detailbill = db.detailBill.Find(id);
            if (detailbill == null)
            {
                return HttpNotFound();
            }
            return View(detailbill);
        }

        //
        // POST: /detailBill/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            detailBill detailbill = db.detailBill.Find(id);
            db.detailBill.Remove(detailbill);
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