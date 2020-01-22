using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOdeToFood.Core;
using MyOdeToFood.Data;

namespace MyOdeToFood
{
    public class IndexModel : PageModel
    {
        private readonly MyOdeToFood.Data.MyOdeToFoodDbContext _context;

        public IndexModel(MyOdeToFood.Data.MyOdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
