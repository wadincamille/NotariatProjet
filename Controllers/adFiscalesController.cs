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
    public class adFiscalesController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: adFiscales
        public ActionResult Index()
        {
            return View(db.adFiscale.ToList());
        }

        // GET: adFiscales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adFiscale adFiscale = db.adFiscale.Find(id);
            if (adFiscale == null)
            {
                return HttpNotFound();
            }
            return View(adFiscale);
        }

        // GET: adFiscales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: adFiscales/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,rue,cp,ville")] adFiscale adFiscale)
        {
            if (ModelState.IsValid)
            {
                db.adFiscale.Add(adFiscale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adFiscale);
        }

        // GET: adFiscales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adFiscale adFiscale = db.adFiscale.Find(id);
            if (adFiscale == null)
            {
                return HttpNotFound();
            }
            return View(adFiscale);
        }

        // POST: adFiscales/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,rue,cp,ville")] adFiscale adFiscale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adFiscale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adFiscale);
        }

        // GET: adFiscales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adFiscale adFiscale = db.adFiscale.Find(id);
            if (adFiscale == null)
            {
                return HttpNotFound();
            }
            return View(adFiscale);
        }

        // POST: adFiscales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adFiscale adFiscale = db.adFiscale.Find(id);
            db.adFiscale.Remove(adFiscale);
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
