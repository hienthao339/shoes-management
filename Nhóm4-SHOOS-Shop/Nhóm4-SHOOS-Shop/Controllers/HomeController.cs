using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Nhóm4_SHOOS_Shop.Models;

namespace Nhóm4_SHOOS_Shop.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            List<SANPHAM> lst = db.SANPHAMs.ToList();
            return View(lst);
        }
        public ActionResult Product(int id)
        {
            var sanPhams = db.SANPHAMs.Where(s => s.MASP == id);
            return View(sanPhams);
        }
        public ActionResult Cart()
        {
            //temporary

            List<SANPHAM> lst = db.SANPHAMs.ToList();
            return View(lst);
        }
    }
}