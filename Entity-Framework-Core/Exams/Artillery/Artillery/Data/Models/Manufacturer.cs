namespace Artillery.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Utilities;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ManufacturerNameMaxLength)]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.ManufacturerFoundedMaxValue)]
        public string Founded { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
