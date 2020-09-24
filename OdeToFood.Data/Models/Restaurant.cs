using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    // adding public allows usage outside of odeToFood.Data
    // is an entity as it represents information to be persisted into the database
    // entities may not be the best model for a view. a view might need more information. so view model may be needed.
    public class Restaurant
    {
        public int Id { get; set; }

        [Required] // this is data annotation (not nullable)
        //[Range(1, 10)]
        public string Name { get; set; }
        [Display(Name="Type of food")]
        public CuisineType Cuisine { get; set; } // restrict the types here by creating a separate class that defines the list
    }
}
