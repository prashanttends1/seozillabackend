using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seozillabackend.DAL;
using seozillabackend.Models;

namespace seozillabackend.Controllers
{
    public class zillablogsController : Controller
    {
        private usercontext db = new usercontext();

        // GET: zillablogs
        public ActionResult Index()
        {
            var zillablogs = db.zillablogs.Include(z => z.order);
            return View(zillablogs.ToList());
        }

        // GET: zillablogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillablog zillablog = db.zillablogs.Find(id);
            if (zillablog == null)
            {
                return HttpNotFound();
            }
            return View(zillablog);
        }

        // GET: zillablogs/Create
        public ActionResult Create()
        {
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno");
            return View();
        }

        // POST: zillablogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,words,quantity,title,website,brief,orderID")] zillablog zillablog)
        {
            if (ModelState.IsValid)
            {
                db.zillablogs.Add(zillablog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillablog.orderID);
            return View(zillablog);
        }

        // GET: zillablogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillablog zillablog = db.zillablogs.Find(id);
            if (zillablog == null)
            {
                return HttpNotFound();
            }
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillablog.orderID);
            return View(zillablog);
        }

        // POST: zillablogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,words,quantity,title,website,brief,orderID")] zillablog zillablog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zillablog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillablog.orderID);
            return View(zillablog);
        }

        // GET: zillablogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillablog zillablog = db.zillablogs.Find(id);
            if (zillablog == null)
            {
                return HttpNotFound();
            }
            return View(zillablog);
        }

        // POST: zillablogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zillablog zillablog = db.zillablogs.Find(id);
            db.zillablogs.Remove(zillablog);
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
