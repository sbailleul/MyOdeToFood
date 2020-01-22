using Microsoft.AspNetCore.Mvc;
using MyOdeToFood.Data;

namespace MyOdeToFood.Pages.ViewComponents
{
    public class RestaurantCountViewComponent: ViewComponent
    {
        private readonly IRestaurantData _restaurantData;
        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.Count();
            return View(count);
        }
    }
}