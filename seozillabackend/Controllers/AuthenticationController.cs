using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using seozillabackend.Models;
using System.Web.Security;
using seozillabackend.DAL;

namespace seozillabackend.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "orders");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            dal dl = new dal();
            user user = dl.getuser(email, password);
            if (user != null && !User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SetAuthCookie(user.email, true);
                var authTicket = new FormsAuthenticationTicket(1, user.email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "orders");
            }
            else if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "orders");
            }
            else
            {
                ModelState.AddModelError("incorrectcredentials", "Invalid login attempt.");
                return View();
            }
            
        }
        
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult AccessDenied()
        {
            //return View();
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }
    }
}