namespace PetStore.Web.ViewModels.Categories
{

    public class AllCategoriesViewModel
    {
        public IEnumerable<ListCategoryViewModel> AllCategories { get; set; }

        public int PageCount { get; set; }

        public int ActivePage { get; set; }
    }
}
