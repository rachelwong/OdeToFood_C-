using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    // replace the InMemoryRestaurantData with database connection
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext db;

        //construct new instance of dbcontext
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public void Add(Restaurant restaurant)
        {
            // id will be the primary key and it will be the identity column
            db.Restaurants.Add(restaurant);
            db.SaveChanges(); // commit to database
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            // retrieve restaurant from db first
            // not ideal for multiple users 
            //var record = Get(restaurant.Id);
            //if (record != null)
            //{
            //    record.Name = restaurant.Name;
            //    record.Cuisine = restaurant.Cuisine;
            //}
            //db.SaveChanges();

            // with optimistic concurrency
            var entry = db.Entry(restaurant);//track changes to this object which should already be in the database 
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Remove(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }
    }
}