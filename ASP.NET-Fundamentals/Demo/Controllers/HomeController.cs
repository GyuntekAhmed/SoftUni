using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // View Data => Dictionary
            // View Bag => Obect
            ViewData["MyData"] = "I am inserting data from controller in view";
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC app.";

            return View();
        }

        [ActionName("AboutMvc")]
        public IActionResult Info()
        {
            return this.Redirect("https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}