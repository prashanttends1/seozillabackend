using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seozillabackend.Models;

namespace seozillabackend.DAL
{
    public class dal
    {

        usercontext db = new usercontext();
        public user getuser(string email, string pass)
        {
            return db.users.Where(u => u.email.ToLower() == email.ToLower() &&
            u.password == pass).FirstOrDefault();
        }

    }
}