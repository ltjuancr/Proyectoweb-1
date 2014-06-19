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
    public class accounts_payableController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /accounts_payable/

        public ActionResult Index()
        {
            var accounts_payable = db.accounts_payable.Include(a => a.purchaseOrder1).Include(a => a.supplier1);
            return View(accounts_payable.ToList());
        }

        //
        // GET: /accounts_payable/Details/5

        public ActionResult Details(int id = 0)
        {
            accounts_payable accounts_payable = db.accounts_payable.Find(id);
            if (accounts_payable == null)
            {
                return HttpNotFound();
            }
            return View(accounts_payable);
        }

        //
        // GET: /accounts_payable/Create

        public ActionResult Create()
        {
            ViewBag.purchaseOrder = new SelectList(db.purchaseOrder, "id", "description");
            ViewBag.supplier = new SelectList(db.supplier, "id", "company");
            return View();
        }

        //
        // POST: /accounts_payable/Create

        [HttpPost]
        public ActionResult Create(accounts_payable accounts_payable)
        {
            if (ModelState.IsValid)
            {
                db.accounts_payable.Add(accounts_payable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.purchaseOrder = new SelectList(db.purchaseOrder, "id", "description", accounts_payable.purchaseOrder);
            ViewBag.supplier = new SelectList(db.supplier, "id", "company", accounts_payable.supplier);
            return View(accounts_payable);
        }

        //
        // GET: /accounts_payable/Edit/5

        public ActionResult Edit(int id = 0)
        {
            accounts_payable accounts_payable = db.accounts_payable.Find(id);
            if (accounts_payable == null)
            {
                return HttpNotFound();
            }
            ViewBag.purchaseOrder = new SelectList(db.purchaseOrder, "id", "description", accounts_payable.purchaseOrder);
            ViewBag.supplier = new SelectList(db.supplier, "id", "company", accounts_payable.supplier);
            return View(accounts_payable);
        }

        //
        // POST: /accounts_payable/Edit/5

        [HttpPost]
        public ActionResult Edit(accounts_payable accounts_payable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounts_payable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.purchaseOrder = new SelectList(db.purchaseOrder, "id", "description", accounts_payable.purchaseOrder);
            ViewBag.supplier = new SelectList(db.supplier, "id", "company", accounts_payable.supplier);
            return View(accounts_payable);
        }

        //
        // GET: /accounts_payable/Delete/5

        public ActionResult Delete(int id = 0)
        {
            accounts_payable accounts_payable = db.accounts_payable.Find(id);
            if (accounts_payable == null)
            {
                return HttpNotFound();
            }
            return View(accounts_payable);
        }

        //
        // POST: /accounts_payable/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            accounts_payable accounts_payable = db.accounts_payable.Find(id);
            db.accounts_payable.Remove(accounts_payable);
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