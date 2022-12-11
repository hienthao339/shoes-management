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
    public class THANHTOANsController : Controller
    {
        private Entities db = new Entities();

        // GET: THANHTOANs
        public ActionResult Index()
        {
            var tHANHTOANs = db.THANHTOANs.Include(t => t.HOADON).Include(t => t.THE);
            return View(tHANHTOANs.ToList());
        }

        // GET: THANHTOANs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHTOAN tHANHTOAN = db.THANHTOANs.Find(id);
            if (tHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHTOAN);
        }

        // GET: THANHTOANs/Create
        public ActionResult Create()
        {
            ViewBag.MAHD = new SelectList(db.HOADONs, "MAHD", "MAHD");
            ViewBag.MATHE = new SelectList(db.THEs, "MATHE", "SOTHE");
            return View();
        }

        // POST: THANHTOANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATT,MAHD,MATHE,NGAYTHANHTOAN,SOTIEN,HINHTHUCTHANHTOAN")] THANHTOAN tHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.THANHTOANs.Add(tHANHTOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHD = new SelectList(db.HOADONs, "MAHD", "MAHD", tHANHTOAN.MAHD);
            ViewBag.MATHE = new SelectList(db.THEs, "MATHE", "SOTHE", tHANHTOAN.MATHE);
            return View(tHANHTOAN);
        }

        // GET: THANHTOANs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHTOAN tHANHTOAN = db.THANHTOANs.Find(id);
            if (tHANHTOAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHD = new SelectList(db.HOADONs, "MAHD", "MAHD", tHANHTOAN.MAHD);
            ViewBag.MATHE = new SelectList(db.THEs, "MATHE", "SOTHE", tHANHTOAN.MATHE);
            return View(tHANHTOAN);
        }

        // POST: THANHTOANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATT,MAHD,MATHE,NGAYTHANHTOAN,SOTIEN,HINHTHUCTHANHTOAN")] THANHTOAN tHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHANHTOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHD = new SelectList(db.HOADONs, "MAHD", "MAHD", tHANHTOAN.MAHD);
            ViewBag.MATHE = new SelectList(db.THEs, "MATHE", "SOTHE", tHANHTOAN.MATHE);
            return View(tHANHTOAN);
        }

        // GET: THANHTOANs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHTOAN tHANHTOAN = db.THANHTOANs.Find(id);
            if (tHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHTOAN);
        }

        // POST: THANHTOANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THANHTOAN tHANHTOAN = db.THANHTOANs.Find(id);
            db.THANHTOANs.Remove(tHANHTOAN);
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
