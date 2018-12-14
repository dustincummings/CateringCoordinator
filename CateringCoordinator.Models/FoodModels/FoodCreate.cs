using CateringCoordinator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Models.FoodModels
{
     public class FoodCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Description { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public bool Allergens { get; set; }
        [Required]
        public int Servings { get; set; }


        public virtual Event Events { get; set; }
    }
}
