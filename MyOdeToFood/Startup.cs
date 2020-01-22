using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MyOdeToFood.Data;

namespace MyOdeToFood
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<MyOdeToFoodDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyOdeToFoodDb"));
            });
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(SayHelloMiddleware);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    "./node_modules"),
                RequestPath = "/node_modules"
            });
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
            
            
        }

        private static RequestDelegate SayHelloMiddleware(RequestDelegate next)
        {
            return async context =>
            {
                if (context.Request.Path.StartsWithSegments("/hello"))
                {
                    await context.Response.WriteAsync("Hello world");
                }
                else
                {
                    await next(context);
                }
            };
        }
    }
}