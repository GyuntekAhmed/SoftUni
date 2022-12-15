namespace BookingApp.Models.Rooms.Entities
{
    public class Studio : Room
    {
        private const int bedCapacity = 4;

        public Studio() : base(bedCapacity)
        {
        }
    }
}
