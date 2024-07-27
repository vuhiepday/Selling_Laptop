using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnNhom8.Models;

namespace DoAnNhom8.Controllers
{
    public class NhaSanXuatController : Controller
    {
        //
        // GET: /NhaSanXuat/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhaSanXuatPartial()
        {
            //var listNSX = db.NSXes.Take(10).ToList();
            var listNSX = db.NSXes.Take(5).ToList();
            return View(listNSX);
        }
	}
}