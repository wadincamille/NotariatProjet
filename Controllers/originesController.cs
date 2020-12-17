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
    public class originesController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: origines
        public ActionResult Index()
        {
            var origine = db.origine.Include(o => o.bien);
            return View(origine.ToList());
        }

        // GET: origines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            origine origine = db.origine.Find(id);
            if (origine == null)
            {
                return HttpNotFound();
            }
            return View(origine);
        }

        // GET: origines/Create
        public ActionResult Create()
        {
            ViewBag.idBien = new SelectList(db.bien, "id", "rue");
            return View();
        }

        // POST: origines/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descr,idBien")] origine origine)
        {
            if (ModelState.IsValid)
            {
                db.origine.Add(origine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBien = new SelectList(db.bien, "id", "rue", origine.idBien);
            return View(origine);
        }

        // GET: origines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            origine origine = db.origine.Find(id);
            if (origine == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBien = new SelectList(db.bien, "id", "rue", origine.idBien);
            return View(origine);
        }

        // POST: origines/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descr,idBien")] origine origine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(origine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBien = new SelectList(db.bien, "id", "rue", origine.idBien);
            return View(origine);
        }

        // GET: origines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            origine origine = db.origine.Find(id);
            if (origine == null)
            {
                return HttpNotFound();
            }
            return View(origine);
        }

        // POST: origines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            origine origine = db.origine.Find(id);
            db.origine.Remove(origine);
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
