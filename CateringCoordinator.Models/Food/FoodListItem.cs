﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Models
{
    public class FoodListItem
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingrediants { get; set; }
        public decimal Cost { get; set; }
        public bool Allergens { get; set; }
        public int Servings { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }


}