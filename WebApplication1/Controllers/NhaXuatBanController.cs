using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class NhaXuatBanController : Controller
    {
        Models.QLNSDataContext db = new Models.QLNSDataContext();
        // GET: NhaXuatBan
        public ActionResult Index()
        {
            return View(db.NhaXuatBans.ToList().GetRange(0, 7));
        }
    }
}