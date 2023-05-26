using Microsoft.AspNetCore.Mvc;

using static MVCIntroDemo.Seeding.ProductsData;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult All()
        {
            return View(Products);
        }
    }
}
