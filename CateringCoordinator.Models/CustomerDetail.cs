using CateringCoordinator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Models
{
    public class CustomerDetail
    {
      

        public int CustomerId { get; set; }
        [Display(Name ="Event")]
        public int EventId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual Event Event { get; set; }

    }
}
