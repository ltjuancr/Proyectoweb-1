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
    public class billController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /bill/

        public ActionResult Index()
        {
            var bill = db.bill.Include(b => b.client1);
            return View(bill.ToList());
        }

        //
        // GET: /bill/Details/5

        public ActionResult Details(int id = 0)
        {
            bill bill = db.bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        //
        // GET: /bill/Create

        public ActionResult Create()
        {
            ViewBag.client = new SelectList(db.client, "id", "identification");
            return View();
        }

        //
        // POST: /bill/Create

        [HttpPost]
        public ActionResult Create(bill bill)
        {
            if (ModelState.IsValid)
            {
                db.bill.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client = new SelectList(db.client, "id", "identification", bill.client);
            return View(bill);
        }

        //
        // GET: /bill/Edit/5

        public ActionResult Edit(int id = 0)
        {
            bill bill = db.bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.client = new SelectList(db.client, "id", "identification", bill.client);
            return View(bill);
        }

        //
        // POST: /bill/Edit/5

        [HttpPost]
        public ActionResult Edit(bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client = new SelectList(db.client, "id", "identification", bill.client);
            return View(bill);
        }

        //
        // GET: /bill/Delete/5

        public ActionResult Delete(int id = 0)
        {
            bill bill = db.bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        //
        // POST: /bill/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bill bill = db.bill.Find(id);
            db.bill.Remove(bill);
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