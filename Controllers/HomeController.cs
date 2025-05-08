using Hart_PROG7311_Part_2.Models;
using Hart_PROG7311_Part_2.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Hart_PROG7311_Part_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        EmployeeRepository er = new EmployeeRepository();
        FarmerRepository fr = new FarmerRepository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
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
                return RedirectToAction("Index", "Product");
            }
            // If the user does not exist, return to the Login view with an error message
            ModelState.AddModelError("", "Invalid username or password.");
            return View("Login");
        }

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
