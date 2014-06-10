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
    public class postTypeController : Controller
    {
        private SalePointEntities db = new SalePointEntities();

        //
        // GET: /postType/

        public ActionResult Index()
        {
            return View(db.postType.ToList());
        }

        //
        // GET: /postType/Details/5

        public ActionResult Details(int id = 0)
        {
            postType posttype = db.postType.Find(id);
            if (posttype == null)
            {
                return HttpNotFound();
            }
            return View(posttype);
        }

        //
        // GET: /postType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /postType/Create

        [HttpPost]
        public ActionResult Create(postType posttype)
        {
            if (ModelState.IsValid)
            {
                db.postType.Add(posttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posttype);
        }

        //
        // GET: /postType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            postType posttype = db.postType.Find(id);
            if (posttype == null)
            {
                return HttpNotFound();
            }
            return View(posttype);
        }

        //
        // POST: /postType/Edit/5

        [HttpPost]
        public ActionResult Edit(postType posttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posttype);
        }

        //
        // GET: /postType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            postType posttype = db.postType.Find(id);
            if (posttype == null)
            {
                return HttpNotFound();
            }
            return View(posttype);
        }

        //
        // POST: /postType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            postType posttype = db.postType.Find(id);
            db.postType.Remove(posttype);
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