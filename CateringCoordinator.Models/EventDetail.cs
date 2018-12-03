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
        [Display(Name = "Preparing on Site")]
        public bool PrepArea { get; set; }
        [Display(Name = "# of Guests")]
        public int NumOfGuest { get; set; }
        [Display(Name = "# of People Needed")]
        public int NumOfHelpers { get; set; }
        [Display(Name = "Needed Supplies")]
        public string SuppliesNeeded { get; set; }
        public string Location { get; set; }
        [Display(Name = "Full Service")]
        public bool IsFullService { get; set; }
        [Display(Name = "Date of Event")]
        public DateTime DateOfEvent { get; set; }
        [Display(Name = "Event Cost")]
        public decimal CostOfEvent { get; set; }

    }
}
