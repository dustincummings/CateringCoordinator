﻿using CateringCoodinator.Data;
using CateringCoordinator.Data;
using CateringCoordinator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Services
{

    public class FoodService
    {
        private readonly Guid _userId;

        public FoodService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFood(FoodCreate model)
        {
            var entity =
                new Food()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description,
                    Ingrediants = model.Ingrediants,
                    Cost = model.Cost,
                    Allergens = model.Allergens,
                    Servings = model.Servings,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Foods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FoodListItem> GetFoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Foods
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new FoodListItem
                        {
                            FoodId = e.FoodId,
                            Name = e.Name,
                            Description = e.Description,
                            Ingrediants = e.Ingrediants,
                            Cost = e.Cost,
                            Allergens = e.Allergens,
                            Servings = e.Servings,
                        }
                      );
                return query.ToArray();
            }
        }
    }
    
    
}