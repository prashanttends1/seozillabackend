using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class citation : order
    {
        //public int ID { get; set; }
        public string country { get; set; }
        public string businessname { get; set; }
        public string websiteurl { get; set; }
        public string businessdescription { get; set; }
        public string keywords { get; set; }
        public string founder { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        //public int userID { get; set; }
        //public virtual user user { get; set; }
        //public int orderID { get; set; }
        //public virtual order order { get; set; }
    }
}