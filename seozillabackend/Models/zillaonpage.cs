using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class zillaonpage
    {
        public int ID { get; set; }
        [Display(Name = "Plan")]
        public string plan { get; set; }
        [Display(Name = "Page Url")]
        public string pageurl { get; set; }
        [Display(Name = "Prime Keyword")]
        public string primekeyword { get; set; }
        [Display(Name = "Secondary Keyword")]
        public string secondarykeyword { get; set; }
        [Display(Name = "Target Location")]
        public string targetlocation { get; set; }
        public int orderID { get; set; }
        public virtual order order { get; set; }

    }
}