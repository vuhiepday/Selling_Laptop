using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnNhom8.Models
{
    public class GioHang
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public string sMaSP { get; set; }
        public string sTenSP { get; set; }
        public int iSoLuong {get;set;}
        public string sAnh {get; set;}
        public decimal dGiaBan { get; set; }
        public decimal dThanhTien
         {
             get { return iSoLuong * dGiaBan; }
         }
        public GioHang (string MaSP)
        {
            sMaSP = MaSP;
            SANPHAM sanpham = db.SANPHAMs.Single(s => s.MaSP == sMaSP);
            sTenSP = sanpham.TenSP;
            iSoLuong = 1;
            sAnh = sanpham.Anh;
            dGiaBan = decimal.Parse(sanpham.GiaBan.ToString());
        }
    }
}