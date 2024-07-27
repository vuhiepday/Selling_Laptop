using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnNhom8.Models;

namespace DoAnNhom8.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        //
        // GET: /Admin/DonHang/
        DataClasses1DataContext DB = new DataClasses1DataContext();
        public ActionResult List_DonHang()
        {
            var dh = DB.HOADONs.ToList();
            return View(dh);
        }

        public ActionResult ChiTietDonHang(string maHD)
        {         
           var hd = DB.CHITIETHOADONs.Where(m => m.MaHoaDon == maHD).ToList();     
            return View(hd);
        }
        public ActionResult TimDonHang(string txt_Search)
        {
            var listSP = DB.HOADONs.Where(s => s.MaHoaDon.Contains(txt_Search)).ToList();
            if (listSP.Count == 0)
            {
                ViewBag.TB = "Không tìm thấy hóa đơn!!!";
            }
            return View(listSP);
        }
	}
}