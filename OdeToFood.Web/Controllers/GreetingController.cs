using Microsoft.Ajax.Utilities;
using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        // Index is default action if action is not specified in teh ulr /controller/action/id
        public ActionResult Index(string name)
        {
            //mvv controller will go look for name arg, it could look for in the query string 

            // controller to build a model to contain the information to render (view model)
            var model = new GreetingViewModel();

            // directly look for the query string in the url, but can just pass in the name as an argument to the Index method
            //var name = HttpContext.Request.QueryString["name"];
            model.Name = name ?? "no name";
            model.Message = ConfigurationManager.AppSettings["message"];
            
            return View(model);
        }
    }
}