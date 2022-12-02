using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Models.QLNSDataContext db = new Models.QLNSDataContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowAllSach()
        {
            return View(db.Saches.ToList());
        }
        public ActionResult BookDetails(string id)
        {
            return View(db.Saches.Single(s => s.MaSach.Equals(id)));
        }
    }
}