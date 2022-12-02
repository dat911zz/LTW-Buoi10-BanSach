using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
        QLNSDataContext db = new QLNSDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGH = Session["GioHang"] as List<GioHang>;
            if (lstGH == null)
            {
                lstGH = new List<GioHang>();
                Session["GioHang"] = lstGH;
            }
            return lstGH;
        }
        // GET: GioHang
        public ActionResult Index()
        {
            var lst = Session["GioHang"] as List<GioHang>;
            if (lst == null)
            {
                ViewBag.TongCong = 0;
                ViewBag.TongTien = 0;
            }
            else
            {
                ViewBag.TongCong = lst.Sum(x => x.SL);
                ViewBag.TongTien = lst.Sum(x => x.ThanhTien);
            }
            
            return View(LayGioHang());
        }
        public ActionResult ThemGioHang(int idSach, string strURL)
        {
            List<GioHang> lstGH = LayGioHang();
            GioHang sp = lstGH.Find(s => s.ThongTinSach.MaSach == idSach);
            if (sp == null)
            {
                sp = new GioHang(idSach);
                lstGH.Add(sp);
                return Redirect(strURL);
            }
            else
            {
                sp.SL++;
                return Redirect(strURL);
            }
        }
        public ActionResult GioHangPartial()
        {
            Session["SoLuong"] = LayGioHang().Sum(x => x.SL);
            return PartialView();
        }
        public ActionResult XoaGioHang(int id)
        { var lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.ThongTinSach.MaSach.Equals(id));
            if (sp != null)
            {
                lstGioHang.RemoveAll(x => x.ThongTinSach.MaSach.Equals(id));
                return RedirectToAction("Index","GioHang");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "GioHang");
        }
        public ActionResult XoaAllGioHang()
        {
            LayGioHang().Clear();
            return RedirectToAction("Index", "GioHang");
        }
        public ActionResult CapNhatGioHang(int id, int sl)
        {
            GioHang sp = LayGioHang().Single(s => s.ThongTinSach.MaSach.Equals(id));
            if (sp != null)
            {
                sp.SL = sl;
            }
            return RedirectToAction("Index", "GioHang");
        }
    }
}