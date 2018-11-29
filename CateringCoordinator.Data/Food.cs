using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Data
{
     public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Ingrediants { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public bool Allergens { get; set; }
        [Required]
        public int Servings { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
