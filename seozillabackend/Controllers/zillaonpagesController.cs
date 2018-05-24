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
    public class zillaonpagesController : Controller
    {
        private usercontext db = new usercontext();

        // GET: zillaonpages
        public ActionResult Index()
        {
            var zillaonpages = db.zillaonpages.Include(zo => zo.order);
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
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno");
            return View();
        }
        [NonAction]
        public int findlast()
        {

            return Convert.ToInt32(db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('order')").First());
        }
        //[ChildActionOnly]
        //public ActionResult updatedetails(int id)
        //{

        //    zillablog zillablog = db.zillablogs.Find(id);
        //    if (User.IsInRole("Admin"))
        //        return PartialView("_adminzillablogupdatedetails", zillablog);
        //    else
        //        return PartialView("_zillablogupdatedetails", zillablog);

        //}
        // POST: zillaonpages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<zillaonpage> zillaonpages_f, string url, string amount)
        {
            if (zillaonpages_f != null)
            {
                //create an order for blog 
                order order = new order();
                int last = findlast() + 111;
                order.orderno = "SZ" + last;
                order.orderdate = DateTime.Now;
                order.service = "zillaonpage";
                order.status = status.awaiting_payment;
                order.userID = db.users.Where(u => u.email == User.Identity.Name).FirstOrDefault().ID;
                db.orders.Add(order);
                db.SaveChanges();
                if (ModelState.IsValid)
                {

                    foreach (zillaonpage zillaonpage in zillaonpages_f)
                    {

                        zillaonpage.orderID = findlast(); //assign last(i.e. above) order ID to blog OrderID
                        Session["orderID"] = findlast();
                        Session["amount"] = amount;
                        db.zillaonpages.Add(zillaonpage);
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
            return View(zillaonpages_f);
        }
        //public ActionResult Create([Bind(Include = "ID,plan,pageurl,primekeyword,secondarykeyword,targetlocation")] zillaonpage zillaonpage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.zillaonpages.Add(zillaonpage);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(zillaonpage);
        //}

        // GET: zillaonpages/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zillaonpage zillaonpage = db.zillaonpages.Find(id);
            if (User.IsInRole("Admin"))
            {
                if (zillaonpage == null)
                {
                    return HttpNotFound();
                }
                ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillaonpage.orderID);
                return View(zillaonpage);
            }
            else
            {
                if (User.Identity.Name == zillaonpage.order.user.email)
                {
                    if (zillaonpage == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillaonpage.orderID);
                    return View(zillaonpage);
                }
                else
                {

                    return RedirectToAction("AccessDenied", "Authentication");
                    //return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

                }
            }
        }
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    zillaonpage zillaonpage = db.zillaonpages.Find(id);
        //    if (zillaonpage == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillaonpage.orderID);
        //    return View(zillaonpage);
        //}

        // POST: zillaonpages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,plan,pageurl,primekeyword,secondarykeyword,targetlocation,orderID")] zillaonpage zillaonpage)
        {
            int orderid = zillaonpage.orderID;
            if (ModelState.IsValid)
            {
                db.Entry(zillaonpage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "orders", new { @id = orderid });
            }
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", zillaonpage.orderID);
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
