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
        public int FoodId { get; set; }
        [Required]
        public int NumOfGuest { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Event")]
        public DateTime? DateOfEvent { get; set; }
       

        public virtual Food Food { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
