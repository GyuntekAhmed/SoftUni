// ReSharper disable VirtualMemberCallInConstructor
namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public Item()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string? Name { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; } = null!;

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}