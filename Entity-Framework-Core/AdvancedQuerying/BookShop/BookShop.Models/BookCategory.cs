namespace BookShop.Models
{
    public class BookCategory
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
