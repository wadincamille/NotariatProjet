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
    public class typeActesController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: typeActes
        public ActionResult Index()
        {
            return View(db.typeActe.ToList());
        }

        // GET: typeActes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeActe typeActe = db.typeActe.Find(id);
            if (typeActe == null)
            {
                return HttpNotFound();
            }
            return View(typeActe);
        }

        // GET: typeActes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: typeActes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,descr")] typeActe typeActe)
        {
            if (ModelState.IsValid)
            {
                db.typeActe.Add(typeActe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeActe);
        }

        // GET: typeActes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeActe typeActe = db.typeActe.Find(id);
            if (typeActe == null)
            {
                return HttpNotFound();
            }
            return View(typeActe);
        }

        // POST: typeActes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,descr")] typeActe typeActe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeActe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeActe);
        }

        // GET: typeActes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeActe typeActe = db.typeActe.Find(id);
            if (typeActe == null)
            {
                return HttpNotFound();
            }
            return View(typeActe);
        }

        // POST: typeActes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            typeActe typeActe = db.typeActe.Find(id);
            db.typeActe.Remove(typeActe);
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
