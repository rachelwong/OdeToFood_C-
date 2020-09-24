using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    // simulates accessing data 
    public interface IRestaurantData
    {
        // define operations on data source
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id); // returns a single restaurant by id
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Remove(int id);
    }
}
