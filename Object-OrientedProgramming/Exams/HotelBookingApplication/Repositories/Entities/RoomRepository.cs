namespace BookingApp.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using BookingApp.Models.Rooms.Contracts;
    using Contracts;
    using Models.Rooms.Entities;

    public class RoomRepository : IRepository<Room>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(Room model)
        {
            rooms.Add(model);
        }

        public Room Select(string criteria)
        {
            return (Room)rooms.FirstOrDefault(r => r.GetType().Name == criteria);
        }

        public IReadOnlyCollection<Room> All() => (IReadOnlyCollection<Room>)rooms;
    }
}
