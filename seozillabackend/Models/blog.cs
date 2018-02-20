using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seozillabackend.Models
{
    public enum daordered
    {
       
         [Description("DA 10+")]
        ten_plus,
         [Description("DA 20+")]
         twenty_plus,
         [Description("DA 30+")]
         thirty_plus,
        [Description("DA 40+")]
         forty_plus,
        [Description("DA 10+ special ")]
        ten_plus_special
     }

    public enum wordcount
    {
        [Description("500 Words")]
        fivehundredplus,
          [Description("750 Words")]
        sevenfiftyplus,
          [Description("1000 Words")]
        thousandplus,
          [Description("1250 Words")]
        twelevefiftyplus,
          [Description("1500 Words")]
        fifteenhundrednplus
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
         [Display(Name = "DA")]
        public string da { get; set; }

        //public int userID { get; set; }
        //public virtual user user { get; set; }
         [Display(Name = "Order Id")]
        public int orderID { get; set; }
        [Display(Name = "Order")]
        public virtual order order { get; set; }

    }
}
