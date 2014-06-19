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
    public class routeController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /route/

        public ActionResult Index()
        {
            var route = db.route.Include(r => r.requisition1);
            return View(route.ToList());
        }

        //
        // GET: /route/Details/5

        public ActionResult Details(int id = 0)
        {
            route route = db.route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        //
        // GET: /route/Create

        public ActionResult Create()
        {
            ViewBag.requisition = new SelectList(db.requisition, "id", "description");
            return View();
        }

        //
        // POST: /route/Create

        [HttpPost]
        public ActionResult Create(route route)
        {
            if (ModelState.IsValid)
            {
                db.route.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.requisition = new SelectList(db.requisition, "id", "description", route.requisition);
            return View(route);
        }

        //
        // GET: /route/Edit/5

        public ActionResult Edit(int id = 0)
        {
            route route = db.route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.requisition = new SelectList(db.requisition, "id", "description", route.requisition);
            return View(route);
        }

        //
        // POST: /route/Edit/5

        [HttpPost]
        public ActionResult Edit(route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.requisition = new SelectList(db.requisition, "id", "description", route.requisition);
            return View(route);
        }

        //
        // GET: /route/Delete/5

        public ActionResult Delete(int id = 0)
        {
            route route = db.route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        //
        // POST: /route/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            route route = db.route.Find(id);
            db.route.Remove(route);
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