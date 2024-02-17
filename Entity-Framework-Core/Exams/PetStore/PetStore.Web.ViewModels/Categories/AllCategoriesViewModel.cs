namespace PetStore.Web.ViewModels.Categories
{
    using Data.Models;
    using Services.Mapping;

    public class AllCategoriesViewModel : IMapFrom<Category>
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
