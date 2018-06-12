using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seozillabackend.DAL;
using seozillabackend.Models;
using seozillabackend.Extensions;

namespace seozillabackend.Controllers
{
    
    public class ordersController : Controller
    {
        private usercontext db = new usercontext();

        [Authorize]
        // GET: current orders
        public ActionResult Index()
        {

            if (User.IsInRole("User"))
            {
                var orders = db.orders.Include(o => o.user).Where(o => o.status != status.cancelled && o.status != status.archived).Where(o => o.user.email == User.Identity.Name);

                return View(orders.ToList());
            }
            else
            {
                var orders = db.orders.Include(o => o.user).Where(o => o.status != status.cancelled).Where(o => o.status != status.archived);

                return View(orders.ToList());
            }
        }

        [Authorize]
        // GET: cancelled orders
        public ActionResult Cancelled()
        {
            if (User.IsInRole("User"))
            {
                var orders = db.orders.Include(o => o.user).Where(o => o.status == status.cancelled).Where(o => o.user.email == User.Identity.Name); 

                return View(orders.ToList());
            }
            else
            {
                var orders = db.orders.Include(o => o.user).Where(o => o.status == status.cancelled) ;
                return View(orders.ToList());
            }
        }
        [Authorize]
        // GET: archived orders
        public ActionResult Archived()
        {
            if (User.IsInRole("User"))
            {
                var orders = db.orders.Include(o => o.user).Where(o => o.status == status.archived).Where(o => o.user.email == User.Identity.Name);
                return View(orders.ToList());
            }
            else
            {
                var orders = db.orders.Include(o => o.user).Where(o => o.status == status.archived);
                return View(orders.ToList());
            }
        }
        [Authorize]
        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (User.IsInRole("User"))
            {
                var order = db.orders.Where(o => o.ID == id && o.user.email == User.Identity.Name).FirstOrDefault();
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
            else
            {
                var order = db.orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
           // Session["service"] = order.service;
           
        }
        [Authorize]
         //GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.userID = new SelectList(db.users, "ID", "firstname");
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,orderno,service,orderdate,duedate,status,comment,tags,userID")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            ViewBag.userID = new SelectList(db.users, "ID", "firstname", order.userID);
            return View(order);
        }
        
        [AccessDeniedAuthorize(Roles="Admin")]
        
        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (User.IsInRole("User"))
            {
                var order = db.orders.Where(o => o.ID == id && o.user.email == User.Identity.Name).FirstOrDefault();
                if (order == null)
                {
                    return HttpNotFound();
                }
                ViewBag.userID = new SelectList(db.users, "ID", "firstname", order.userID);
                return View(order);
            }
           else
            {
                var order = db.orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                ViewBag.userID = new SelectList(db.users, "ID", "firstname", order.userID);
                return View(order);
            }
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AccessDeniedAuthorize(Roles="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,orderno,service,orderdate,duedate,status,comment,tags,userID")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.users, "ID", "firstname", order.userID);
            return View(order);
        }
        [AccessDeniedAuthorize(Roles="Admin")]
        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        [AccessDeniedAuthorize(Roles = "Admin")]
        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        // GET: orders/Cancel/5
        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (User.IsInRole("User"))
            {
                order order = db.orders.Where(o => o.ID == id && o.user.email == User.Identity.Name).FirstOrDefault();
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
                
            }
            else
            {
                order order = db.orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
                
            }
        }
        [Authorize]
        // POST: orders/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public ActionResult CancelConfirmed(int id)
        {
            order order = db.orders.Find(id);
            order.status = status.cancelled;
            db.orders.AddOrUpdate(o=>o.ID, order);
            db.SaveChanges();
            return RedirectToAction("Cancelled");
        }
         [AccessDeniedAuthorize(Roles = "Admin")]
        // GET: orders/Cancel/5
        public ActionResult Archive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (User.IsInRole("User"))
            {
                order order = db.orders.Where(o => o.ID == id && o.user.email == User.Identity.Name).FirstOrDefault();
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
            else
            {
                order order = db.orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
        }
        [AccessDeniedAuthorize(Roles="Admin")]
        // POST: orders/Cancel/5
        [HttpPost, ActionName("Archive")]
        [ValidateAntiForgeryToken]
        public ActionResult ArchiveConfirmed(int id)
        {
            order order = db.orders.Find(id);
            order.status = status.archived;
            db.orders.AddOrUpdate(o => o.ID, order);
            db.SaveChanges();
            return RedirectToAction("Archived");
        }
        [Authorize]
        public ActionResult afterpayment(string invoicestatus, int invoiceamount)
        {

            if (invoicestatus == "Paid")
            {
                if (Session["orderID"] == null)
                    return Content("Invalid Session. Please try again.");
                else if (Query.findlast() == Convert.ToInt32(Session["orderID"]) && Convert.ToDouble(Session["amount"]) == invoiceamount/100)
                {
                    int id = Convert.ToInt32(Session["orderID"]);
                    order order = db.orders.Find(id);
                    order.status = status.payment_done;
                    db.orders.AddOrUpdate(o => o.ID, order);
                    db.SaveChanges();
                    Session["orderID"] = null;
                    return RedirectToAction("Index");
                }
                else
                    return Content("Invalid Session Error#2. Please try again.");
            }
            else if (invoicestatus == null)
                return Content("Cannot find order. Please try again.");
            else
                return Content(invoicestatus);
        }

        public ActionResult makepayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
                order order = db.orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                string service = order.service;
                if (service == "Zilla Local SEO")
                {
                    //int count = order.citations.Count;
                    String plan = order.citations.FirstOrDefault().plan;
                    if (plan == "Zilla Local Starter")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 125;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-local-starter");
                    }
                    if (plan == "Zilla Local Small")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 150;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-local-small");
                    }
                    if (plan == "Zilla Local Medium")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 260;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-local-medium");
                    }
                    if (plan == "Zilla Local Large")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 400;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-local-large");
                    }
                }
                if (service == "Zilla X")
                {
                    string plan = order.zillax.FirstOrDefault().plan;
                   
                    if (plan == "Zilla X 750")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 750;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-x-750-words");
                    }
                    if (plan == "Zilla X 1500")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1500;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-x-1500-words");
                    }
                    if (plan == "Zilla X 3000")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 3000;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-x-3000-words");
                    }
                }
                if (service == "Zilla Link Building")
                {
                    string plan = order.zillalinkbuildings.FirstOrDefault().plan;
                    int count = order.zillalinkbuildings.Count;

                    if (plan == "Bronze" && count == 5)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 350;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-link-bronze-5-pack");
                    }
                    if (plan == "Bronze" && count == 10)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 650;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-link-bronze-10-packs");
                    }

                    if (plan == "Silver" && count == 5)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 150;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-link-silver-5-packs");
                    }
                    if (plan == "Silver" && count == 10)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 260;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-link-silver-10-packs");
                    }

                    if (plan == "Gold" && count == 5)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 200;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-link-gold-5-packs");
                    }
                    if (plan == "Gold" && count == 10)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 375;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-link-gold-10-packs");
                    }
                }

                if (service == "Zilla Blog")
                {
                    string words = order.zillablogs.FirstOrDefault().words;


                    if (words == "1 x 500 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 30;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-1-x-500-word-article");
                    }
                    if (words == "1 x 1000 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 55;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-1-x-1000-word-article");
                    }

                    if (words == "1 x 1500 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 70;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-1-x-1500-word-article");
                    }
                    if (words == "1 x 2000 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 100;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-1-x-2000-word-article");
                    }

                    if (words == "2 x 500 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 50;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-2-x-500-word-article");
                    }
                    if (words == "2 x 1000 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 100;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-2-x-1000-word-article");
                    }
                    if (words == "2 x 1500 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 360;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-2-x-1500-word-article");
                    }
                    if (words == "2 x 2000 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 255;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-2-x-2000-word-article");
                    }


                    if (words == "4 x 500 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 90;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-4-x-500-word-article");
                    }
                    if (words == "4 x 1000 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 180;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-4-x-1000-word-article");
                    }

                    if (words == "4 x 1500 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 360;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-4-x-1500-word-article");
                    }
                    if (words == "4 x 2000 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 255;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-4-x-2000-word-article");
                    }

                    if (words == "8 x 500 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 180;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-8-x-500-word-article");
                    }
                    if (words == "8 x 1000 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 360;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-8-x-1000-word-article");
                    }
                    if (words == "8 x 1500 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 720;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-8-x-1500-word-article");
                    }
                    if (words == "8 x 2000 Words Article")
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 480;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-blogs-8-x-2000-word-article");
                    }

                }
                if (service == "Zilla On Page")
               {
                   string plan = order.zillaonpages.FirstOrDefault().plan;
                   int count = order.zillaonpages.Count;
                   if (plan == "2–4 Pages" && count == 2)
                   {
                       Session["orderID"] = id;
                       Session["amount"] = 160;
                       return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-2-pages");
                   }
                   if (plan == "2–4 Pages" && count == 3)
                   {
                       Session["orderID"] = id;
                       Session["amount"] = 240;
                       return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-3-pages");
                   }
                   if (plan == "2–4 Pages" && count == 4)
                   {
                       Session["orderID"] = id;
                       Session["amount"] = 320;
                       return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-4-pages");
                   }
                   if (plan == "5–9 Pages" && count == 5)
                   {
                       Session["orderID"] = id;
                       Session["amount"] = 375;
                       return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-5-pages");
                   }
                    if (plan == "5–9 Pages" && count == 6)
                   {
                       Session["orderID"] = id;
                       Session["amount"] = 450;
                       return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-6-pages");
                   }
                    if (plan == "5–9 Pages" && count == 7)
                   {
                       Session["orderID"] = id;
                       Session["amount"] = 525;
                       return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-7-pages");
                   }
                    if (plan == "5–9 Pages" && count == 8)
                   {
                       Session["orderID"] = id;
                       Session["amount"] = 600;
                       return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-8-pages");
                   }
                    if (plan == "5–9 Pages" && count == 9)
                   {
                       Session["orderID"] = id;
                       Session["amount"] = 675;
                       return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-9-pages");
                   }
                    if (plan == "10–19 Pages" && count == 10)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 700;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-10-pages");
                    }
                    if (plan == "10–19 Pages" && count == 11)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 770;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-11-pages");
                    }
                    if (plan == "10–19 Pages" && count == 12)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 840;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-12-pages");
                    }
                    if (plan == "10–19 Pages" && count == 13)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 910;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-13-pages");
                    }
                    if (plan == "10–19 Pages" && count == 14)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 980;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-14-pages");
                    }
                    if (plan == "10–19 Pages" && count == 15)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1050;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-15-pages");
                    }
                    if (plan == "10–19 Pages" && count == 16)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1120;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-16-pages");
                    }
                    if (plan == "10–19 Pages" && count == 17)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1190;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-17-pages");
                    }
                    if (plan == "10–19 Pages" && count == 18)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1260;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-18-pages");
                    }
                    if (plan == "10–19 Pages" && count == 19)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1330;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-19-pages");
                    }

                    if (plan == "20–30 Pages" && count == 20)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1300;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-20-pages");
                    }
                    if (plan == "20–30 Pages" && count == 21)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1365;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-21-pages");
                    }
                    if (plan == "20–30 Pages" && count == 22)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1430;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-22-pages");
                    }
                    if (plan == "20–30 Pages" && count == 23)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1495;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-23-pages");
                    }
                    if (plan == "20–30 Pages" && count == 24)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1560;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-24-pages");
                    }
                    if (plan == "20–30 Pages" && count == 25)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1625;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-25-pages");
                    }
                    if (plan == "20–30 Pages" && count == 26)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1690;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-26-pages");
                    }
                    if (plan == "20–30 Pages" && count == 27)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1755;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-27-pages");
                    }
                    if (plan == "20–30 Pages" && count == 28)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1820;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-28-pages");
                    }
                    if (plan == "20–30 Pages" && count == 29)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1885;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-29-pages");
                    }
                    if (plan == "20–30 Pages" && count == 30)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1950;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/zilla-on-page-30-pages");
                    }
               }

                if (service == "Zilla Guest Post")
                {
                    daordered daordered = order.blogs.FirstOrDefault().daordered;
                    int count = order.blogs.Count;
                    if (daordered == daordered.ten_plus && count == 1)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 75;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-da10%2B-1pack");
                    }
                    if (daordered == daordered.ten_plus && count == 5)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 350;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-da10%2B-5packs");
                    }
                    if (daordered == daordered.ten_plus && count == 10)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 650;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-da10%2B-10packs");
                    }
                    if (daordered == daordered.twenty_plus && count == 1)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 110;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-20%2B-1pack");
                    }
                    if (daordered == daordered.twenty_plus && count == 5)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 500;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-20%2B-5packs");
                    }
                    if (daordered == daordered.twenty_plus && count == 10)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 980;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-20%2B-10packs");
                    }
                    if (daordered == daordered.thirty_plus && count == 1)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 150;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-da30%2B-1packs");
                    }
                    if (daordered == daordered.thirty_plus && count == 5)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 670;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/-blogs-da30%2B5packs");
                    }
                    if (daordered == daordered.thirty_plus && count == 10)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1300;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-da30%2B-10packs");
                    }
                    if (daordered == daordered.forty_plus && count == 1)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 300;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-da40%2B-1pack");
                    }
                    if (daordered == daordered.forty_plus && count == 5)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 1350;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-da40%2B-5packs");
                    }
                    if (daordered == daordered.forty_plus && count == 10)
                    {
                        Session["orderID"] = id;
                        Session["amount"] = 2600;
                        return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/blogs-da40%2B-10packs");
                    }
                    else
                    {
                        return Content("Invalid Session. Please try again.");
                    }
                }
                else
                {
                    return Content("Invalid Service. Please try again.");
                }
            
        }

        [ChildActionOnly]
        public ActionResult actionlinks(int id)
        {

            //order order = db.orders.Find(id);
            if (User.IsInRole("Admin"))
                return PartialView("_adminlinks",id);
            else
                return new EmptyResult();

        }

        [ChildActionOnly]
        public ActionResult emailheading()
        {

            //order order = db.orders.Find(id);
            if (User.IsInRole("Admin"))
                return PartialView("_emailheading");
            else
                return new EmptyResult();

        }

        [ChildActionOnly]
        public ActionResult emailvalues(string email)
        {

            //order order = db.orders.Find(id);
            if (User.IsInRole("Admin"))
                return PartialView("_emailvalues", email);
            else
                return new EmptyResult();

        }

        [ChildActionOnly]
        public ActionResult servicedetailstable(int id)
        {

            order order = db.orders.Find(id);
            //string service = Session["service"].ToString();
            //ViewBag.id = id;
            string service = order.service;
            //status status = order.status;

            //if (status != status.cancelled)
            //    if (status != status.archived)
            //    {

                    switch (service)
                    {
                        case "Zilla Guest Post":
                            return PartialView("_blogdetailstable", order);
                        //return PartialView("_blogdetailstable");
                        case "Zilla Local SEO":
                            return PartialView("_citationdetailstable", order);
                        //return PartialView("_citationdetailstable");
                        case "Zilla Blog":
                            return PartialView("_zillablogdetailstable", order);

                        case "Zilla On Page":
                            return PartialView("_zillaonpagedetailstable", order);

                        case "Zilla X":
                            return PartialView("_zillaxdetailstable", order);

                        case "Zilla Link Building":
                             return PartialView("_zillalinkbuildingdetailstable", order);
                        default:
                            return Content("Incorrect ID");

                    }
                //}
               //if(status == status.cancelled || status==status.archived)
               // {

               //     switch (service)
               //     {
               //         case "Zilla Guest Post":
               //             return PartialView("_blogdetailstable", order);
               //         //return PartialView("_blogdetailstable");
               //         case Zilla Local SEO:
               //             return PartialView("_citationdetailstable", order);
               //         //return PartialView("_citationdetailstable");
               //         default:
               //             return Content("Incorrect ID");

               //     }

               // }
         
        }
         
          public ActionResult Add_new()
        {
            return View();
        }

        
        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult Invoice()
        {

            daordered daordered = db.blogs.FirstOrDefault().daordered;

            if (User.IsInRole("User"))
            {
                var orders = db.orders.Include(o => o.user).Where(o => o.status == status.cancelled || o.status == status.awaiting_payment || o.status == status.payment_done).Where(o => o.user.email == User.Identity.Name);

                return View(orders.ToList());
            }
            else
            {
                var orders = db.orders.Include(o => o.user).Where(o => o.status == status.cancelled || o.status == status.awaiting_payment || o.status == status.archived || o.status == status.payment_done);

                return View(orders.ToList());
            }
        }
        public ActionResult Invoices(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (User.IsInRole("User"))
            {
                var order = db.orders.Where(o => o.ID == id && o.user.email == User.Identity.Name).FirstOrDefault();
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
            else
            {
                var order = db.orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
          
        }
        [ChildActionOnly]
        public ActionResult invoicedetailstable(int id)
        {

            order order = db.orders.Find(id);
           
            string service = order.service;

            ViewBag.service = service;
           
            ViewBag.countblog = order.blogs.Count();

            ViewBag.countcitation = order.citations.Count();

            ViewBag.countzillablog = order.zillablogs.Count();

            ViewBag.countzillax = order.zillax.Count();

            ViewBag.countzillaonpage = order.zillaonpages.Count();

            ViewBag.countzillalinkbuilding = order.zillalinkbuildings.Count();

           

            switch (service)
            {
                case "Zilla Guest Post":
                  
                    return PartialView("_bloginvoice", order);
               
                case "Zilla Local SEO":
                    return PartialView("_citationinvoice", order);

                case "Zilla Blog":
                    return PartialView("_zillabloginvoice", order);

                case "Zilla On Page":
                    return PartialView("_zillaonpageinvoice", order);

                case "Zilla X":

                   return PartialView("_zillaxinvoice", order);

                case "Zilla Link Building":
                 return PartialView("_zillalinkbuildinginvoice", order);

                 default:
                    return Content("Incorrect ID");

            }
         
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
