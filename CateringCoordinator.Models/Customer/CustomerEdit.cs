using CateringCoordinator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Models
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public int EventId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual Event Event { get; set; }
    }
}
