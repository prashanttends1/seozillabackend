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
    public class citationsController : Controller
    {
        private usercontext db = new usercontext();

        // GET: citations
        public ActionResult Index()
        {
            var citations = db.citations.Include(c => c.order);
            return View(citations.ToList());
        }

        // GET: citations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citation citation = db.citations.Find(id);
            if (citation == null)
            {
                return HttpNotFound();
            }
            return View(citation);
        }

        // GET: citations/Create
        public ActionResult Create()
        {
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno");
            return View();
        }

        // POST: citations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,country,businessname,websiteurl,businessdescription,keywords,founder,address,phone,email,orderID")] citation citation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.citations.Add(citation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", citation.orderID);
        //    return View(citation);
        //}

             [NonAction]
        public int findlast()
        {

            return Convert.ToInt32( db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('order')").First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<citation> citations_f)
        {
            
            //create an order for citation 
            order order = new order();
            int last = findlast()+111;
            order.orderno = "SZ" + last;
            order.orderdate = DateTime.Now;
            order.service = "citation";
            order.status = status.awaiting_payment;
            order.userID = 1;
            
            db.orders.Add(order);
            db.SaveChanges();
            if (ModelState.IsValid)
            {

                foreach (citation citation in citations_f)
                {

                    citation.orderID = findlast(); //assign last(i.e. above) order ID to citation OrderID
                    db.citations.Add(citation);
                }
                db.SaveChanges();
                return RedirectToAction("Index", "orders");
            }
            return View(citations_f);
        }


        // GET: citations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citation citation = db.citations.Find(id);
            if (citation == null)
            {
                return HttpNotFound();
            }
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", citation.orderID);
            return View(citation);
        }

        // POST: citations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,country,businessname,websiteurl,businessdescription,keywords,founder,address,phone,email,orderID")] citation citation)
        {
            int orderid = citation.orderID;

            if (ModelState.IsValid)
            {
                db.Entry(citation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "orders", new { @id = orderid });
            }
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", citation.orderID);
            return View(citation);
        }

        // GET: citations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citation citation = db.citations.Find(id);
            if (citation == null)
            {
                return HttpNotFound();
            }
            return View(citation);
        }

        // POST: citations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            citation citation = db.citations.Find(id);
            db.citations.Remove(citation);
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
