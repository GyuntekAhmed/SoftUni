namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.Genre;

    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Name { get; set; } = null!;
    }
}
