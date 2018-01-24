using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seozillabackend.Models
{
   
    public enum status
    {
        awaiting_payment, payment_done, task_in_progress, task_completed
    }

    public class order
    {
        public int ID { get; set; }
        public string orderno { get; set; }
        public string service { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime? duedate { get; set; }
        public status status { get; set; }
        public string comment { get; set; }
        public string tags { get; set; }
        public int userID { get; set; }
        public virtual user user { get; set; }        
        public virtual ICollection<blog> blogs { get; set; }        
        public virtual ICollection<citation> citations { get; set; }

    }
}