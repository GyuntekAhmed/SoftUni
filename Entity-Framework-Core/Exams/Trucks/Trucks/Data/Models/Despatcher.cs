namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Utilities;

    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks = new HashSet<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Position { get; set; } = null!;

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
