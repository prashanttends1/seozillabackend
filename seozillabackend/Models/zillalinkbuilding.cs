using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class zillalinkbuilding
    {
        public int ID { get; set; }
        [Display(Name = "Plan")]
        public string plan { get; set; }
        [Display(Name = "Url 1")]
        public string url1 { get; set; }
         [Display(Name = "Url 2")]
        public string url2 { get; set; }
         [Display(Name = "Url 3")]
        public string url3 { get; set; }
         [Display(Name = "Keyword 1")]
        public string keyword1a { get; set; }//first keyword associated with url1
        [Display(Name = "Keyword 2")]
        public string keyword1b { get; set;}//second keyword associated with url1
        [Display(Name = "Keyword 3")]
        public string keyword2a { get; set; }
        [Display(Name = "Keyword 4")]
        public string keyword2b { get; set; }
        [Display(Name = "Keyword 5")]
        public string keyword3a { get; set; }
        [Display(Name = "Keyword 6")]
        public string keyword3b { get; set; }
        [Display(Name = "Cloud Url")]
        public string cloudurl { get; set; }
        public int orderID { get; set; }
        public virtual order order { get; set; }
    }
}