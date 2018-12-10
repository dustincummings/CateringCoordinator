using CateringCoordinator.Data;
using CateringCoordinator.Models;
using CateringCoordinator.Models.EventModels;
using CateringCoordinator.Models.FoodModels;
using CateringCoordinator.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catering_Coodinator_MVC.Controllers
{
    public class EventController : Controller
    {
        
        [Authorize]
        // GET: Event
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            var model = service.GetEvents();

            return View(model);
        }

        public ActionResult Create()
        {
            var customerService = CreateCustomerService();
            var customers = customerService.GetCustomers();
            //var foodService = CreateFoodService();
            //var foods = foodService.GetFoods();
            //ViewBag.FoodId =  new SelectList(foods, "FoodId", "Name");
            ViewBag.CustomerId = new SelectList(customers, "CustomerId","FullName");

            var food = new FoodListItem();
            food.Food = new List<FoodListItem>();
            PopulateFoodData(food);

            return View();
        }

        private void PopulateFoodData(FoodListItem food)
        {
            var foodService = CreateFoodService();
            var allFoods = foodService.GetFoods();

            var viewModel = new List<FoodListItem>();

            foreach (var foods in allFoods)
            {
                viewModel.Add(new FoodListItem
                {
                    FoodId = food.FoodId,
                    Name = food.Name
                });
            }
            ViewBag.AllEventFoods = viewModel;
        }

        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            return service;

        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid)
            {
            return View(model);
            }
            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = " Your Event was created.";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Event could not be created.");
            return View(model);
        }

        private EventService CreateEventService()
        {
          var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var customerService = CreateCustomerService();
            var customers = customerService.GetCustomers();
            var foodService = CreateFoodService();
            var foods = foodService.GetFoods();
            ViewBag.FoodId = new SelectList(foods, "FoodId", "Name", detail.FoodId);
            ViewBag.CustomerId = new SelectList(customers, "CustomerId", "FullName",detail.CustomerId);
            
            var model =
                new EventEdit
                {
                    EventId = detail.EventId,
                    FullName  = detail.FullName,                   
                    Name = detail.FoodName,
                    NumOfGuest = detail.NumOfGuest,
                    Location = detail.Location,
                    DateOfEvent = detail.DateOfEvent,
                    //Food=detail.,
                    FoodId=detail.FoodId,
                    //Customer = detail.Customer,
                    CustomerId = detail.CustomerId
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Edit(int id, EventEdit model)
            

        {
            var customerService = CreateCustomerService();
            var customers = customerService.GetCustomers();
            var foodService = CreateFoodService();
            var foods = foodService.GetFoods();
            ViewBag.FoodId = new SelectList(foods, "FoodId", "Name");
            ViewBag.CustomerId = new SelectList(customers, "CustomerId", "FullName");
            if (!ModelState.IsValid) return View(model);

            if(model.EventId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your Event was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your event could not be updated.");

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEventService();

            service.DeleteEvent(id);

            TempData["SaveResult"] = "Your event was deleted";

            return RedirectToAction("Index");
        }
    }
}