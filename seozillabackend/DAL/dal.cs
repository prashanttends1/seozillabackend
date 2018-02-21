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
        public user getuser(user user)
        {
            return db.users.Where(u => u.email.ToLower() == user.email.ToLower() &&
            u.password == user.password).FirstOrDefault();
        }

    }
}