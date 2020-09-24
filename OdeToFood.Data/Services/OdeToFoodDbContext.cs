using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    // gateway to database
    public class OdeToFoodDbContext : DbContext
    {
        // table of a data in teh database somewhere that matches the Restaurant model
        // there should be a table called restauran tthat has columsn taht match the restaurant model 
        public DbSet<Restaurant> Restaurants { get; set; } // name of this variable here also refers to a table's name
    }
}
