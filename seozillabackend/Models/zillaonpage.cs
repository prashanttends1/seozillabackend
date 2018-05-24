using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class zillaonpage
    {
        public int ID { get; set; }
        public string plan { get; set; }
        public string pageurl { get; set; }
        public string primekeyword { get; set; }
        public string secondarykeyword { get; set; }
        public string targetlocation { get; set; }
        public int orderID { get; set; }
        public virtual order order { get; set; }

    }
}