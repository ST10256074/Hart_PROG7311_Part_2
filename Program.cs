using Hart_PROG7311_Part_2.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Hart_PROG7311_Part_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Sessions
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // On Program First Run Seed data into database
            AppDbContext db = new AppDbContext();
            var check = db.Employees.ToList();
            if (check.Count == 0)
            {
                db.Employees.Add(new Models.EmployeeModel("Admin","admin","admin","123 Jackson Street","nowhere","042 245 2265"));
                db.Farmers.Add(new Models.FarmerModel("Farmer","Farmer","Farmer","123 Farmer Road","no profile pic","031 224 5322",DateTime.Now));
                db.Farmers.Add(new Models.FarmerModel("Farmer2","Farmer2","Farmer2","123 Farmer Road","no profile pic","031 224 5322",DateTime.Now));
                db.Products.Add(new Models.ProductModel(1, "Test Product", "Category", "Description", "no image", 0, 0, DateTime.Now, DateTime.Now));
                db.Products.Add(new Models.ProductModel(1, "Tomatoes", "Produce", "Fresh Tomatoes", "ProductImages/Tomato.jpg", 0, 0, DateTime.Now, DateTime.Now));
                db.Products.Add(new Models.ProductModel(1, "Potatoes", "Produce", "Fresh Potatoes", "ProductImages/Potato.jpg", 0, 0, DateTime.Now, DateTime.Now));
                db.Products.Add(new Models.ProductModel(1, "Carrots", "Produce", "Fresh Carrots", "ProductImages/Carrot.jpg", 0, 0, DateTime.Now, DateTime.Now));
                db.Products.Add(new Models.ProductModel(2, "Solar Panel", "Solar", "Solar Panel", "ProductImages/SolarPanel.jpg", 0, 0, DateTime.Now, DateTime.Now));
            }

            db.SaveChanges();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db2 = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db2.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Sessions
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
