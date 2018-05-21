using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class zillablog
    {
        public int ID { get; set; }
        public string words { get; set; }
        public int quantity { get; set; }
        public string title { get; set; }
        public string website { get; set; } //target website or audience
        public string brief { get; set; } //project brief

        public int orderID { get; set; }

        public virtual order order { get; set; }

    }
}