using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NotariatProjetUTC503.Models;

namespace NotariatProjetUTC503.Controllers
{
    public class clairesController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: claires
        public ActionResult Index()
        {
            return View(db.claire.ToList());
        }

        // GET: claires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claire claire = db.claire.Find(id);
            if (claire == null)
            {
                return HttpNotFound();
            }
            return View(claire);
        }

        // GET: claires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: claires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,prenom")] claire claire)
        {
            if (ModelState.IsValid)
            {
                db.claire.Add(claire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(claire);
        }

        // GET: claires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claire claire = db.claire.Find(id);
            if (claire == null)
            {
                return HttpNotFound();
            }
            return View(claire);
        }

        // POST: claires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,prenom")] claire claire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claire);
        }

        // GET: claires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claire claire = db.claire.Find(id);
            if (claire == null)
            {
                return HttpNotFound();
            }
            return View(claire);
        }

        // POST: claires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            claire claire = db.claire.Find(id);
            db.claire.Remove(claire);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
