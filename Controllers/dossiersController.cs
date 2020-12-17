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
    public class dossiersController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: dossiers
        public ActionResult Index()
        {
            var dossier = db.dossier.Include(d => d.claire).Include(d => d.notaire).Include(d => d.secretaire);
            return View(dossier.ToList());
        }

        // GET: dossiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dossier dossier = db.dossier.Find(id);
            if (dossier == null)
            {
                return HttpNotFound();
            }
            return View(dossier);
        }

        // GET: dossiers/Create
        public ActionResult Create()
        {
            ViewBag.idClaire = new SelectList(db.claire, "id", "nom");
            ViewBag.idNotaire = new SelectList(db.notaire, "id", "nom");
            ViewBag.idSecretaire = new SelectList(db.secretaire, "id", "nom");
            return View();
        }

        // POST: dossiers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,dateCreation,dateButoireSigna,dateSigna,dateTransImpot,dateRetourImpot,idNotaire,idClaire,idSecretaire")] dossier dossier)
        {
            if (ModelState.IsValid)
            {
                db.dossier.Add(dossier);
                db.SaveChanges();
                return RedirectToAction("Index");
                //return RedirectToAction("./biens");
            }

            ViewBag.idClaire = new SelectList(db.claire, "id", "nom", dossier.idClaire);
            ViewBag.idNotaire = new SelectList(db.notaire, "id", "nom", dossier.idNotaire);
            ViewBag.idSecretaire = new SelectList(db.secretaire, "id", "nom", dossier.idSecretaire);
            return View(dossier);
        }

        // GET: dossiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dossier dossier = db.dossier.Find(id);
            if (dossier == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClaire = new SelectList(db.claire, "id", "nom", dossier.idClaire);
            ViewBag.idNotaire = new SelectList(db.notaire, "id", "nom", dossier.idNotaire);
            ViewBag.idSecretaire = new SelectList(db.secretaire, "id", "nom", dossier.idSecretaire);
            return View(dossier);
        }

        // POST: dossiers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,dateCreation,dateButoireSigna,dateSigna,dateTransImpot,dateRetourImpot,idNotaire,idClaire,idSecretaire")] dossier dossier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dossier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClaire = new SelectList(db.claire, "id", "nom", dossier.idClaire);
            ViewBag.idNotaire = new SelectList(db.notaire, "id", "nom", dossier.idNotaire);
            ViewBag.idSecretaire = new SelectList(db.secretaire, "id", "nom", dossier.idSecretaire);
            return View(dossier);
        }

        // GET: dossiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dossier dossier = db.dossier.Find(id);
            if (dossier == null)
            {
                return HttpNotFound();
            }
            return View(dossier);
        }

        // POST: dossiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dossier dossier = db.dossier.Find(id);
            db.dossier.Remove(dossier);
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
