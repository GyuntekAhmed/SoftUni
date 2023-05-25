using Microsoft.AspNetCore.Mvc;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
