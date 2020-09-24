using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db; // initialised field

        // contructor
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public ActionResult Index() {

            var model = db.GetAll();
            return View(model);
        }

        // framework will lok for id in the query string and in the data that was extracted from the route (route config parameter)
        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            // nullchecks 
            if (model == null)
            {
                //return RedirectToAction("Index"); // go back to /restaurants
                return View("NotFound"); // goes to NotFound.cshtml
            }


            return View(model);
            //var model = db.GetAll().Where(x => x.id)
        }

        [HttpGet] // specify that this method only run to GET method to show the create page
        public ActionResult Create()
        {
            //restuarant has id, name, cuisine properties
            return View();
        }

        // needs two actions
        // returns view 
        // receives the input 
        [HttpPost] // specify that this method only run for an HTTP POST even if the name is the same
        [ValidateAntiForgeryToken] // adding an attribute to the method
        public ActionResult Create(Restaurant restaurant)
        {
            // ModelState data structure that tells you what is going on during model binding
            // can represent the attempted value for validation
            //ModelState["Name"]
            //if (String.IsNullOrEmpty(restaurant.Name))
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            //}

            // data annoation are metadata attached to models & view models and influence validation during model binding
            if (ModelState.IsValid)
            { 
                db.Add(restaurant);
                //return RedirectToAction("Index"); // back to original listing of restaurants may not be as helpful
                //restuarant has id, name, cuisine properties
                // routeValues - can pass anonymously typed object with values to specify for a route
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound(); // just returns straight 404
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // adding an attribute to the method
        public ActionResult Edit(Restaurant restaurant) 
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant changes!"; // potential for security risk
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound"); // just returns straight 404
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Delete(int id, FormCollection form) // form is throwaway form and not used
        {
            db.Remove(id);
            return RedirectToAction("Index");
        }
    }
}