﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seozillabackend.Models
{
   
    public enum status
    {
        [Description("Awaiting Payment")]
        awaiting_payment,
        [Description("Payment Done")]
        payment_done,
        [Description("Task In Progress")]
        task_in_progress,
        [Description("Task Completed")]
        task_completed,
        [Description("Cancelled")]
        cancelled,
        [Description("Cancelled*")]
        cancelled_after_payment,
        [Description("Refund Initiated")]
        refund_initiated,
        [Description("Archived")]
        archived
    }

    public class order
    {
        public int ID { get; set; }
        [Display(Name = "Order No")]
        public string orderno { get; set; }
        [Display(Name = "Product")]
        public string service { get; set; }
          [Display(Name = "Order Date")]
          [DataType(DataType.Date)]
        public DateTime orderdate { get; set; }
          [Display(Name = "Due Date")]
          [DataType(DataType.Date)]
        public DateTime? duedate { get; set; }
          [Display(Name = "Status")]
        public status status { get; set; }
          [Display(Name = "Comment")]
        public string comment { get; set; }
        public string tags { get; set; }
        public int userID { get; set; }
        public virtual user user { get; set; }        
        public virtual ICollection<blog> blogs { get; set; }        
        public virtual ICollection<citation> citations { get; set; }

        public virtual ICollection<zillablog> zillablogs { get; set; }

        public virtual ICollection<zillalinkbuilding> zillalinkbuildings { get; set; }
        public virtual ICollection<zillaonpage> zillaonpages { get; set; }
        public virtual ICollection<zillax> zillax{get; set;}
        
    }
}