using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seozillabackend.DAL;

namespace seozillabackend.Extensions
{
    public class Query
    {
        
        public static int findlast()
        {
            usercontext db = new usercontext();
            return Convert.ToInt32(db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('order')").First());
        }
    }
}