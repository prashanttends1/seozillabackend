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
                if (service == "citation")
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


                if (service == "blog")
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
                        case "blog":
                            return PartialView("_blogdetailstable", order);
                        //return PartialView("_blogdetailstable");
                        case "citation":
                            return PartialView("_citationdetailstable", order);
                        //return PartialView("_citationdetailstable");
                        case "zillablog":
                            return PartialView("_zillablogdetailstable", order);

                        case "zillaonpage":
                            return PartialView("_zillaonpagedetailstable", order);

                        default:
                            return Content("Incorrect ID");

                    }
                //}
               //if(status == status.cancelled || status==status.archived)
               // {

               //     switch (service)
               //     {
               //         case "blog":
               //             return PartialView("_blogdetailstable", order);
               //         //return PartialView("_blogdetailstable");
               //         case "citation":
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

           

            switch (service)
            {
                case "blog":
                  
                    return PartialView("_bloginvoice", order);
               
                case "citation":
                    return PartialView("_citationinvoice", order);
               
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
