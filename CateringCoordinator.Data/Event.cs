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
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int FoodId { get; set; }
        [Required]
        public bool PrepArea { get; set; }
        [Required]
        public int NumOfGuest { get; set; }
        [Required]
        public int NumOfHelpers { get; set; }
        [Required]
        public string SuppliesNeeded { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public bool IsFullService { get; set; }
        [Required]
        public DateTime DateOfEvent { get; set; }
        [Required]
        public decimal CostOfEvent { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
