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
     [Authorize]
    public class zillalinkbuildingsController : Controller
    {
        private usercontext db = new usercontext();

        // GET: zillalinkbuildings
        public ActionResult Index()
        {
            var zillaxes = db.zillaxes.Include(zl => zl.order);
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
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno");
            return View();
        }

        // POST: zillalinkbuildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,url1,url2,url3,keyword1a,keyword1b,keyword2a,keyword2b,keyword3a,keyword3b,cloudurl")] zillalinkbuilding zillalinkbuilding)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.zillalinkbuildings.Add(zillalinkbuilding);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(zillalinkbuilding);
        //}

        public ActionResult Create(List<zillalinkbuilding> zillalinkbuildings_f, string url, string amount)
        {
            if (zillalinkbuildings_f != null)
            {
                //create an order for blog 
                order order = new order();
                int last = findlast() + 111;
                order.orderno = "SZ" + last;
                order.orderdate = DateTime.Now;
                order.service = "zillalinkbuilding";
                order.status = status.awaiting_payment;
                order.userID = db.users.Where(u => u.email == User.Identity.Name).FirstOrDefault().ID;
                db.orders.Add(order);
                db.SaveChanges();
                if (ModelState.IsValid)
                {

                    foreach (zillalinkbuilding zillalinkbuilding in zillalinkbuildings_f)
                    {

                        zillalinkbuilding.orderID = findlast(); //assign last(i.e. above) order ID to blog OrderID
                        Session["orderID"] = findlast();
                        Session["amount"] = amount;
                        db.zillalinkbuildings.Add(zillalinkbuilding);
                    }
                    db.SaveChanges();
                    //return RedirectToAction("Index", "orders");
                    return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/test_plan");
                    //return Redirect(url);
                }
            }

            return View(zillalinkbuildings_f);
        }

        [NonAction]
        public int findlast()
        {

            return Convert.ToInt32(db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('order')").First());
        }

        // GET: zillalinkbuildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillalinkbuilding zillalinkbuilding = db.zillalinkbuildings.Find(id);
            if (User.IsInRole("Admin"))
            {
                if (zillalinkbuilding == null)
                {
                    return HttpNotFound();
                }
                ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillalinkbuilding.orderID);
                return View(zillalinkbuilding);
            }
            else
            {
                if (zillalinkbuilding == null)
                {
                    return HttpNotFound();
                }
                return View(zillalinkbuilding);
            }
        }

        // POST: zillalinkbuildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,plan,url1,url2,url3,keyword1a,keyword1b,keyword2a,keyword2b,keyword3a,keyword3b,cloudurl,orderID")] zillalinkbuilding zillalinkbuilding)
        {
            int orderid = zillalinkbuilding.orderID;
            if (ModelState.IsValid)
            {
                db.Entry(zillalinkbuilding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "orders", new { @id = orderid });
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
