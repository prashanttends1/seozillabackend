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

        [NonAction]
        public int findlast()
        {

            return Convert.ToInt32(db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('order')").First());
        }
         [ChildActionOnly]
        public ActionResult updatedetails(int id)
        {

            zillablog zillablog = db.zillablogs.Find(id);
            if (User.IsInRole("Admin"))
                return PartialView("_adminzillablogupdatedetails", zillablog);
            else
                return PartialView("_zillablogupdatedetails", zillablog);
         
        }

        // POST: zillablogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<zillablog> zillablogs_f, string url, string amount)
        {
            if (zillablogs_f != null)
            {
                //create an order for blog 
                order order = new order();
                int last = findlast() + 111;
                order.orderno = "SZ" + last;
                order.orderdate = DateTime.Now;
                order.service = "zillablog";
                order.status = status.awaiting_payment;
                order.userID = db.users.Where(u => u.email == User.Identity.Name).FirstOrDefault().ID;
                db.orders.Add(order);
                db.SaveChanges();
                if (ModelState.IsValid)
                {

                    foreach (zillablog zillablog in zillablogs_f)
                    {

                        zillablog.orderID = findlast(); //assign last(i.e. above) order ID to blog OrderID
                        Session["orderID"] = findlast();
                        Session["amount"] = amount;
                        db.zillablogs.Add(zillablog);
                    }
                    db.SaveChanges();
                    //return RedirectToAction("Index", "orders");
                    return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/test_plan");
                    //return Redirect(url);
                }
            }

            //foreach (blog blog in blogs_f)
            //{
            //    ViewData["[0].orderID"] = new SelectList(db.orders, "ID", "orderno", blog.orderID);
            //    ViewData["[1].orderID"] = new SelectList(db.orders, "ID", "orderno", blog.orderID);

            //    //ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", blog.orderID);
            //    //ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", blog.orderID);


            //}
            return View(zillablogs_f);
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
            int orderid = zillablog.orderID;

            if (ModelState.IsValid)
            {
                db.Entry(zillablog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "orders", new { @id = orderid });
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
