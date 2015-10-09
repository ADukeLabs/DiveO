using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiveO.Models;

namespace DiveO.Controllers
{
    public class DiversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Divers
        public ActionResult Index()
        {
            return View(db.Divers.ToList());
        }

        // GET: Divers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diver diver = db.Divers.Find(id);
            if (diver == null)
            {
                return HttpNotFound();
            }
            return View(diver);
        }

        // GET: Divers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Divers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ProfilePic,Location,Description,Certification,CertDate")] Diver diver)
        {
            if (ModelState.IsValid)
            {
                db.Divers.Add(diver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diver);
        }

        // GET: Divers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diver diver = db.Divers.Find(id);
            if (diver == null)
            {
                return HttpNotFound();
            }
            return View(diver);
        }

        // POST: Divers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ProfilePic,Location,Description,Certification,CertDate")] Diver diver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diver);
        }

        // GET: Divers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diver diver = db.Divers.Find(id);
            if (diver == null)
            {
                return HttpNotFound();
            }
            return View(diver);
        }

        // POST: Divers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diver diver = db.Divers.Find(id);
            db.Divers.Remove(diver);
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
