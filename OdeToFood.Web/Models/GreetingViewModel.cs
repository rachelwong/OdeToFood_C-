using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OdeToFood.Data.Models;

namespace OdeToFood.Web.Models
{
    public class GreetingViewModel
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; } // an entity model 

        //lookup data (i.e. a list of available filter options)
    }


}