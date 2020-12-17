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
    public class typeClientsController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: typeClients
        public ActionResult Index()
        {
            return View(db.typeClient.ToList());
        }

        // GET: typeClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeClient typeClient = db.typeClient.Find(id);
            if (typeClient == null)
            {
                return HttpNotFound();
            }
            return View(typeClient);
        }

        // GET: typeClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: typeClients/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,libelle")] typeClient typeClient)
        {
            if (ModelState.IsValid)
            {
                db.typeClient.Add(typeClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeClient);
        }

        // GET: typeClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeClient typeClient = db.typeClient.Find(id);
            if (typeClient == null)
            {
                return HttpNotFound();
            }
            return View(typeClient);
        }

        // POST: typeClients/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,libelle")] typeClient typeClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeClient);
        }

        // GET: typeClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeClient typeClient = db.typeClient.Find(id);
            if (typeClient == null)
            {
                return HttpNotFound();
            }
            return View(typeClient);
        }

        // POST: typeClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            typeClient typeClient = db.typeClient.Find(id);
            db.typeClient.Remove(typeClient);
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
