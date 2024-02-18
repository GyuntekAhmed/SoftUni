using PetStore.Services.Data.Interfaces;

namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.categoryService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All(int page)
        {
            IEnumerable<ListCategoryViewModel> allCategories =
                await this.categoryService
                    .GetAllWithPaginationAsync(page);


            var viewModel = new AllCategoriesViewModel()
            {
                AllCategories = allCategories,
                PageCount = (int)Math.Ceiling(allCategories.Count() / 20.0),
                ActivePage = page
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool isValidCategory =
                await this.categoryService
                    .ExistsAsync(id);

            if (!isValidCategory)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var categoryToEdit =
                await this.categoryService
                    .GetByIdAndPrepareEditAsync(id);

            return this.View(categoryToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            bool isValidCategory =
                await this.categoryService
                    .ExistsAsync(model.Id);

            if (!isValidCategory)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.categoryService.EditCategoryAsync(model);

            return this.RedirectToAction("All");
        }
    }
}
