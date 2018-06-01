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
        public string token { get; set; }
        public bool reset { get; set; }
        public DateTime? timeforreset { get; set; }


        public virtual ICollection<order> orders { get; set; }

        //public virtual ICollection<blog> blogs { get; set; }

        //public virtual ICollection<citation> citations { get; set; }
            
    }
}
