using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    // class that implements the interface
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants; // ?
        
        // constructors
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French },
                new Restaurant { Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
        }

        // returns one restaurant, 
        public Restaurant Get(int id)
        {
            // give first restaurant that matches the id OR null reference
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var currentRestaurant = Get(restaurant.Id);
            if (currentRestaurant != null)
            {
                currentRestaurant.Name = restaurant.Name;
                currentRestaurant.Cuisine = restaurant.Cuisine;
            }
        }
        public void Remove(int id) 
        {
            var restaurant = Get(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }
    }
}
