using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seozillabackend.Models
{
    public class citation // : order
    {
        public int ID { get; set; }
        [Display(Name="Country")]
        public string country { get; set; }
         [Display(Name = "Business Name")]
        public string businessname { get; set; }
         [Display(Name = "Website Url")]
        public string websiteurl { get; set; }
         [Display(Name = "Business Description")]
        public string businessdescription { get; set; }
         [Display(Name = "Keywords")]
        public string keywords { get; set; }
         [Display(Name = "Founder/CEO")]
        public string founder { get; set; }
         [Display(Name = "Address")]
        public string address { get; set; }
         [Display(Name = "Phone")]
        public string phone { get; set; }
         [Display(Name = "Email")]
        public string email { get; set; }
        //public int userID { get; set; }
        //public virtual user user { get; set; }
         [Display(Name = "Order Id")]
        public int orderID { get; set; }
         [Display(Name = "Order")]
        public virtual order order { get; set; }
    }
}