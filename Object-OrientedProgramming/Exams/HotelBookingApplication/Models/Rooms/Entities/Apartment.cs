namespace BookingApp.Models.Rooms.Entities
{
    public class Apartment : Room
    {
        private const int bedCapacity = 6;

        public Apartment() : base(bedCapacity)
        {
        }
    }
}
