using Hart_PROG7311_Part_2.Models;
using Hart_PROG7311_Part_2.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using static System.Net.WebRequestMethods;

namespace Hart_PROG7311_Part_2.Controllers
{
    //Microsoft Learn. (2025, May 10). Routing to controller actions in ASP.NET Core.Retrieved from Microsoft Learn: https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-9.0
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        EmployeeRepository er = new EmployeeRepository();
        FarmerRepository fr = new FarmerRepository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // GET: Home
        public IActionResult Index()
        {
            return View();
        }
        // GET: Home/Index
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // POST: Home/Login
        public async Task<IActionResult> LoginUser(LoginModel l)
        {
            // Using the EmployeeRepository to check if the user exists
            var employee = er.Get(l.Username, l.Password);
            if (employee != null)
            {
                HttpContext.Session.SetString("Username", employee.Username.ToString());
                HttpContext.Session.SetInt32("ID", employee.EmployeeModelID);
                HttpContext.Session.SetString("UserType", "Employee");
                return RedirectToAction("Index", "Product");
            }

            var farmer = fr.Get(l.Username, l.Password);
            if (farmer != null)
            {
                HttpContext.Session.SetString("Username", farmer.Username.ToString());
                HttpContext.Session.SetInt32("ID", farmer.FarmerModelID);
                HttpContext.Session.SetString("UserType", "Farmer");
                return RedirectToAction("FarmerIndex", "Product");
            }
            // If the user does not exist, return to the Login view with an error message
            ModelState.AddModelError("", "Invalid username or password.");
            return View("Login");
        }
        // GET: Home/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        // GET: Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
