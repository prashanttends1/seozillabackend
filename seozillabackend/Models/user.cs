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
        public string lastname { get; set; }         
        public int ID { get; set; }        
        public string email { get; set; }
        public string country { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public virtual ICollection<order> orders { get; set; }

        //public virtual ICollection<blog> blogs { get; set; }

        //public virtual ICollection<citation> citations { get; set; }
            
    }
}