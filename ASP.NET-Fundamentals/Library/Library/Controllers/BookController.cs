namespace Library.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using Models;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBooksAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await bookService.GetNewAddBookModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            decimal rating;
            if (model.Rating < 0 || model.Rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating),"Rating must be a number between 0 and 10.");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            var model = await bookService.GetMyBookAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> AddBookToCollectionAsync(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = GetUserId();

            await bookService.RemoveBookFromCollectionAsync(userId, book);

            return RedirectToAction(nameof(Mine));
        }
    }
}
