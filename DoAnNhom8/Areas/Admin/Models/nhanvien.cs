using System.ComponentModel.DataAnnotations;
public class NhanVienModel
{
    [Key]
    public string MaNV { get; set; }

    public string TenNV { get; set; }

    public string GioiTinh { get; set; }

    public string DiaChi { get; set; }

    public string SDT { get; set; }
}