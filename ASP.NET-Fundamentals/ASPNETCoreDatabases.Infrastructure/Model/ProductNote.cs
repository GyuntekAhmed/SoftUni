using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreDatabases.Infrastructure.Model
{
    [Comment("Product note table")]
    public class ProductNote
    {
        [Comment("Product note id")]
        [Key]
        public int Id { get; set; }

        [Comment("Product note text")]
        [MaxLength(500)]
        [Required]
        public string Note { get; set; } = null!;

        [Comment("Product note date")]
        [Required]
        public DateTime NoteDate { get; set; }

        [Comment("Product note product id")]
        [ForeignKey(nameof(Product))]
        [Required]
        public int ProductId { get; set; }
        [Comment("Product note product")]
        public Product Product { get; set; } = null!;
    }
}
