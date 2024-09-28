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
    public class CauHoiController : Controller
    {
        private tracnghiemEntities db = new tracnghiemEntities();

        // GET: CauHoi
        public ActionResult Index()
        {
            var cauHois = db.CauHois.Include(c => c.DapAn).Include(c => c.MonHoc).Include(c => c.MucDoKho);
            return View(cauHois.ToList());
        }

        // GET: CauHoi/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHois cauHois = db.CauHois.Find(id);
            if (cauHois == null)
            {
                return HttpNotFound();
            }
            return View(cauHois);
        }

        // GET: CauHoi/Create
        public ActionResult Create()
        {
            ViewBag.MaDapAn = new SelectList(db.DapAns, "id", "DapAn1");
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "id", "TenMonHoc");
            ViewBag.MaMucDo = new SelectList(db.MucDoKhos, "id", "TenMucDo");
            return View();
        }

        // POST: CauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Cauhoi,dap_an_a,dap_an_b,dap_an_c,dap_an_d,MaDapAn,ghi_chu,MaMonHoc,MaMucDo")] CauHois cauHois)
        {
            if (ModelState.IsValid)
            {
                db.CauHois.Add(cauHois);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDapAn = new SelectList(db.DapAns, "id", "DapAn1", cauHois.MaDapAn);
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "id", "TenMonHoc", cauHois.MaMonHoc);
            ViewBag.MaMucDo = new SelectList(db.MucDoKhos, "id", "TenMucDo", cauHois.MaMucDo);
            return View(cauHois);
        }

        // GET: CauHoi/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHois cauHois = db.CauHois.Find(id);
            if (cauHois == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDapAn = new SelectList(db.DapAns, "id", "DapAn1", cauHois.MaDapAn);
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "id", "TenMonHoc", cauHois.MaMonHoc);
            ViewBag.MaMucDo = new SelectList(db.MucDoKhos, "id", "TenMucDo", cauHois.MaMucDo);
            return View(cauHois);
        }

        // POST: CauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Cauhoi,dap_an_a,dap_an_b,dap_an_c,dap_an_d,MaDapAn,ghi_chu,MaMonHoc,MaMucDo")] CauHois cauHois)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cauHois).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDapAn = new SelectList(db.DapAns, "id", "DapAn1", cauHois.MaDapAn);
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "id", "TenMonHoc", cauHois.MaMonHoc);
            ViewBag.MaMucDo = new SelectList(db.MucDoKhos, "id", "TenMucDo", cauHois.MaMucDo);
            return View(cauHois);
        }

        // GET: CauHoi/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHois cauHois = db.CauHois.Find(id);
            if (cauHois == null)
            {
                return HttpNotFound();
            }
            return View(cauHois);
        }

        // POST: CauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CauHois cauHois = db.CauHois.Find(id);
            db.CauHois.Remove(cauHois);
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
