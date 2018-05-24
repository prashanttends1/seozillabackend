using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class zillalinkbuilding
    {
        public int ID { get; set; }
        public string url1 { get; set; }
        public string url2 { get; set; }
        public string url3 { get; set; }
        public string keyword1a { get; set; }//first keyword associated with url1
        public string keyword1b { get; set;}//second keyword associated with url1
        public string keyword2a { get; set; }
        public string keyword2b { get; set; }
        public string keyword3a { get; set; }
        public string keyword3b { get; set; }
        public string cloudurl { get; set; }
    }
}