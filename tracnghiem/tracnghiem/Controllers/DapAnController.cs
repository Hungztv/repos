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
    public class DapAnController : Controller
    {
        private tracnghiemEntities db = new tracnghiemEntities();

        // GET: DapAn
        public ActionResult Index()
        {
            return View(db.DapAns.ToList());
        }

        // GET: DapAn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DapAn dapAn = db.DapAns.Find(id);
            if (dapAn == null)
            {
                return HttpNotFound();
            }
            return View(dapAn);
        }

        // GET: DapAn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DapAn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,DapAn1")] DapAn dapAn)
        {
            if (ModelState.IsValid)
            {
                db.DapAns.Add(dapAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dapAn);
        }

        // GET: DapAn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DapAn dapAn = db.DapAns.Find(id);
            if (dapAn == null)
            {
                return HttpNotFound();
            }
            return View(dapAn);
        }

        // POST: DapAn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,DapAn1")] DapAn dapAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dapAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dapAn);
        }

        // GET: DapAn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DapAn dapAn = db.DapAns.Find(id);
            if (dapAn == null)
            {
                return HttpNotFound();
            }
            return View(dapAn);
        }

        // POST: DapAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DapAn dapAn = db.DapAns.Find(id);
            db.DapAns.Remove(dapAn);
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
