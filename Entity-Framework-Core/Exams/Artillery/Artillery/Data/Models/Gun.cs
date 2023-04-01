namespace Artillery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class Gun
    {
        public Gun()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        public int GunWeight { get; set; }

        public double BarrelLength { get; set; }

        public int? NumberBuild{ get; set; }

        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        [ForeignKey(nameof(Shell))]
        public int ShellId { get; set; }
        public virtual Shell Shell { get; set; } = null!;

        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
