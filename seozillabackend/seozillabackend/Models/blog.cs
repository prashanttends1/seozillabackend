using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    public class blog : order
    {
        //public int ID { get; set; }
        public daordered daordered { get; set; }

        public wordcount wordcount { get; set; }
        public string anchortext { get; set; }

        public string targeturl { get; set; }

        public string posttitle { get; set; }
        public string postplacement { get; set; }
        public string da { get; set; }

        //public int userID { get; set; }
        //public virtual user user { get; set; }

        //public int orderID { get; set; }

        //public virtual order order { get; set; }

    }
}