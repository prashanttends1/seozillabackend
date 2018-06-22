using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
    public class zillablog
    {
        public int ID { get; set; }
        [Display(Name = "Words")]
        public string words { get; set; }
        [Display (Name="Quantity")]
        public int quantity { get; set; }
        [Display (Name="Title")]
        public string title { get; set; }
        [Display (Name="Website")]
        public string website { get; set; } //target website or audience
        [Display (Name="Brief")]
        public string brief { get; set; } //project brief
        [Display(Name="Document Url")]
        public string document_url { get; set; }
        public int orderID { get; set; }
        public virtual order order { get; set; }

    }
}