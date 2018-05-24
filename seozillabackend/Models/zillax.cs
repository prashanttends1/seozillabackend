using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class zillax
    {
       
        public int ID { get; set; }
        public string plan { get; set; }
        public string keyword1 { get; set; }
        public string keyword2 { get; set; }
        public string keyword3 { get; set; }
        public string competitor1{get; set;}
        public string competitor2{get; set;}
        public string competitor3{get; set;}
        public string targetlocation{get; set;}
        public string otherinfo{get; set;}
        public int orderID { get; set; }
        public virtual order order { get; set; }
    }
}