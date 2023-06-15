using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task AddBookAsync(AddBookViewModel viewModel);
        Task AddBookToCollectionAsync(string userId, AddCollectionBookViewModel book);
        Task<AddBookViewModel> GetNewAddBookModelAsync();
    }
}
