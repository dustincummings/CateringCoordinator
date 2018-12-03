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
            return View();
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
            var model =
                new EventEdit
                {
                    EventId = detail.EventId,
                    CustomerId = detail.CustomerId,
                    FoodId = detail.FoodId,
                    PrepArea = detail.PrepArea,
                    NumOfGuest = detail.NumOfGuest,
                    NumOfHelpers = detail.NumOfHelpers,
                    SuppliesNeeded = detail.SuppliesNeeded,
                    Location = detail.Location,
                    IsFullService = detail.IsFullService,
                    DateOfEvent = detail.DateOfEvent,
                    CostOfEvent = detail.CostOfEvent,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Edit(int id, EventEdit model)
        {
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