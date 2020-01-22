using System;
using System.Collections;
using System.Collections.Generic;
using MyOdeToFood.Core;

namespace MyOdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetByName(string name);
        Restaurant GetById(int id);

        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Add(Restaurant newRestaurant);
        int Commit();

        Restaurant Delete(int restaurantId);

        int Count();
    }
}