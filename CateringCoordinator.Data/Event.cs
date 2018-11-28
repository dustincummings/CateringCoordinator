using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public int CustomerId { get; set; }
        public int FoodId { get; set; }
        public bool PrepArea { get; set; }
        public int NumOfGuest { get; set; }
        public int NumOfHelpers { get; set; }
        public string SuppliesNeeded { get; set; }
        public string Location { get; set; }
        public bool IsFullService { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostOfEvent { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
