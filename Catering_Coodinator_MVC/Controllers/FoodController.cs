﻿using CateringCoordinator.Models;
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
            if (ModelState.IsValid)
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

        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);

            return service;
        }
    }
}