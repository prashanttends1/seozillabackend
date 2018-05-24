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
    public class zillalinkbuildingsController : Controller
    {
        private usercontext db = new usercontext();

        // GET: zillalinkbuildings
        public ActionResult Index()
        {
            return View(db.zillalinkbuildings.ToList());
        }

        // GET: zillalinkbuildings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillalinkbuilding zillalinkbuilding = db.zillalinkbuildings.Find(id);
            if (zillalinkbuilding == null)
            {
                return HttpNotFound();
            }
            return View(zillalinkbuilding);
        }

        // GET: zillalinkbuildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: zillalinkbuildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,url1,url2,url3,keyword1a,keyword1b,keyword2a,keyword2b,keyword3a,keyword3b,cloudurl")] zillalinkbuilding zillalinkbuilding)
        {
            if (ModelState.IsValid)
            {
                db.zillalinkbuildings.Add(zillalinkbuilding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zillalinkbuilding);
        }

        // GET: zillalinkbuildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillalinkbuilding zillalinkbuilding = db.zillalinkbuildings.Find(id);
            if (zillalinkbuilding == null)
            {
                return HttpNotFound();
            }
            return View(zillalinkbuilding);
        }

        // POST: zillalinkbuildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,url1,url2,url3,keyword1a,keyword1b,keyword2a,keyword2b,keyword3a,keyword3b,cloudurl")] zillalinkbuilding zillalinkbuilding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zillalinkbuilding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zillalinkbuilding);
        }

        // GET: zillalinkbuildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillalinkbuilding zillalinkbuilding = db.zillalinkbuildings.Find(id);
            if (zillalinkbuilding == null)
            {
                return HttpNotFound();
            }
            return View(zillalinkbuilding);
        }

        // POST: zillalinkbuildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zillalinkbuilding zillalinkbuilding = db.zillalinkbuildings.Find(id);
            db.zillalinkbuildings.Remove(zillalinkbuilding);
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
