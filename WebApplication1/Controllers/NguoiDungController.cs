using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        //public ActionResult DangKy()
        //{
        //    return View();
        //}
    }
}