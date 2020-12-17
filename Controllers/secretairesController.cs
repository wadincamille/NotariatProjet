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
    public class secretairesController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: secretaires
        public ActionResult Index()
        {
            return View(db.secretaire.ToList());
        }

        // GET: secretaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            secretaire secretaire = db.secretaire.Find(id);
            if (secretaire == null)
            {
                return HttpNotFound();
            }
            return View(secretaire);
        }

        // GET: secretaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: secretaires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,prenom")] secretaire secretaire)
        {
            if (ModelState.IsValid)
            {
                db.secretaire.Add(secretaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secretaire);
        }

        // GET: secretaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            secretaire secretaire = db.secretaire.Find(id);
            if (secretaire == null)
            {
                return HttpNotFound();
            }
            return View(secretaire);
        }

        // POST: secretaires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,prenom")] secretaire secretaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secretaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(secretaire);
        }

        // GET: secretaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            secretaire secretaire = db.secretaire.Find(id);
            if (secretaire == null)
            {
                return HttpNotFound();
            }
            return View(secretaire);
        }

        // POST: secretaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            secretaire secretaire = db.secretaire.Find(id);
            db.secretaire.Remove(secretaire);
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
