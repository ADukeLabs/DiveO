using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiveO.Models;
using DiveO.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DiveO.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public HomeController()
        {
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
        } 

        [Authorize]
        public ActionResult Feed()
        {
            DiverViewModel dvm = new DiverViewModel();

            var id = User.Identity.GetUserId();
            var diver = db.Divers.Find(id);
            dvm.Name = diver.Name;
            dvm.ProfilePic = diver.ProfilePic;
            dvm.Dives = diver.DiveLog;
            return View(dvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}