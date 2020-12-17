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
    public class biensController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: biens
        public ActionResult Index()
        {
            var bien = db.bien.Include(b => b.nature);
            return View(bien.ToList());
        }

        // GET: biens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bien bien = db.bien.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // GET: biens/Create
        public ActionResult Create()
        {
            ViewBag.idNature = new SelectList(db.nature, "id", "libelle");
            return View();
        }

        // POST: biens/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rue,cp,ville,idNature")] bien bien)
        {
            if (ModelState.IsValid)
            {
                db.bien.Add(bien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNature = new SelectList(db.nature, "id", "libelle", bien.idNature);
            return View(bien);
        }

        // GET: biens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bien bien = db.bien.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNature = new SelectList(db.nature, "id", "libelle", bien.idNature);
            return View(bien);
        }

        // POST: biens/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rue,cp,ville,idNature")] bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNature = new SelectList(db.nature, "id", "libelle", bien.idNature);
            return View(bien);
        }

        // GET: biens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bien bien = db.bien.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: biens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bien bien = db.bien.Find(id);
            db.bien.Remove(bien);
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
