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
    public class productController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /product/

        public ActionResult Index()
        {
            var product = db.product.Include(p => p.family_product).Include(p => p.supplier1);
            return View(product.ToList());
        }

        //
        // GET: /product/Details/5

        public ActionResult Details(int id = 0)
        {
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /product/Create

        public ActionResult Create()
        {
            ViewBag.familyProduct = new SelectList(db.family_product, "id", "description");
            ViewBag.supplier = new SelectList(db.supplier, "id", "company");
            return View();
        }

        //
        // POST: /product/Create

        [HttpPost]
        public ActionResult Create(product product)
        {
            if (ModelState.IsValid)
            {
                db.product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.familyProduct = new SelectList(db.family_product, "id", "description", product.familyProduct);
            ViewBag.supplier = new SelectList(db.supplier, "id", "company", product.supplier);
            return View(product);
        }

        //
        // GET: /product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.familyProduct = new SelectList(db.family_product, "id", "description", product.familyProduct);
            ViewBag.supplier = new SelectList(db.supplier, "id", "company", product.supplier);
            return View(product);
        }

        //
        // POST: /product/Edit/5

        [HttpPost]
        public ActionResult Edit(product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.familyProduct = new SelectList(db.family_product, "id", "description", product.familyProduct);
            ViewBag.supplier = new SelectList(db.supplier, "id", "company", product.supplier);
            return View(product);
        }

        //
        // GET: /product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            product product = db.product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.product.Find(id);
            db.product.Remove(product);
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