using HospitalProjectTeam4.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProjectTeam4.Controllers
{
    public class HomeController : Controller
    {
        private HospitalProjectContext db = new HospitalProjectContext();

        public ActionResult Index()
        {
            var pagesList = db.Pages
                .Where(x => x.IsPublished)
                .Include(p => p.Doctor)
                .ToList();
            return View("PagesList", pagesList);
        }

        public ActionResult PagesList()
        {
            var pagesList = db.Pages
                .Where(x => x.IsPublished)
                .Include(p => p.Doctor)
                .ToList();
            return View("PagesList", pagesList);
        }

        public ActionResult Page(string id)
        {
            var page = db.Pages.SingleOrDefault(x => x.PageID == id);
            if (page == null)
                return HttpNotFound();

            return View(page);
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