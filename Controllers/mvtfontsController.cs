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
    public class mvtfontsController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: mvtfonts
        public ActionResult Index()
        {
            return View(db.mvtfont.ToList());
        }

        // GET: mvtfonts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mvtfont mvtfont = db.mvtfont.Find(id);
            if (mvtfont == null)
            {
                return HttpNotFound();
            }
            return View(mvtfont);
        }

        // GET: mvtfonts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mvtfonts/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,montant,libelle,date")] mvtfont mvtfont)
        {
            if (ModelState.IsValid)
            {
                db.mvtfont.Add(mvtfont);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mvtfont);
        }

        // GET: mvtfonts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mvtfont mvtfont = db.mvtfont.Find(id);
            if (mvtfont == null)
            {
                return HttpNotFound();
            }
            return View(mvtfont);
        }

        // POST: mvtfonts/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,montant,libelle,date")] mvtfont mvtfont)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mvtfont).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mvtfont);
        }

        // GET: mvtfonts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mvtfont mvtfont = db.mvtfont.Find(id);
            if (mvtfont == null)
            {
                return HttpNotFound();
            }
            return View(mvtfont);
        }

        // POST: mvtfonts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mvtfont mvtfont = db.mvtfont.Find(id);
            db.mvtfont.Remove(mvtfont);
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
