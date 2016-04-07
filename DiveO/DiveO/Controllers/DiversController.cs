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
using DiveO.Services;
using DiveO.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DiveO.Controllers
{
    public class DiversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public DiversController()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Divers
        //[Authorize]
        public ActionResult Index()
        {
            return View(db.Divers.ToList());
        }

        // GET: Divers/Details/5
        //[Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiverViewModel dvm = new DiverViewModel();
            dvm.Id = db.Divers.Find(id).Id;
            dvm.Name = db.Divers.Find(id).Name;
            dvm.ProfilePic = db.Divers.Find(id).ProfilePic;
            dvm.HomeBase = db.Divers.Find(id).Location;
            dvm.Certification = db.Divers.Find(id).Certification;
            //Diver diver = db.Divers.Find(id);
            if (dvm == null)
            {
                return HttpNotFound();
            }
            return View(dvm);
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
        //[Authorize]
        public ActionResult Create([Bind(Include = "Id,Name,ProfilePic,Location,Description,Certification,CertDate")] Diver diver, HttpPostedFileBase file)
        {
            if (file != null)
            {
                diver.ProfilePic = new ImageProcessor().ImageToByteArray(file);
            }

            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                diver.ApplicationUser = UserManager.FindById(id);
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
        public ActionResult Edit([Bind(Include = "Id,Name,ProfilePic,Location,Description,Certification,CertDate")] Diver diver, HttpPostedFileBase file)
        {
            if (file != null)
            {
                diver.ProfilePic = new ImageProcessor().ImageToByteArray(file);
            }

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
