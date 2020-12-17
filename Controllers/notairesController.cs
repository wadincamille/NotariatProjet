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
    public class notairesController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: notaires
        public ActionResult Index()
        {
            return View(db.notaire.ToList());
        }

        // GET: notaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notaire notaire = db.notaire.Find(id);
            if (notaire == null)
            {
                return HttpNotFound();
            }
            return View(notaire);
        }

        // GET: notaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notaires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,prenom")] notaire notaire)
        {
            if (ModelState.IsValid)
            {
                db.notaire.Add(notaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notaire);
        }

        // GET: notaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notaire notaire = db.notaire.Find(id);
            if (notaire == null)
            {
                return HttpNotFound();
            }
            return View(notaire);
        }

        // POST: notaires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,prenom")] notaire notaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notaire);
        }

        // GET: notaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notaire notaire = db.notaire.Find(id);
            if (notaire == null)
            {
                return HttpNotFound();
            }
            return View(notaire);
        }

        // POST: notaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notaire notaire = db.notaire.Find(id);
            db.notaire.Remove(notaire);
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
