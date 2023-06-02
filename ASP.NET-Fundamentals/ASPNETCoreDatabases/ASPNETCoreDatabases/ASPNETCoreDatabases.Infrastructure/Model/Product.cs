using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreDatabases.Infrastructure.Model
{
    [Comment("Product table")]
    public class Product
    {
        public Product()
        {
             this.ProductNotes = new List<ProductNote>();
        }

        [Comment("Product id")]
        [Key]
        public int Id { get; set; }

        [Comment("Product name")]
        [MaxLength(155)]
        [Required]
        public string ProductName { get; set; } = null!;

        [Comment("Product quantity")]
        public int Quantity { get; set; }

        [Comment("Product price")]
        public decimal? Price { get; set; }

        public List<ProductNote> ProductNotes { get; set; }
    }
}
