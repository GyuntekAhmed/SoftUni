namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ClientTruck
    {
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;

        [ForeignKey("Truck")]
        public int TruckId { get; set; }
        public virtual Truck Truck { get; set; } = null!;
    }
}
