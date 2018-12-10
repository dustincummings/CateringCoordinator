using CateringCoordinator.Data;
using CateringCoordinator.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Models.EventModels
{
    public class EventCreate
    {
        public int CustomerId { get; set; }
        public int FoodId { get; set; }
        [Display(Name = "# of Guests")]
        public int NumOfGuest { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Event")]
        public DateTime? DateOfEvent { get; set; }


        //public virtual Customer Customer { get; set; }
        public virtual ICollection<FoodListItem> Food { get; set; }


    }
}
