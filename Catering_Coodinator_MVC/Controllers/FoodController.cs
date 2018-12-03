using CateringCoordinator.Models;
using CateringCoordinator.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catering_Coodinator_MVC.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var servivce = new FoodService(userId);
            var model = servivce.GetFoods();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var service = CreateFoodService();

            if (service.CreateFood(model))
            {
                TempData["SaveResult"] = "Your Food was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Food could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = CreateFoodService();
            var detail = service.GetFoodById(id);
            var model =
                new FoodEdit
                {
                    FoodId = detail.FoodId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Ingrediants = detail.Ingrediants,
                    Cost = detail.Cost,
                    Allergens = detail.Allergens,
                    Servings = detail.Servings,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FoodId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateFoodService();

            if (service.UpdateFoods(model))
            {
                TempData["SaveResult"] = " Your food was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your food could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodService();

            service.DeleteFood(id);

            TempData["SaveResult"] = "Your food was deleted";

            return RedirectToAction("Index");
        }


        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);

            return service;
        }
    }
}