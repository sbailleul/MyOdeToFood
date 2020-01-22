using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyOdeToFood.Core;

namespace MyOdeToFood.Data
{
    public class SqlRestaurantData: IRestaurantData
    {
        private readonly MyOdeToFoodDbContext _db;

        public SqlRestaurantData(MyOdeToFoodDbContext db)
        {
            _db = db;    
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            return from r in _db.Restaurants
                where string.IsNullOrWhiteSpace(name) || r.Name.StartsWith(name)
                select r;
        }

        public Restaurant GetById(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _db.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurant = GetById(restaurantId);
            if (restaurant != null)
            {
                _db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int Count()
        {
            return _db.Restaurants.Count();
        }
    }
}