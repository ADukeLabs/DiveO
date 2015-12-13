using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiveO.Models;
using DiveO.Services;
using DiveO.ViewModels;
using Microsoft.AspNet.Identity;

namespace DiveO.Controllers
{
    public class DiveController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //protected UserManager<ApplicationUser> UserManager { get; set; }

        //[Authorize]
        // GET: Dive
        public ActionResult Index()
        {
            return View(db.Dives.ToList());
        }

        //[Authorize]
        // GET: Dive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dive dive = db.Dives.Find(id);
            DiveViewModel dvm = new DiveViewModel();
            if (dive == null)
            {
                return HttpNotFound();
            }
            dvm.DiveSite = dive.DiveSite;
            dvm.Location = dive.Location;
            dvm.Date = dive.DateTime;
            dvm.Time = dive.DateTime;
            dvm.Depth = dive.Depth;
            dvm.Duration = dive.Duration;
            dvm.Description = dive.Description;
            dvm.Photos = dive.Photos;
            return View(dvm);
        }

        // GET: Dive/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public ActionResult Create([Bind(Include = "Id,DiveSite,Location,DateTime,Duration,Depth,Description")] Dive dive, int? id, ICollection<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                Diver diver = db.Divers.Find(id);
                dive.Diver = diver;
                dive.Photos = new List<byte[]>();
                if (files != null)
                {
                    foreach (var i in files)
                    {
                        var photo = new ImageProcessor().ImageToByteArray(i);
                        dive.Photos.Add(photo);
                    }
                }
                db.Dives.Add(dive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dive);
        }

        // GET: Dive/Edit/5
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

        // POST: Dive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DiveSite,Location,DateTime,Duration,Depth,Description")] Dive dive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dive);
        }

        // GET: Dive/Delete/5
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

        // POST: Dive/Delete/5
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
