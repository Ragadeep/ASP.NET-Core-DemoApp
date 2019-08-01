using DemoLearning.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DemoLearning.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Mcd", Location = "Mumbai", Cuisine = Restaurant.CuisineType.Indian },
                new Restaurant{ Id = 2, Name = "Dominos", Location = "Hyderabad", Cuisine = Restaurant.CuisineType.Italian },
                new Restaurant{ Id = 3, Name = "KCF", Location = "Pune", Cuisine = Restaurant.CuisineType.Mexcian }
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
