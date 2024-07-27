using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnNhom8.Models;
namespace DoAnNhom8.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /Admin/SanPham/
        DataClasses1DataContext DB = new DataClasses1DataContext();
        public ActionResult List_SanPham()
        {
            var sp = DB.SANPHAMs.ToList();
            return View(sp);
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            ViewBag.hl = new SelectList(DB.NSXes.ToList().OrderBy(n => n.MaNSX), "MaNSX", "TenNSX");
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham(SANPHAM sp, FormCollection f)
        {
            sp.MaSP = "SP0"+MaAuto();
            sp.TenSP = f["TenSP"];
            sp.SoLuong = int.Parse(f["SoLuong"]);
            sp.ChiTiet = f["ChiTiet"];
            sp.Anh = Convert.ToString(f["Anh"]);
            sp.GiaBan = decimal.Parse(Convert.ToString(f["GiaBan"]));
            sp.MaNSX = f["MaNSX"];
            DB.SANPHAMs.InsertOnSubmit(sp);
            DB.SubmitChanges();
            return RedirectToAction("List_SanPham", "SanPham");
        }
        [HttpGet]
        public ActionResult SuaSanPham(string model)
        {
            ViewBag.hl = new SelectList(DB.NSXes.ToList().OrderBy(n => n.MaNSX), "MaNSX", "TenNSX");
            var sp = DB.SANPHAMs.Single(d => d.MaSP == model);
            return View(sp);
        }

        [HttpPost]
        public ActionResult SuaSanPham(SANPHAM sp)
        {
            if (ModelState.IsValid)
            {
                var a = DB.SANPHAMs.Single(d => d.MaSP == sp.MaSP);
                a.Anh = sp.Anh;
                a.ChiTiet = sp.ChiTiet;
                a.GiaBan = sp.GiaBan;
                a.MaNSX = sp.MaNSX;
                a.MaSP = sp.MaSP;
                a.SoLuong = sp.SoLuong;
                a.TenSP = sp.TenSP;
                DB.SubmitChanges();
                return RedirectToAction("List_SanPham", "SanPham");
            }
            return View(sp);
        }
        public ActionResult XoaSanPham(string model)
        {
            var sp = DB.SANPHAMs.Single(d => d.MaSP == model);
            DB.SANPHAMs.DeleteOnSubmit(sp);
            DB.SubmitChanges();
            return RedirectToAction("List_SanPham", "SanPham");
        }

        public int MaAuto()
        {
            int ma = DB.SANPHAMs.Count();
            return ma+1; 
        }
	}
}