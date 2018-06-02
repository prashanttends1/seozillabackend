using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using seozillabackend.Models;

namespace seozillabackend.DAL
{
    public class userinitializer: DropCreateDatabaseIfModelChanges<usercontext>
    {
        protected override void Seed(usercontext context)
        {
            var userss = new List<user>
            {
                new user{firstname="Hitesh", lastname="Patel", email="hitesh@inteventure.com", country="United Kingdom", password="123", Roles="Admin",  token=null, timeforreset=null},
                new user{firstname="Ajit2", lastname="Prakash", email="ajit2@gmail.com", country="India", password="123", Roles="User",  token=null, timeforreset=null},
                new user {firstname="Nikhil", lastname="Verma", email="nikhil@gmail.com", country="India", password="123", Roles="User",  token=null, timeforreset=null}
            };
            userss.ForEach(u => context.users.Add(u));
            context.SaveChanges();

            var orderss = new List<order> 
            { 
                new order{orderno="SZ111",service="blog", orderdate=DateTime.Parse("2017-11-01"), status=status.awaiting_payment, userID=1},
                new order{orderno="SZ112",service="citation", orderdate=DateTime.Parse("2017-11-02"), status=status.awaiting_payment, userID=2}
            };
            orderss.ForEach(o => context.orders.Add(o));
            context.SaveChanges();

            var blogss = new List<blog> 
            {
                new blog{ daordered=daordered.ten_plus, wordcount=wordcount.fivehundredplus, anchortext="clickhere", targeturl="abc.com", orderID=1 },
                 new blog{ daordered=daordered.ten_plus, wordcount=wordcount.fivehundredplus, anchortext="clickhere", targeturl="xyz.com", orderID=1 }

            };
            blogss.ForEach(b => context.blogs.Add(b));
            context.SaveChanges();

            var citationss = new List<citation> 
            {
                new citation{ country="India", businessname="WrongX", websiteurl="wrongx.com", businessdescription="A fashion clothing brand", keywords="lastest shirts, trendy t-shirts", founder="V Malhotra", address="Delhi, India", phone="+91-9897508181", email="info@wrongx.com", orderID=2  }
            };

            citationss.ForEach(c => context.citations.Add(c));
            context.SaveChanges();

        }
    }
}