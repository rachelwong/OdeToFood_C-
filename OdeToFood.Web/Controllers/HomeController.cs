using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Data.Services;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        // goes to View folder, 
        // the HomeController will look for Home folder, 
        // Index method will look for Index.cshtml

        // access the database throught this interface
        IRestaurantData db; // private to this controller // ? why can't this be of type InMemoryRestauratData?

        // constructor to initialise the db field
        public HomeController(IRestaurantData db)
        {
            //db = new InMemoryRestaurantData(); // can be replaced with dependency injectino 
            this.db = db;
        }
        // ActionREsult tells MVC what to do next --> render a view 
        public ActionResult Index()
        {
            // needs to build a model to carry into the view to display a list of restauratns
            // receive a request and decide what to do next
            // build model, contain all info that the view needs to present
            // model doesn't know about view or controller (final destination format) - separation of concerns

            var model = db.GetAll();
            return View(model); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}