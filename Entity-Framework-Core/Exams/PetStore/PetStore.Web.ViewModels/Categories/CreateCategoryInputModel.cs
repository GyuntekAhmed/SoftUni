namespace PetStore.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Services.Mapping;
    using Common;

    public class CreateCategoryInputModel : IMapTo<Category>
    {
        [Required]
        [StringLength(CategoryInputModelValidationConstants.NameMaxLength,
            MinimumLength = CategoryInputModelValidationConstants.NameMinLength,
            ErrorMessage = CategoryInputModelValidationConstants.NameLengthErrorMessage)]
        public string Name { get; set; } = null!;
    }
}
