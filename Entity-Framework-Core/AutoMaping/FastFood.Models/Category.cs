namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class Category
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(ValidationConstants.CategoryNameMaxLength, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
