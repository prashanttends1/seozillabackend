using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seozillabackend.Models
{
   
    public enum status
    {
        awaiting_payment, payment_done, task_in_progress, task_completed
    }

    public class order
    {
        public int ID { get; set; }
        [Display(Name = "Order No")]
        public string orderno { get; set; }
        [Display(Name = "Services")]
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

    }
}