using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT100720_59130033.Models;

namespace KT100720_59130033.Controllers
{
    public class TaiSan_59130033Controller : Controller
    {
        private KT100720_59130033Entities db = new KT100720_59130033Entities();

        // GET: TaiSan_59130033
        public ActionResult Index()
        {
            var tAISANs = db.TAISANs.Include(t => t.LOAIT);
            return View(tAISANs.ToList());
        }

        // GET: TaiSan_59130033/Details/5/123
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAISAN tAISAN = db.TAISANs.Find(id);
            if (tAISAN == null)
            {
                return HttpNotFound();
            }
            return View(tAISAN);
        }

        // GET: TaiSan_59130033/Create
        public ActionResult Create()
        {
            ViewBag.MaLTS = new SelectList(db.LOAITS, "MaLTS", "TenLTS");
            return View();
        }

        // POST: TaiSan_59130033/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTS,TenTS,DVT,XuatXu,DonGia,AnhMH,GhiChu,MaLTS")] TAISAN tAISAN)
        {
            if (ModelState.IsValid)
            {
                db.TAISANs.Add(tAISAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLTS = new SelectList(db.LOAITS, "MaLTS", "TenLTS", tAISAN.MaLTS);
            return View(tAISAN);
        }

        // GET: TaiSan_59130033/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAISAN tAISAN = db.TAISANs.Find(id);
            if (tAISAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLTS = new SelectList(db.LOAITS, "MaLTS", "TenLTS", tAISAN.MaLTS);
            return View(tAISAN);
        }

        // POST: TaiSan_59130033/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTS,TenTS,DVT,XuatXu,DonGia,AnhMH,GhiChu,MaLTS")] TAISAN tAISAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAISAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLTS = new SelectList(db.LOAITS, "MaLTS", "TenLTS", tAISAN.MaLTS);
            return View(tAISAN);
        }

        // GET: TaiSan_59130033/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAISAN tAISAN = db.TAISANs.Find(id);
            if (tAISAN == null)
            {
                return HttpNotFound();
            }
            return View(tAISAN);
        }

        // POST: TaiSan_59130033/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAISAN tAISAN = db.TAISANs.Find(id);
            db.TAISANs.Remove(tAISAN);
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
