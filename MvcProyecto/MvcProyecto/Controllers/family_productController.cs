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
    public class family_productController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /family_product/

        public ActionResult Index()
        {
            return View(db.family_product.ToList());
        }

        //
        // GET: /family_product/Details/5

        public ActionResult Details(int id = 0)
        {
            family_product family_product = db.family_product.Find(id);
            if (family_product == null)
            {
                return HttpNotFound();
            }
            return View(family_product);
        }

        //
        // GET: /family_product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /family_product/Create

        [HttpPost]
        public ActionResult Create(family_product family_product)
        {
            if (ModelState.IsValid)
            {
                db.family_product.Add(family_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(family_product);
        }

        //
        // GET: /family_product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            family_product family_product = db.family_product.Find(id);
            if (family_product == null)
            {
                return HttpNotFound();
            }
            return View(family_product);
        }

        //
        // POST: /family_product/Edit/5

        [HttpPost]
        public ActionResult Edit(family_product family_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(family_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(family_product);
        }

        //
        // GET: /family_product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            family_product family_product = db.family_product.Find(id);
            if (family_product == null)
            {
                return HttpNotFound();
            }
            return View(family_product);
        }

        //
        // POST: /family_product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            family_product family_product = db.family_product.Find(id);
            db.family_product.Remove(family_product);
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