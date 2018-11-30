using CateringCoodinator.Data;
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

        public FoodDetail GetFoodById(int foodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(e => e.FoodId == foodId && e.OwnerId == _userId);
                return
                    new FoodDetail
                    {
                        FoodId = entity.FoodId,
                        Name = entity.Name,
                        Description = entity.Description,
                        Ingrediants = entity.Ingrediants,
                        Cost = entity.Cost,
                        Allergens = entity.Allergens,
                        Servings = entity.Servings,

                        
                    };
            }
        }

        public bool UpdateFoods(FoodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Foods
                    .Single(e => e.FoodId == model.FoodId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Ingrediants = model.Ingrediants;
                entity.Cost = model.Cost;
                entity.Allergens = model.Allergens;
                entity.Servings = entity.Servings;

                return ctx.SaveChanges() == 1;

            }
        }
    }
    
    
}
