using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OdeToFood.Web
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            // no action here so no method in the RestaurantsController
            // the action is the HTTP methods GET/POST/UPDATE/DELETE
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
