namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Utilities;

    public class Client
    {
        public Client()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.ClientNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
