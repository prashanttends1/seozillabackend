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
      
        [Display(Name = "First Name")]
        public string firstname { get; set; }
         [Display(Name = "Last Name")]
        public string lastname { get; set; }         
        public int ID { get; set; }
        [Display(Name="Email")]
        public string email { get; set; }
         [Display(Name = "Country")]
        public string country { get; set; }
         [Display(Name = "Password")]
        public string password { get; set; }
        public string Roles { get; set; }
        public virtual ICollection<order> orders { get; set; }

        //public virtual ICollection<blog> blogs { get; set; }

        //public virtual ICollection<citation> citations { get; set; }
            
    }
}