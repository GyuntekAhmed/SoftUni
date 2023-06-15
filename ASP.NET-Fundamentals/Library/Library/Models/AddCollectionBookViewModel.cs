using System.ComponentModel.DataAnnotations;
using static Library.Common.ValidationConstants.BookValidationConstants;

namespace Library.Models
{
    public class AddCollectionBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Range(1, 10.00)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }
    }
}
