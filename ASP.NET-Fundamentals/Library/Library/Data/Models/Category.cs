using System.ComponentModel.DataAnnotations;
using static Library.Common.DataConstants.CategoryConstants;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Book> Books { get; set; }
    }
}
