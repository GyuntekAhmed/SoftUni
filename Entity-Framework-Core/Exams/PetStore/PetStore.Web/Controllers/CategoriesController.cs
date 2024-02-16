namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
