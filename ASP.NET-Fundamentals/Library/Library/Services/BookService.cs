using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;
        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            var model = new AddBookViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task AddBookToCollectionAsync(string userId, AddCollectionBookViewModel book)
        {
            bool alreadyAdded = await dbContext.IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (alreadyAdded == false)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id
                };

                await dbContext.IdentityUserBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await dbContext.Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Author = b.Author,
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();
        }
    }
}
