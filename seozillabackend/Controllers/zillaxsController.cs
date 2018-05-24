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
    public class zillaxsController : Controller
    {
        private usercontext db = new usercontext();

        // GET: zillaxs
        public ActionResult Index()
        {
            return View(db.zillaxes.ToList());
        }

        // GET: zillaxs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillax zillax = db.zillaxes.Find(id);
            if (zillax == null)
            {
                return HttpNotFound();
            }
            return View(zillax);
        }

        // GET: zillaxs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: zillaxs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,keyword1,keyword2,keyword3,competitor1,competitor2,competitor3,targetlocation,otherinfo")] zillax zillax)
        {
            if (ModelState.IsValid)
            {
                db.zillaxes.Add(zillax);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zillax);
        }

        // GET: zillaxs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillax zillax = db.zillaxes.Find(id);
            if (zillax == null)
            {
                return HttpNotFound();
            }
            return View(zillax);
        }

        // POST: zillaxs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,keyword1,keyword2,keyword3,competitor1,competitor2,competitor3,targetlocation,otherinfo")] zillax zillax)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zillax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zillax);
        }

        // GET: zillaxs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillax zillax = db.zillaxes.Find(id);
            if (zillax == null)
            {
                return HttpNotFound();
            }
            return View(zillax);
        }

        // POST: zillaxs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zillax zillax = db.zillaxes.Find(id);
            db.zillaxes.Remove(zillax);
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
