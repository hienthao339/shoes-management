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
    public class KHUYENMAIsController : Controller
    {
        private Entities db = new Entities();

        // GET: KHUYENMAIs
        public ActionResult Index()
        {
            return View(db.KHUYENMAIs.ToList());
        }

        // GET: KHUYENMAIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUYENMAI kHUYENMAI = db.KHUYENMAIs.Find(id);
            if (kHUYENMAI == null)
            {
                return HttpNotFound();
            }
            return View(kHUYENMAI);
        }

        // GET: KHUYENMAIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KHUYENMAIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKM,TENKM,TRIGIA,NGAYBD,NGAYKT")] KHUYENMAI kHUYENMAI)
        {
            if (ModelState.IsValid)
            {
                db.KHUYENMAIs.Add(kHUYENMAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHUYENMAI);
        }

        // GET: KHUYENMAIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUYENMAI kHUYENMAI = db.KHUYENMAIs.Find(id);
            if (kHUYENMAI == null)
            {
                return HttpNotFound();
            }
            return View(kHUYENMAI);
        }

        // POST: KHUYENMAIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKM,TENKM,TRIGIA,NGAYBD,NGAYKT")] KHUYENMAI kHUYENMAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHUYENMAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHUYENMAI);
        }

        // GET: KHUYENMAIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUYENMAI kHUYENMAI = db.KHUYENMAIs.Find(id);
            if (kHUYENMAI == null)
            {
                return HttpNotFound();
            }
            return View(kHUYENMAI);
        }

        // POST: KHUYENMAIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHUYENMAI kHUYENMAI = db.KHUYENMAIs.Find(id);
            db.KHUYENMAIs.Remove(kHUYENMAI);
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
