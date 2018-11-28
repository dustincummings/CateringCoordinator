using CateringCoordinator.Models;
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
            var model = new EventList[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}