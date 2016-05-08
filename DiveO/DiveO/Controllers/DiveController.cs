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
using DiveO.Models.Model_Attributes;

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

        public ActionResult DiveLog(int? id)
        {
            DiveViewModel dvm = new DiveViewModel();
            dvm.Diver = db.Divers.Find(id);
            dvm.DiveList = db.Dives.ToList().FindAll(d => d.Diver.Id == id);
            return View(dvm);
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
            dvm.Dive = dive;
            dvm.Photos = dive.Photos;
            if (dive == null)
            {
                return HttpNotFound();
            }
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
        public ActionResult Create([Bind(Include = "Id,DiveSite,Location,DateTime,Duration,Depth,Description")] Dive dive, int? id, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                Diver diver = db.Divers.Find(id);
                dive.Diver = diver;
                if (files != null)
                {
                    foreach(var p in files)
                    {
                        Photo photo = new Photo();
                        photo.DiveId = dive.Id;
                        photo.PhotoBytes = new ImageProcessor().ImageToByteArray(p);
                        db.DivePhotos.Add(photo);
                    }
                }

                db.Dives.Add(dive);
                db.SaveChanges();
                return RedirectToAction("Feed");
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
        public ActionResult Edit([Bind(Include = "Id,DiveSite,Location,DateTime,Duration,Depth,Description")] Dive dive, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                if (files != null)
                {
                    foreach (var p in files)
                    {
                        Photo photo = new Photo();
                        photo.DiveId = dive.Id;
                        photo.PhotoBytes = new ImageProcessor().ImageToByteArray(p);
                        db.DivePhotos.Add(photo);
                    }
                }
                db.Entry(dive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Feed");
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
