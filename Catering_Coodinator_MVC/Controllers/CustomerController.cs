using CateringCoordinator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catering_Coodinator_MVC.Controllers
{
    public class CustomerController : Controller
    {
        [Authorize]
        // GET: Customer
        public ActionResult Index()
        {
            var model = new CustomerList[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}