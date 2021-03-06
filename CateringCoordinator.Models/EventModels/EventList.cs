﻿using CateringCoordinator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Models.EventModels
{
    public class EventList
    {
        public int EventId { get; set; }
        public int CustomerId { get; set; }
        public int FoodId { get; set; }
        
        public string CustomerName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Food")]
        public string FoodName { get; set; }
        [Display(Name ="# of Guests")]
        public int NumOfGuest { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Date of Event")]
        public DateTime? DateOfEvent { get; set; }

        public virtual Food Food { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
