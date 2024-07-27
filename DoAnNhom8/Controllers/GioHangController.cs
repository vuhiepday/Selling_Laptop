using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnNhom8.Models;

namespace DoAnNhom8.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(string ms, string strURL)
        {
            List<GioHang> firstGioHang = LayGioHang();
            GioHang SanPham = firstGioHang.Find(sp => sp.sMaSP == ms);
            if (SanPham == null)
            {
                SanPham = new GioHang(ms);
                firstGioHang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        [HttpPost]
        public ActionResult ThemGioHang1(string ms, string strURL)
        {
            List<GioHang> firstGioHang = LayGioHang();
            GioHang SanPham = firstGioHang.Find(sp => sp.sMaSP == ms);
            if (SanPham == null)
            {
                SanPham = new GioHang(ms);
                firstGioHang.Add(SanPham);
                return Json(new { success = true, message = "Thêm sản phẩm vào giỏ hàng thành công!" });
            }
            else
            {
                SanPham.iSoLuong++;
                return Json(new { success = true, message = "Thêm sản phẩm vào giỏ hàng thành công!" });
            }
        }

        private int TongSoLuong()
        {
            int totalSoLuong = 0;
            List<GioHang> firstGioHang = Session["GioHang"] as List<GioHang>;

            if (firstGioHang != null)
            {
                totalSoLuong = firstGioHang.Sum(sp => sp.iSoLuong);
            }

            return totalSoLuong;
        }
        private decimal TongThanhTien()
        {
            decimal totalThanhTien = 0;
            List<GioHang> firstGioHang = Session["GioHang"] as List<GioHang>;

            if (firstGioHang != null)
            {
                totalThanhTien = firstGioHang.Sum(sp => sp.dThanhTien);
            }

            return totalThanhTien;
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<GioHang> firstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();

            return View(firstGioHang);
        }


        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }
        public ActionResult XoaGioHang(string MaSp)
        {
            List<GioHang> lstGioHang = LayGioHang();

            GioHang sp = lstGioHang.SingleOrDefault(s => s.sMaSP == MaSp);
            if (sp != null) // Nếu có thì tiến hành xóa
            {
                lstGioHang.RemoveAll(s => s.sMaSP == MaSp);
                return RedirectToAction("GioHang", "GioHang");
            }

            if (lstGioHang.Count == 0) // Nếu giỏ hàng rỗng
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult XoaGioHang_All()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CapNhapGioHang(string MaSp, FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.sMaSP == MaSp);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult ThanhToan()
        {
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();

            return View(lstGioHang);
        }
        [HttpPost]
        public ActionResult XuLyThanhToan(FormCollection f)
        {
            string hoTen = f["txtHoTen"];
            string diaChi = f["txtDiaChi"];
            string email = f["txtEmail"];
            string soDienThoai = f["txtSoDienThoai"];

            // Thực hiện xử lý thanh toán tại đây (lưu thông tin, gửi email, ...)
            // ...
            List<GioHang> gh = LayGioHang();

            HOADON hd = new HOADON();   
            hd.MaHoaDon = "HD0"+Convert.ToString(ma());
            hd.MaKhach = Session["MaKH"].ToString();
            hd.TongTien = TongThanhTien();
            db.HOADONs.InsertOnSubmit(hd);
            db.SubmitChanges();

            List<CHITIETHOADON> lst = new List<CHITIETHOADON>();
            foreach (var item in gh)
            {
                CHITIETHOADON obj = new CHITIETHOADON();
                obj.MaHoaDon = hd.MaHoaDon;
                obj.MaSP = item.sMaSP;
                obj.SoLuong = item.iSoLuong;
                obj.DonGia = item.dGiaBan;
                obj.ThanhTien = item.iSoLuong * item.dGiaBan;
                lst.Add(obj);
            }
            db.CHITIETHOADONs.InsertAllOnSubmit(lst);
            db.SubmitChanges();
            // Xóa giỏ hàng sau khi thanh toán
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Home");
        }
        public int ma()
        {
            int a = db.HOADONs.Count();
            return a;
        }
	}
}