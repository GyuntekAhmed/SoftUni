namespace BookingApp.Repositories.Entities
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Bookings.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            this.bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => this.bookings;

        public IBooking Select(string criteria)
            => this.bookings.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);
    }
}
