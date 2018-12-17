using CateringCoordinator.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Contracts
{
    public interface IFood
    {
        bool CreateFood(FoodCreate model);
        IEnumerable<FoodListItem> GetFoods();
        FoodDetail GetFoodById(int foodId);
        bool UpdateFoods(FoodEdit model);
        bool DeleteFood(int foodId);
    }
}
