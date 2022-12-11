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
    public class THEsController : Controller
    {
        private Entities db = new Entities();

        // GET: THEs
        public ActionResult Index()
        {
            return View(db.THEs.ToList());
        }

        // GET: THEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THE tHE = db.THEs.Find(id);
            if (tHE == null)
            {
                return HttpNotFound();
            }
            return View(tHE);
        }

        // GET: THEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATHE,SOTHE,TENNGANHANG,CHUTAIKHOAN")] THE tHE)
        {
            if (ModelState.IsValid)
            {
                db.THEs.Add(tHE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHE);
        }

        // GET: THEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THE tHE = db.THEs.Find(id);
            if (tHE == null)
            {
                return HttpNotFound();
            }
            return View(tHE);
        }

        // POST: THEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATHE,SOTHE,TENNGANHANG,CHUTAIKHOAN")] THE tHE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHE);
        }

        // GET: THEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THE tHE = db.THEs.Find(id);
            if (tHE == null)
            {
                return HttpNotFound();
            }
            return View(tHE);
        }

        // POST: THEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THE tHE = db.THEs.Find(id);
            db.THEs.Remove(tHE);
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
