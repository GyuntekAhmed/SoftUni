namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.CategoryValidationConstants;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}