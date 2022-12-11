using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhóm4_SHOOS_Shop.Models;

namespace Nhóm4_SHOOS_Shop.Controllers
{
    public class SANPHAMsController : Controller
    {
        private Entities db = new Entities();

        // GET: SANPHAMs
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAMs.Include(s => s.NHACUNGCAP).Include(s => s.THUONGHIEU);
            return View(sANPHAMs.ToList());
        }

        // GET: SANPHAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MANCC = new SelectList(db.NHACUNGCAPs, "MANCC", "TENNCC");
            ViewBag.MATH = new SelectList(db.THUONGHIEUx, "MATH", "TENTH");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SANPHAM sp, HttpPostedFileBase uploadhinh)
        {
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                string proc = db.SANPHAMs.ToList().Last().TENSP.ToString();
                string FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                FileName = proc.ToLower().Replace(" ", "-")
                    + "." +
                    uploadhinh.FileName.Substring(index + 1);
                string path = Path.Combine(Server.MapPath("~/Images"), FileName);
                uploadhinh.SaveAs(path);

                SANPHAM usp = db.SANPHAMs.FirstOrDefault(x => x.TENSP == proc);
                usp.HINH = FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Create([Bind(Include = "MASP,TENSP,MATH,MANCC,MAUSAC,KICHCO,SL,MOTA,HINH,GIA")] SANPHAM sANPHAM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SANPHAMs.Add(sANPHAM);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MANCC = new SelectList(db.NHACUNGCAPs, "MANCC", "TENNCC", sANPHAM.MANCC);
        //    ViewBag.MATH = new SelectList(db.THUONGHIEUx, "MATH", "TENTH", sANPHAM.MATH);
        //    return View(sANPHAM);
        //}

        // GET: SANPHAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANCC = new SelectList(db.NHACUNGCAPs, "MANCC", "TENNCC", sANPHAM.MANCC);
            ViewBag.MATH = new SelectList(db.THUONGHIEUx, "MATH", "TENTH", sANPHAM.MATH);
            return View(sANPHAM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,MATH,MANCC,MAUSAC,KICHCO,SL,MOTA,HINH,GIA")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANCC = new SelectList(db.NHACUNGCAPs, "MANCC", "TENNCC", sANPHAM.MANCC);
            ViewBag.MATH = new SelectList(db.THUONGHIEUx, "MATH", "TENTH", sANPHAM.MATH);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
