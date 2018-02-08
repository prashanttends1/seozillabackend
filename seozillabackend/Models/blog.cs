using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seozillabackend.Models
{
    public enum daordered
    {
        ten_plus, twenty_plus, thirty_plus, forty_plus
    }

    public enum wordcount
    {
        fivehundredplus, sevenfiftyplus, thousandplus, twelevefiftyplus, fifteenhundrednplus
    }
    public class blog //: order
    {
        public int ID { get; set; }
        [Display(Name = "DA Ordered")]
        public daordered daordered { get; set; }
         [Display(Name = "Word Count")]
        public wordcount wordcount { get; set; }
         [Display(Name = "Anchor Text")]
        public string anchortext { get; set; }
        [Display(Name = "Target URL")]
        public string targeturl { get; set; }
         [Display(Name = "Post Title")]
        public string posttitle { get; set; }
         [Display(Name = "Post Placement")]
        public string postplacement { get; set; }
         [Display(Name = "Da")]
        public string da { get; set; }

        //public int userID { get; set; }
        //public virtual user user { get; set; }
         [Display(Name = "Order Id")]
        public int orderID { get; set; }
        [Display(Name = "Order")]
        public virtual order order { get; set; }

    }
}
