using CateringCoordinator.Models.FoodModels;
using CateringCoordinator.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Catering_Coodinator.WebApi.Controllers
{
    [Authorize]
    public class FoodController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            FoodService foodService = CreateFoodService();
            var foods = foodService.GetFoods();
            return Ok(foods);
        }

        public IHttpActionResult Get(int id)
        {
            FoodService foodService = CreateFoodService();
            var food = foodService.GetFoodById(id);
            return Ok(food);

        }

        public IHttpActionResult Post(FoodCreate food)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFoodService();
            if (!service.CreateFood(food))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(FoodEdit food)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFoodService();
            if (!service.UpdateFoods(food))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateFoodService();
            if (!service.DeleteFood(id))
                return InternalServerError();
            return Ok();
        }

        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var foodService = new FoodService(userId);
            return foodService;
        }
    }
}
