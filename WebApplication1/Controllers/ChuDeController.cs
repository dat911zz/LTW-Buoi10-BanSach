using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ChuDeController : Controller
    {
        Models.QLNSDataContext db = new Models.QLNSDataContext();
        // GET: ChuDe
        public ActionResult Index()
        {
            return View(db.ChuDes.ToList().GetRange(0, 7));
        }
        public ActionResult SachTheoCD(string id)
        {
            return View(db.ChuDes.First(x => x.MaChuDe.Equals(id)).Saches.ToList());
        }
    }
}