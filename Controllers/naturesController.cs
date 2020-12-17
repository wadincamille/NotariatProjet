﻿using System;
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
    public class naturesController : Controller
    {
        private NotariatProjetUTC503Entities db = new NotariatProjetUTC503Entities();

        // GET: natures
        public ActionResult Index()
        {
            return View(db.nature.ToList());
        }

        // GET: natures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nature nature = db.nature.Find(id);
            if (nature == null)
            {
                return HttpNotFound();
            }
            return View(nature);
        }

        // GET: natures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: natures/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,libelle")] nature nature)
        {
            if (ModelState.IsValid)
            {
                db.nature.Add(nature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nature);
        }

        // GET: natures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nature nature = db.nature.Find(id);
            if (nature == null)
            {
                return HttpNotFound();
            }
            return View(nature);
        }

        // POST: natures/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,libelle")] nature nature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nature);
        }

        // GET: natures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nature nature = db.nature.Find(id);
            if (nature == null)
            {
                return HttpNotFound();
            }
            return View(nature);
        }

        // POST: natures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nature nature = db.nature.Find(id);
            db.nature.Remove(nature);
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
