using Microsoft.EntityFrameworkCore;
using MyOdeToFood.Core;

namespace MyOdeToFood.Data
{
    public class MyOdeToFoodDbContext: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public MyOdeToFoodDbContext(DbContextOptions<MyOdeToFoodDbContext> options):base(options)
        {
        }
    }
}