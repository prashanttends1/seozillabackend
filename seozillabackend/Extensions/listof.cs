using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace seozillabackend.Extensions
{
    public class listof
    {
        public static List<SelectListItem> countries = new List<SelectListItem>() { 
                new SelectListItem(){ Text="Afghanistan", Value="Afghanistan"},
                new SelectListItem(){ Text="India", Value="India"},
                new SelectListItem(){ Text="United Kingdom", Value="United Kingdom"},};
        public static List<SelectListItem> status = new List<SelectListItem>()
        {
            new SelectListItem(){ Text="Awaiting Payment", Value="awaiting_payment"},
                new SelectListItem(){ Text="Payment Done", Value="Payment Done"},
                new SelectListItem(){ Text="Task In Progress", Value="task_in_progress"},
                new SelectListItem(){ Text="Task Completed", Value="task_completed"},
                new SelectListItem(){ Text="Cancelled", Value="cancelled"},
                new SelectListItem(){ Text="Archived", Value="archived"}
        };
        

    }
     
}