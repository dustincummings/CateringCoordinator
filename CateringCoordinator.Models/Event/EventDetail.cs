using CateringCoordinator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Models
{
    public class EventDetail
    {
        public int EventId { get; set; }
        public int CustomerId { get; set; }
        public int FoodId { get; set; }
        [Display(Name = "# of Guests")]
        public int NumOfGuest { get; set; }
        public string Location { get; set; }
        [Display(Name = "Date of Event")]
        public DateTime DateOfEvent { get; set; }

        
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Food> Foods { get; set; }

    }
}
