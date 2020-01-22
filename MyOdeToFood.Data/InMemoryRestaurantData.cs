using System.Collections.Generic;
using System.Linq;
using MyOdeToFood.Core;

namespace MyOdeToFood.Data
{
    public class InMemoryRestaurantData: IRestaurantData
    {
        readonly List<Restaurant> _restaurants;


        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant(){Name = "Scott's Pizza", Id = 1, Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant(){Name = "Indian palace", Id = 2, Location = "Bali", Cuisine = CuisineType.Indian},
                new Restaurant(){Name = "Tortilla bonita", Id = 3, Location = "Mexico", Cuisine = CuisineType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            return from restaurant 
                    in _restaurants 
                where string.IsNullOrWhiteSpace(name) || restaurant.Name.StartsWith(name)
                orderby restaurant.Name 
                select restaurant;
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant =  _restaurants.FirstOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant == null) return restaurant;
            
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Name = updatedRestaurant.Name;
            restaurant.Cuisine = updatedRestaurant.Cuisine;

            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurant = _restaurants.FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int Count()
        {
            return _restaurants.Count;
        }
    }
}