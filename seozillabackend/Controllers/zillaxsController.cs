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
    public class zillaxsController : Controller
    {
        private usercontext db = new usercontext();

        // GET: zillaxs
        public ActionResult Index()
        {
            var zillaxes = db.zillaxes.Include(zx => zx.order);
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
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno");
            return View();
        }

        // POST: zillaxs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      

        public ActionResult Create(List<zillax> zillaxes_f, string url, string amount)
        {
            if (zillaxes_f != null)
            {
                //create an order for blog 
                order order = new order();
                int last = findlast() + 111;
                order.orderno = "SZ" + last;
                order.orderdate = DateTime.Now;
                order.service = "zillax";
                order.status = status.awaiting_payment;
                order.userID = db.users.Where(u => u.email == User.Identity.Name).FirstOrDefault().ID;
                db.orders.Add(order);
                db.SaveChanges();
                if (ModelState.IsValid)
                {

                    foreach (zillax zillax in zillaxes_f)
                    {

                        zillax.orderID = findlast(); //assign last(i.e. above) order ID to blog OrderID
                        Session["orderID"] = findlast();
                        Session["amount"] = amount;
                        db.zillaxes.Add(zillax);
                    }
                    db.SaveChanges();
                    //return RedirectToAction("Index", "orders");
                    return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/test_plan");
                    //return Redirect(url);
                }
            }

            return View(zillaxes_f);
        }


        [NonAction]
        public int findlast()
        {

            return Convert.ToInt32(db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('order')").First());
        }
        // GET: zillaxs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillax zillax = db.zillaxes.Find(id);
            if (User.IsInRole("Admin"))
            {
                if (zillax == null)
                {
                    return HttpNotFound();
                }
                ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillax.orderID);
                return View(zillax);
            }
            else
            {
                if (User.Identity.Name == zillax.order.user.email)
                {
                    if (zillax == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillax.orderID);
                    return View(zillax);
                }
                else
                {

                    return RedirectToAction("AccessDenied", "Authentication");
                    //return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

                }
            }
        }

        // POST: zillaxs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,plan,keyword1,keyword2,keyword3,competitor1,competitor2,competitor3,targetlocation,otherinfo,orderID")] zillax zillax)
        {
            int orderid = zillax.orderID;
            if (ModelState.IsValid)
            {
                db.Entry(zillax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "orders", new { @id = orderid });
            }
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillax.orderID);
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
