// ReSharper disable RedundantNameQualifier
namespace PetStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using PetStore.Data.Models.Common;

    public class Client : ApplicationUser
    {
        public Client()
        {
            this.PaymentCards = new HashSet<CardInfo>();
            this.Pets = new HashSet<Pet>();
            this.Orders = new HashSet<Order>();
        }

        [Required]
        [MaxLength(ClientValidationConstants.NameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ClientValidationConstants.NameMaxLength)]
        public string LastName { get; set; } = null!;

        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;

        [ForeignKey(nameof(ClientCard))]
        public string? ClientCardId { get; set; }

        public virtual ClientCard? ClientCard { get; set; }

        public virtual ICollection<CardInfo> PaymentCards { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
