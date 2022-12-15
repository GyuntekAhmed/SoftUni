namespace BookingApp.Models.Rooms.Entities
{
    public class DoubleBed : Room
    {
        private const int bedCapacity = 2;

        public DoubleBed() : base(bedCapacity)
        {
        }
    }
}
