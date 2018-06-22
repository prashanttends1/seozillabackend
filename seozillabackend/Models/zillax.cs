using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class zillax
    {
       
        public int ID { get; set; }
        [Display(Name = "Plan")]
        public string plan { get; set; }
        [Display(Name = "Keyword 1")]
        public string keyword1 { get; set; }
          [Display(Name = "Keyword 2")]
        public string keyword2 { get; set; }
          [Display(Name = "Keyword 3")]
        public string keyword3 { get; set; }
          [Display(Name = "Competitor 1")]
        public string competitor1{get; set;}
         [Display(Name = "Competitor 2")]
        public string competitor2{get; set;}
         [Display(Name = "Competitor 3")]
        public string competitor3{get; set;}
         [Display(Name = "Target Location")]
        public string targetlocation{get; set;}
         [Display(Name = "Other Information")]
        public string otherinfo{get; set;}
        public int orderID { get; set; }
        public virtual order order { get; set; }
    }
}