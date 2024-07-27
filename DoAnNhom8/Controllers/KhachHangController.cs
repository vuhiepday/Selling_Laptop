using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnNhom8.Models;
using System.Text.RegularExpressions;


namespace DoAnNhom8.Controllers
{
    public class KhachHangController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: /KhachHang/
        [HttpGet]
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(KHACH kh, FormCollection f)
        {
            var hoTen = f["HotenKH"];
            var tenDN = f["TenDN"];
            var matKhau = f["Matkhau"];
            var reMatKhau = f["ReMatkhau"];
            var dienThoai = f["Dienthoai"];
            var ngaySinh = f["Ngaysinh"];
            var email = f["Email"];
            var diaChi = f["DiaChi"];


            if (!String.IsNullOrEmpty(hoTen) && !String.IsNullOrEmpty(tenDN) && !String.IsNullOrEmpty(matKhau)
                && !String.IsNullOrEmpty(reMatKhau) && !String.IsNullOrEmpty(dienThoai) && !String.IsNullOrEmpty(ngaySinh)
                && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(diaChi))
            {
                kh.MaKhach = Guid.NewGuid().ToString();
                kh.TenKhach = hoTen.Trim();
                kh.TENDN = tenDN;
                kh.MATKHAU = matKhau;
                kh.SDT = dienThoai.Trim();
                kh.NGAYSINH = DateTime.Parse(ngaySinh);
                kh.EMAIL = email;
                kh.DIACHI = diaChi.Trim();

                db.KHACHes.InsertOnSubmit(kh);
                db.SubmitChanges();

                var savedKhach = db.KHACHes.FirstOrDefault(k => k.TENDN == tenDN);

                if (savedKhach != null)
                {

                    string generatedMaKhach = savedKhach.MaKhach;


                    return RedirectToAction("DangNhap", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "An error occurred while saving data.");
                }
            }

            return View();
        }


        public ActionResult DangNhap(FormCollection f)
        {
            var tenDN = f["TENDN"];
            var matKhau = f["MATKHAU"];
            if (String.IsNullOrEmpty(tenDN))
                ViewData["Loi1"] = "Tên đăng nhập không được bỏ trống";
            if (String.IsNullOrEmpty(matKhau))
                ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
            if (!String.IsNullOrEmpty(tenDN) && !String.IsNullOrEmpty(matKhau))
            {
                TK_ADMIN ad = db.TK_ADMINs.SingleOrDefault(c => c.TAIKHOAN == tenDN && c.MATKHAU == matKhau);
                KHACH kh = db.KHACHes.SingleOrDefault(c => c.TENDN == tenDN && c.MATKHAU == matKhau);
                if (kh != null)
                {

                    Session["Ten"] = layTen(kh.TenKhach);
                    Session["taiKhoan"] = kh;
                    Session["MaKH"] = kh.MaKhach;
                    ViewBag.ThongBaoDangNhap = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "Home");
                }
                else if (ad != null)
                {
                    ViewBag.ThongBaoDangNhap = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                   
                else
                    ViewBag.TB = "Sai tên đăng nhập hoặc mật khẩu, vui lòng nhập lại!";
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public string layTen(string name)
        {
            string ten = "";
            Stack<char> stack = new Stack<char>();
            for (int i = name.Length - 1; i > 0; i--)
            {
                if (name[i] == ' ')
                    break;
                stack.Push(name[i]);
            }
            foreach (char c in stack)
                ten += c;
            return ten;
        }
        public bool kiemTraSpace(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    return false;
            }
            return true;
        }
        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
	}
}