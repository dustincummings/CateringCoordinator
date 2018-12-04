﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
 
       public ICollection<Event> Events { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + "," + FirstName;
            }
        }

        public override string ToString() => FullName;
       
    }
}
