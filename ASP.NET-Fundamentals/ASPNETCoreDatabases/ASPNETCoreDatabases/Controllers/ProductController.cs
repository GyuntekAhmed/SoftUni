using ASPNETCoreDatabases.Core.Contracts;
using ASPNETCoreDatabases.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreDatabases.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetProductsAsync();

            return View("All", model);
        }

        public IActionResult Add()
        {
            var model = new ProductFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _productService.AddProductAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
