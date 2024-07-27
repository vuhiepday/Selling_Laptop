using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnNhom8.Models;

namespace DoAnNhom8.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
       
        //
        // GET: /Admin/KhachHang/
        DataClasses1DataContext DB = new DataClasses1DataContext();
        public ActionResult List_KhachHang()
        {
            var kh = DB.KHACHes.ToList();
            return View(kh);
        }
        [HttpGet]
        public ActionResult SuaKhachHang(string id)
        {   
            var sp = DB.KHACHes.Single(d => d.MaKhach == id);
            return View(sp);
        }
        [HttpPost]
        public ActionResult SuaKhachHang(KHACH sp)
        {
            if (ModelState.IsValid)
            {
                var a = DB.KHACHes.Single(d => d.MaKhach == sp.MaKhach);
                a.DIACHI = sp.DIACHI;
                a.EMAIL = sp.EMAIL;
                a.MaKhach = sp.MaKhach;
               a.MATKHAU = sp.MATKHAU;
               a.NGAYSINH = sp.NGAYSINH;
                a.SDT = sp.SDT;
               a.TENDN = sp.TENDN;
                a.TenKhach = sp.TenKhach;
                DB.SubmitChanges();
                return RedirectToAction("List_KhachHang", "KhachHang");
            }
            return View(sp);
        }
        public ActionResult ChiTietKhachHang(string id)
        {
            var kh = DB.KHACHes.Single(d => d.MaKhach == id);
            return View(kh);
        }
	}
}