namespace PetStore.Services.Data.Interfaces
{
    using Web.ViewModels.Categories;

    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryInputModel inputModel);
        
        Task<IEnumerable<AllCategoriesViewModel>> GetAllAsync();
    }
}
