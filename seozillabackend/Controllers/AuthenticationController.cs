using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using seozillabackend.Models;
using System.Web.Security;
using seozillabackend.DAL;
using seozillabackend.Extensions;

namespace seozillabackend.Controllers
{
    public class AuthenticationController : Controller
    {
        private usercontext db = new usercontext();
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
        public ActionResult Index(string email, string password, bool rememberme=false)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            dal dl = new dal();
            user user = dl.getuser(email, password);
            if (user != null && !User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SetAuthCookie(user.email, rememberme);
                //var authTicket = new FormsAuthenticationTicket(1, user.email, DateTime.Now, DateTime.Now.AddMinutes(20), true, user.Roles);
                //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                //var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                //HttpContext.Response.Cookies.Add(authCookie); 
                //if (rememberme)
                //{
                //    //int timeout = rememberme ? 525600 : 5; // Timeout in minutes, 525600 = 365 days.
                //    int timeout = 525600;
                //    var ticket = new FormsAuthenticationTicket(email, rememberme, timeout);
                //    string encrypted = FormsAuthentication.Encrypt(ticket);
                //    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                //    cookie.Expires = System.DateTime.Now.AddMinutes(timeout);// Not my line
                //    cookie.HttpOnly = true; // cookie not available in javascript.
                //    Response.Cookies.Add(cookie);
                //}
                //else
                //{
                //    Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
                //}
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
        public ActionResult Forget_Password()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forget_Password(string email)
        {
            
            if (email!=null)
                if(ModelState.IsValid)
                {
                    user user = db.users.Where(u => u.email==email).FirstOrDefault();
                    if(user!=null)//if user exist
                    {
                        string To =  email, UserID, Password, SMTPPort, Host; 
                        string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                        token=token.Replace("=","");
                        token = token.Replace("[", "");
                        token = token.Replace("+", "");
                        token = token.Replace("]", "");
                        token = token.Replace("/", "");
                        user.token = token;
                        user.timeforreset = DateTime.Now.AddHours(24);
                        db.users.Attach(user);
                        db.Entry(user).Property("token").IsModified=true;
                        db.Entry(user).Property("timeforreset").IsModified=true;
                        db.SaveChanges();

                        var lnkHref = "<a href='" + Url.Action("resetpassword", "Authentication", new { email = email, token = token }, "http") + "'>Click this link to set a new password.</a>";

                        //HTML Template for Send email  

                        string subject = "Your changed password";

                        string body = "<b>We have received a request to change your password.</b><br/>" + "</br>" + lnkHref + "<br/>" + "<p>If you did not make this request then you can simply ignore this email.</p><br/><p>Thanks,<br/><br/><b>Seozilla Support</b></p>" + "<hr>" + "<img src='http://www.seozilla.co.uk/wp-content/uploads/2017/11/cropped-logo-home.png'/>" + "<br/>" + "<b>Telephone:</b> 020 3808 7777 <p><b>Website: </b>http://seozilla.co.uk/</p>" + "<br/>" + "<p style='font-size: 10px;'><b>Registered Address:</b>86-90 Paul Street,London,EC2A 4NE</p></br><p style='font-size: 10px;'><b>Disclaimer:</b> This message (and any attachments) is private and confidential and may contain personal data or personal views which are not the views of Fat Joe unless specifically stated. If you have received this message in error, please notify us and remove it from your system. Do not use, copy or disclose the information in any way.</p>";


                        //Get and set the AppSettings using configuration manager.  

                        emailmanager.Appsettings(out UserID, out Password, out SMTPPort, out Host);

                        //Call send email methods.  

                        emailmanager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);  
                    }
                }
            return RedirectToAction("forget_password_message" , "Authentication");
        }

        public ActionResult resetpassword(string token, string email)
        {
            user model = new user();
            model.email = email;
            model.token = token;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult resetpassword(string password, string email, string token)
        {
            user model = new user();
            model.email = email;
            model.token = token;
            model.password = password;
            if(password!=null)
            if(ModelState.IsValid)
            {
                user user = db.users.Where(u => u.email == email && u.token == token && u.timeforreset>DateTime.Now).FirstOrDefault();
                if(user!=null)
                {
                    user.password = password;
                    user.token = null;
                    user.timeforreset = null;                    
                    db.users.Attach(user);
                    db.Entry(user).Property("password").IsModified = true;
                    db.Entry(user).Property("token").IsModified = true;
                    db.Entry(user).Property("timeforreset").IsModified = true;
                    db.SaveChanges();               
                    return RedirectToAction("Index");

                }
                else if (user.token!= token || user.timeforreset<DateTime.Now)
                {
                    ModelState.AddModelError("message", "Please Enter Email Again");
                    return RedirectToAction("resetpassword", "Authentication");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }        
            return View(model);
        }

        public ActionResult forget_password_message()
        {
            return View();
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
