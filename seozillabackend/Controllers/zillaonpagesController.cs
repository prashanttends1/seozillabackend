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
    public class zillaonpagesController : Controller
    {
        private usercontext db = new usercontext();

        // GET: zillaonpages
        public ActionResult Index()
        {
            return View(db.zillaonpages.ToList());
        }

        // GET: zillaonpages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillaonpage zillaonpage = db.zillaonpages.Find(id);
            if (zillaonpage == null)
            {
                return HttpNotFound();
            }
            return View(zillaonpage);
        }

        // GET: zillaonpages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: zillaonpages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,plan,pageurl,primekeyword,secondarykeyword,targetlocation")] zillaonpage zillaonpage)
        {
            if (ModelState.IsValid)
            {
                db.zillaonpages.Add(zillaonpage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zillaonpage);
        }

        // GET: zillaonpages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillaonpage zillaonpage = db.zillaonpages.Find(id);
            if (zillaonpage == null)
            {
                return HttpNotFound();
            }
            return View(zillaonpage);
        }

        // POST: zillaonpages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,plan,pageurl,primekeyword,secondarykeyword,targetlocation")] zillaonpage zillaonpage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zillaonpage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zillaonpage);
        }

        // GET: zillaonpages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillaonpage zillaonpage = db.zillaonpages.Find(id);
            if (zillaonpage == null)
            {
                return HttpNotFound();
            }
            return View(zillaonpage);
        }

        // POST: zillaonpages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zillaonpage zillaonpage = db.zillaonpages.Find(id);
            db.zillaonpages.Remove(zillaonpage);
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
