using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace seozillabackend.Extensions
{
    public class listof
    {
        public static List<SelectListItem> countries = new List<SelectListItem>() {                 new SelectListItem(){ Text="Afghanistan", Value="Afghanistan"},                new SelectListItem(){ Text="India", Value="India"},};

    }
}