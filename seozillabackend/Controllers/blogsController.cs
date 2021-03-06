﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seozillabackend.DAL;
using seozillabackend.Models;
using seozillabackend.Extensions;

namespace seozillabackend.Controllers
{
    [Authorize]
    public class blogsController : Controller
    {
        private usercontext db = new usercontext();

        // GET: blogs
        public ActionResult Index()
        {
            var blogs = db.blogs.Include(b => b.order);
            return View(blogs.ToList());
        }

        // GET: blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        
        // GET: blogs/Create
        public ActionResult Create()
        {
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno");
            return View();
        }

        // POST: blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Create([Bind(Include = "ID,daordered,wordcount,anchortext,targeturl,posttitle,postplacement,da,orderID")] blog blog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.blogs.Add(blog);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", blog.orderID);
        //    return View(blog);
        //}
        [NonAction]
        public int findlast()
        {

            return Convert.ToInt32( db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('order')").First());
        }

        
        [ChildActionOnly]
        public ActionResult updatedetails(int id)
        {

            blog blog = db.blogs.Find(id);
            if (User.IsInRole("Admin"))
                return PartialView("_adminupdatedetails", blog);
            else
                return PartialView("_userupdatedetails", blog);
         
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<blog> blogs_f,string url, string amount)
        {
            if (blogs_f != null)
            {
                //create an order for blog 
                order order = new order();
                int last = findlast() + 111;
                order.orderno = "SZ" + last;
                order.orderdate = DateTime.Now;
                order.service = "Zilla Guest Post";
                order.status = status.awaiting_payment;
                order.userID = db.users.Where(u => u.email == User.Identity.Name).FirstOrDefault().ID;
                db.orders.Add(order);
                db.SaveChanges();                
                if (ModelState.IsValid)
                {

                    foreach (blog blog in blogs_f)
                    {

                        blog.orderID = findlast(); //assign last(i.e. above) order ID to blog OrderID
                        Session["orderID"] = findlast();
                        Session["amount"] = amount;
                        db.blogs.Add(blog);
                    }
                    db.SaveChanges();
                    //return RedirectToAction("Index", "orders");
                    //return Redirect("https://amit-test.chargebee.com/hosted_pages/plans/test_plan");
                    return Redirect(url);
                }
            }
           
            //foreach (blog blog in blogs_f)
            //{
            //    ViewData["[0].orderID"] = new SelectList(db.orders, "ID", "orderno", blog.orderID);
            //    ViewData["[1].orderID"] = new SelectList(db.orders, "ID", "orderno", blog.orderID);
               
            //    //ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", blog.orderID);
            //    //ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", blog.orderID);

                
            //}
            return View(blogs_f);
        }
        
        // GET: blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            blog blog = db.blogs.Find(id);
            if (User.IsInRole("Admin"))
            {
                if (blog == null)
                {
                    return HttpNotFound();
                }
                ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", blog.orderID);
                return View(blog);
            }
            else
            {

                if (blog.order.user.email == User.Identity.Name)
                {
                    if (blog == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", blog.orderID);
                    return View(blog);
                }
                else
                {
                    return RedirectToAction("AccessDenied", "Authentication");
                    //return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }
            }
        }

        // POST: blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,daordered,wordcount,anchortext,targeturl,posttitle,postplacement,da,orderID")] blog blog)
        {
            int orderid = blog.orderID;

            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "orders", new {@id=orderid});
            }
            ViewBag.orderID = new SelectList(db.orders, "ID", "orderno", blog.orderID);
            return View(blog);
        }

        // GET: blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            blog blog = db.blogs.Find(id);
            db.blogs.Remove(blog);
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
