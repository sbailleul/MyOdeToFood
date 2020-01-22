using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyOdeToFood.Core;
using MyOdeToFood.Data;

namespace MyOdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        
        public ListModel(IConfiguration config,IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            _restaurantData = restaurantData;
            _config = config;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError("Executing ListModel");
            Restaurants = _restaurantData.GetByName(SearchTerm);
            Message = _config["Message"];
        }
    }
}