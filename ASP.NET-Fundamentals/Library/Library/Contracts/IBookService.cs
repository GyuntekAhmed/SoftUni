using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task AddBookAsync(AddBookViewModel viewModel);
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
        Task<AddBookViewModel> GetNewAddBookModelAsync();
        Task<IEnumerable<AllBookViewModel>> GetMyBookAsync(string userId);
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);
    }
}
