using DiveO.Models;
using DiveO.Models.Model_Attributes;
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
            pvm.Photos = db.Photos.ToList().FindAll(p => p.DiveId == id);
            return View(pvm);
        }


    }
}