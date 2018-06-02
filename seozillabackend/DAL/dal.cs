using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using seozillabackend.Models;

namespace seozillabackend.DAL
{
    public class dal
    {

        usercontext db = new usercontext();
        public user getuser(string email, string pass)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return db.users.Where(u => u.email.ToLower() == email.ToLower() && u.password == pass).FirstOrDefault();
            else
                return db.users.Where(u => u.email.ToLower() == HttpContext.Current.User.Identity.Name).FirstOrDefault();
        }
        public string userexist(string email)
        {
            user user= new user();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                user = db.users.Where(u => u.email.ToLower() == email.ToLower()).FirstOrDefault();
                return user.email;
            }

            else
            {
                user = db.users.Where(u => u.email.ToLower() == HttpContext.Current.User.Identity.Name).FirstOrDefault();
                return user.email;
            }
        }

    }
}