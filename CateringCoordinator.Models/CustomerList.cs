using CateringCoordinator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Models
{
    public class CustomerList
    {
        [Display(Name ="ID")]
        public int CustomerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName  = LastName + "," + FirstName; }
        }

        
            

        public int EventId { get; set; }


    }
}
