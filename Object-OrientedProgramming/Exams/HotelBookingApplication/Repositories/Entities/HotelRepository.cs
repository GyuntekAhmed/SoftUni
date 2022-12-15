namespace BookingApp.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Hotels.Contacts;

    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;
        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            this.hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All() => this.hotels;

        public IHotel Select(string criteria)
            => this.hotels.FirstOrDefault(x => x.FullName == criteria);
    }
}
