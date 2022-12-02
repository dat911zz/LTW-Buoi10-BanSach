using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GioHang
    {
        Models.QLNSDataContext db = new QLNSDataContext();
        public Sach ThongTinSach { get; set; }
        public int SL { get; set; }
        public double ThanhTien { get => (double)(SL * ThongTinSach.GiaBan); }
        public GioHang(int idSach)
        {
            ThongTinSach = db.Saches.Single(s => s.MaSach == idSach);
            SL = 1;
        }
    }
}