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
    public class CHITIETDHsController : Controller
    {
        private Entities db = new Entities();

        // GET: CHITIETDHs
        public ActionResult Index()
        {
            var cHITIETDHs = db.CHITIETDHs.Include(c => c.DATHANG).Include(c => c.SANPHAM);
            return View(cHITIETDHs.ToList());
        }

        // GET: CHITIETDHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDH cHITIETDH = db.CHITIETDHs.Find(id);
            if (cHITIETDH == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDH);
        }

        // GET: CHITIETDHs/Create
        public ActionResult Create()
        {
            ViewBag.MADH = new SelectList(db.DATHANGs, "MADH", "GHICHU");
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP");
            return View();
        }

        // POST: CHITIETDHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MACTDH,MADH,MASP,SL")] CHITIETDH cHITIETDH)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDHs.Add(cHITIETDH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MADH = new SelectList(db.DATHANGs, "MADH", "GHICHU", cHITIETDH.MADH);
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", cHITIETDH.MASP);
            return View(cHITIETDH);
        }

        // GET: CHITIETDHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDH cHITIETDH = db.CHITIETDHs.Find(id);
            if (cHITIETDH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MADH = new SelectList(db.DATHANGs, "MADH", "GHICHU", cHITIETDH.MADH);
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", cHITIETDH.MASP);
            return View(cHITIETDH);
        }

        // POST: CHITIETDHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MACTDH,MADH,MASP,SL")] CHITIETDH cHITIETDH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MADH = new SelectList(db.DATHANGs, "MADH", "GHICHU", cHITIETDH.MADH);
            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP", cHITIETDH.MASP);
            return View(cHITIETDH);
        }

        // GET: CHITIETDHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDH cHITIETDH = db.CHITIETDHs.Find(id);
            if (cHITIETDH == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDH);
        }

        // POST: CHITIETDHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETDH cHITIETDH = db.CHITIETDHs.Find(id);
            db.CHITIETDHs.Remove(cHITIETDH);
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
