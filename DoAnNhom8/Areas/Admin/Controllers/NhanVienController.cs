using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using DoAnNhom8.Models;

namespace DoAnNhom8.Areas.Admin.Controllers
{
    public class NhanVienController : ApiController
    {

        // GET api/nhanvien
        private DataClasses1DataContext db = new DataClasses1DataContext(); // Thay YourDatabaseContext bằng lớp kết nối đến CSDL

        // GET api/nhanvien
        public IEnumerable<NHANVIEN> Get()
        {
            return db.NHANVIENs.ToList(); // Trả về danh sách NHANVIEN từ CSDL
        }

        // GET api/nhanvien/{id}
        public IHttpActionResult Get(string id)
        {
            var nhanVien = db.NHANVIENs.FirstOrDefault(nv => nv.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound(); // Trả về HTTP 404 Not Found nếu không tìm thấy Nhân viên với mã được chỉ định
            }
            return Ok(nhanVien);
        }
    }
}
