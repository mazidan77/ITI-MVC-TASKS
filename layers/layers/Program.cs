using layers.Models;
using layers.Reposiotries;
using Microsoft.AspNetCore.Identity;
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

            builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<companyDBcontext>();
            builder.Services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase= false;
                x.Password.RequireLowercase= false;
                x.Password.RequiredLength = 6;
                x.Password.RequireDigit=false;
                x.User.RequireUniqueEmail = true;
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

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}