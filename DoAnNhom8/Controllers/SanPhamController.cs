using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnNhom8.Models;

namespace DoAnNhom8.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult AllSanPham()
        {
            var listSP = db.SANPHAMs.OrderByDescending(s => s.GiaBan).ToList();
            return View(listSP);
        }
        public ActionResult SearchSanPham(string txt_Search)
        {
            var listSP = db.SANPHAMs.Where(s => s.TenSP.Contains(txt_Search)).ToList();
            if(listSP.Count == 0)
            {
                ViewBag.TB = "Không tìm thấy sản phẩm nào!!!";
            }
            return View(listSP);
        }
        public ActionResult SPTheoNSX(string MaNSX)
        {
            var listSP = db.SANPHAMs.Where(s => s.MaNSX == MaNSX).OrderBy(s => s.GiaBan).ToList();
            return View(listSP);
        }
        public ActionResult XemChiTiet(string MaSP)
        {
            if (MaSP == null)
            {
                return HttpNotFound();
            }

            SANPHAM sp = db.SANPHAMs.SingleOrDefault(s => s.MaSP == MaSP);

            if (sp == null)
            {
                return HttpNotFound();
            }

            return View(sp);
        }

	}
}