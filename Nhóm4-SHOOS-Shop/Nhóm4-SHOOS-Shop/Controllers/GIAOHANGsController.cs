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
    public class GIAOHANGsController : Controller
    {
        private Entities db = new Entities();

        // GET: GIAOHANGs
        public ActionResult Index()
        {
            var gIAOHANGs = db.GIAOHANGs.Include(g => g.THANHTOAN);
            return View(gIAOHANGs.ToList());
        }

        // GET: GIAOHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOHANG gIAOHANG = db.GIAOHANGs.Find(id);
            if (gIAOHANG == null)
            {
                return HttpNotFound();
            }
            return View(gIAOHANG);
        }

        // GET: GIAOHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MATT = new SelectList(db.THANHTOANs, "MATT", "HINHTHUCTHANHTOAN");
            return View();
        }

        // POST: GIAOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAGH,MATT,TENTAIXE,NGAYGIAO,DAGIAO,DATHANHTOAN")] GIAOHANG gIAOHANG)
        {
            if (ModelState.IsValid)
            {
                db.GIAOHANGs.Add(gIAOHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATT = new SelectList(db.THANHTOANs, "MATT", "HINHTHUCTHANHTOAN", gIAOHANG.MATT);
            return View(gIAOHANG);
        }

        // GET: GIAOHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOHANG gIAOHANG = db.GIAOHANGs.Find(id);
            if (gIAOHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATT = new SelectList(db.THANHTOANs, "MATT", "HINHTHUCTHANHTOAN", gIAOHANG.MATT);
            return View(gIAOHANG);
        }

        // POST: GIAOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAGH,MATT,TENTAIXE,NGAYGIAO,DAGIAO,DATHANHTOAN")] GIAOHANG gIAOHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIAOHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATT = new SelectList(db.THANHTOANs, "MATT", "HINHTHUCTHANHTOAN", gIAOHANG.MATT);
            return View(gIAOHANG);
        }

        // GET: GIAOHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOHANG gIAOHANG = db.GIAOHANGs.Find(id);
            if (gIAOHANG == null)
            {
                return HttpNotFound();
            }
            return View(gIAOHANG);
        }

        // POST: GIAOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GIAOHANG gIAOHANG = db.GIAOHANGs.Find(id);
            db.GIAOHANGs.Remove(gIAOHANG);
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
