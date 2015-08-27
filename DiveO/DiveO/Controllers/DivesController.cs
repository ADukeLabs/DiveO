using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiveO.Models;

namespace DiveO.Controllers
{
    public class DivesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dives
        public ActionResult Index()
        {
            return View(db.Dives.ToList());
        }

        // GET: Dives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dive dive = db.Dives.Find(id);
            if (dive == null)
            {
                return HttpNotFound();
            }
            return View(dive);
        }

        // GET: Dives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DiveSite,Date,TimeStart,Duration,Depth,Description")] Dive dive)
        {
            if (ModelState.IsValid)
            {
                db.Dives.Add(dive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dive);
        }

        // GET: Dives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dive dive = db.Dives.Find(id);
            if (dive == null)
            {
                return HttpNotFound();
            }
            return View(dive);
        }

        // POST: Dives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DiveSite,Date,TimeStart,Duration,Depth,Description")] Dive dive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dive);
        }

        // GET: Dives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dive dive = db.Dives.Find(id);
            if (dive == null)
            {
                return HttpNotFound();
            }
            return View(dive);
        }

        // POST: Dives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dive dive = db.Dives.Find(id);
            db.Dives.Remove(dive);
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
