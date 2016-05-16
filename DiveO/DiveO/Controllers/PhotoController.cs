using DiveO.Models;
using DiveO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiveO.Controllers
{
    public class PhotoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Photo
        public ActionResult GetPhoto(int? id)
        {
            PhotoViewModel pvm = new PhotoViewModel();
            pvm.Photo = db.Photos.Find(id);
            return View(pvm);
        }


    }
}