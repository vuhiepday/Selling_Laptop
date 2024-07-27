using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using DoAnNhom8.Areas.Admin.Controllers;
using DoAnNhom8.Models;
namespace DoAnNhom8.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            return View();
        }

        DataClasses1DataContext DB = new DataClasses1DataContext();
        public ActionResult List_NhanVien()
        {
            var sp = DB.NHANVIENs.ToList();
            return View(sp);
        }

        public async Task<ActionResult> AllNhanVien()
        {
            using (var httpClient = new HttpClient())
            {
                var apiUrl = "http://localhost:50715/Areas/Admin/api/NhanVien"; // Thay thế bằng URL của API của bạn

                // Gửi yêu cầu GET đến API và nhận phản hồi
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Đọc dữ liệu từ phản hồi
                    var content = await response.Content.ReadAsStringAsync();

                    // Chuyển đổi dữ liệu JSON thành đối tượng (nếu cần)
                    var data = JsonConvert.DeserializeObject<List<NhanVienModel>>(content);

                    // Truyền dữ liệu đến View để hiển thị
                    return View(data);
                }
                else
                {
                    // Xử lý trường hợp không thành công (ví dụ: thông báo lỗi)
                    ViewBag.ErrorMessage = "Failed to retrieve data from the API";
                    return View();
                }
            }
        }
    }
}