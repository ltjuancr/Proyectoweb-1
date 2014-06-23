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
    public class clientController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /client/

        public ActionResult Index()
        {
            return View(db.client.ToList());
        }

        //
        // GET: /client/Details/5

        public ActionResult Details(int id = 0)
        {
            client client = db.client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // GET: /client/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /client/Create

        [HttpPost]
        public ActionResult Create(client client)
        {
            if (ModelState.IsValid)
            {
                db.client.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        //
        // GET: /client/Edit/5

        public ActionResult Edit(int id = 0)
        {
            client client = db.client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /client/Edit/5

        [HttpPost]
        public ActionResult Edit(client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //
        // GET: /client/Delete/5

        public ActionResult Delete(int id = 0)
        {
            client client = db.client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /client/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client client = db.client.Find(id);
            db.client.Remove(client);
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