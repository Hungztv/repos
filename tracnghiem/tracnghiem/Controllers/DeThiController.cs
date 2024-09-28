using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tracnghiem.Models;

namespace tracnghiem.Controllers
{
    public class DeThiController : Controller
    {
        private tracnghiemEntities db = new tracnghiemEntities();

        // GET: DeThis
        public ActionResult Index()
        {
            return View(db.DeThis.ToList());
        }

        // GET: DeThis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
            if (deThi == null)
            {
                return HttpNotFound();
            }
            return View(deThi);
        }

        // GET: DeThis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeThis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NgayThi,ThoiGianThi,SoLuongCauHoi")] DeThi deThi)
        {
            if (ModelState.IsValid)
            {
                db.DeThis.Add(deThi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deThi);
        }

        // GET: DeThis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
            if (deThi == null)
            {
                return HttpNotFound();
            }
            return View(deThi);
        }

        // POST: DeThis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NgayThi,ThoiGianThi,SoLuongCauHoi")] DeThi deThi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deThi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deThi);
        }

        // GET: DeThis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
            if (deThi == null)
            {
                return HttpNotFound();
            }
            return View(deThi);
        }

        // POST: DeThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeThi deThi = db.DeThis.Find(id);
            db.DeThis.Remove(deThi);
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
