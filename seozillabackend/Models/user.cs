using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seozillabackend.Models
{
    
    public class user
    {
        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [Required]
         [Display(Name = "Last Name")]
        public string lastname { get; set; }  
        [Required]
        public int ID { get; set; }
        [Display(Name="Email")]
        [Required]
        public string email { get; set; }
         [Display(Name = "Country")]
        [Required]
        public string country { get; set; }
         [Display(Name = "Password")]
        [Required]
        public string password { get; set; }
        [Required]
        public string Roles { get; set; }
        [Display(Name="Telephone Number")]
        public string telephone { get; set; }
        [Display(Name="Company Name")]
        public string company { get; set; }

        [Display(Name="Building Name/Number")]
        public string building { get; set; }
        [Display(Name="Address Line 1")]
        public string addressline1 { get; set; }
        [Display(Name="Address Line 2")]
        public string addressline2 { get; set; }
        [Display(Name="City")]
        public string city { get; set; }
        [Display(Name="Postcode/Zipcode")]
        public string postcode { get; set; }        
        public string token { get; set; }        
        public DateTime? timeforreset { get; set; }


        public virtual ICollection<order> orders { get; set; }

        //public virtual ICollection<blog> blogs { get; set; }

        //public virtual ICollection<citation> citations { get; set; }
            
    }
}
