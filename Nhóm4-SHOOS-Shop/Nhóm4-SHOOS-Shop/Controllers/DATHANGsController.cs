using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhóm4_SHOOS_Shop.Models;

namespace Nhóm4_SHOOS_Shop.Controllers
{
    public class DATHANGsController : Controller
    {
        private Entities db = new Entities();

        // GET: DATHANGs
        public ActionResult Index()
        {
            var dATHANGs = db.DATHANGs.Include(d => d.GIAOHANG).Include(d => d.KHACHHANG).Include(d => d.KHUYENMAI);
            return View(dATHANGs.ToList());
        }

        // GET: DATHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATHANG dATHANG = db.DATHANGs.Find(id);
            if (dATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dATHANG);
        }

        // GET: DATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MAGH = new SelectList(db.GIAOHANGs, "MAGH", "TENTAIXE");
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "HOTEN");
            ViewBag.MAKM = new SelectList(db.KHUYENMAIs, "MAKM", "TENKM");
            return View();
        }

        // POST: DATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADH,MAKH,MAKM,MAGH,NGAYDAT,GHICHU,TONGTIEN")] DATHANG dATHANG)
        {
            if (ModelState.IsValid)
            {
                db.DATHANGs.Add(dATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAGH = new SelectList(db.GIAOHANGs, "MAGH", "TENTAIXE", dATHANG.MAGH);
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "HOTEN", dATHANG.MAKH);
            ViewBag.MAKM = new SelectList(db.KHUYENMAIs, "MAKM", "TENKM", dATHANG.MAKM);
            return View(dATHANG);
        }

        // GET: DATHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATHANG dATHANG = db.DATHANGs.Find(id);
            if (dATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAGH = new SelectList(db.GIAOHANGs, "MAGH", "TENTAIXE", dATHANG.MAGH);
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "HOTEN", dATHANG.MAKH);
            ViewBag.MAKM = new SelectList(db.KHUYENMAIs, "MAKM", "TENKM", dATHANG.MAKM);
            return View(dATHANG);
        }

        // POST: DATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADH,MAKH,MAKM,MAGH,NGAYDAT,GHICHU,TONGTIEN")] DATHANG dATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAGH = new SelectList(db.GIAOHANGs, "MAGH", "TENTAIXE", dATHANG.MAGH);
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "HOTEN", dATHANG.MAKH);
            ViewBag.MAKM = new SelectList(db.KHUYENMAIs, "MAKM", "TENKM", dATHANG.MAKM);
            return View(dATHANG);
        }

        // GET: DATHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATHANG dATHANG = db.DATHANGs.Find(id);
            if (dATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dATHANG);
        }

        // POST: DATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DATHANG dATHANG = db.DATHANGs.Find(id);
            db.DATHANGs.Remove(dATHANG);
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
