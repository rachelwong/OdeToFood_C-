using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // a route trace.ax/1/2/3/4 will be ignored
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // template that defines teh route for the application
            // /home/contact/1 home is the controller, contact is the action, 1 is the parameter id
            // tells framework to look for the {controller}, and run the method that is the {action}
            // tells framework to route a url to a specific part of the codebaes/software on what to do next
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", // changing id into key will pass the querystring onto the route
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // anonymous type to tell mvc framework 
            );
        }
    }
}
