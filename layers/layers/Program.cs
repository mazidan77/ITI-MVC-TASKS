using layers.Models;
using layers.Reposiotries;
using Microsoft.EntityFrameworkCore;

namespace layers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<companyDBcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("myCS"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /////
            ///
            builder.Services.AddScoped<IemployeeRepo, employeeRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}