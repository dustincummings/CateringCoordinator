using CateringCoordinator.Models;
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
            var model = new FoodListItem[0];
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

            }
            return View(model);
        }

    }
}