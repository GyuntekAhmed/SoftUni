namespace Homies.Contracts
{
    using Models.Type;
    using Models.Event;

    public interface IEventService
    {
        Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync();
        Task CreateTaskAsync(EventFormViewModel model);
        Task<List<TypeViewModel>> GetAllTypesAsync();
        Task EditEventAsync(int id, EventFormViewModel model);
        EventFormViewModel GetEventFormModel(int id);
        EventDetailsViewModel GetEventDetails(int id);
        Task<List<JoinedEventsViewModel>> GetJoinedEventsAsync(string userId);
        Task<EventViewModel> GetEventById(int id);
        Task JoinToEvent(string userId, EventViewModel model);
        Task LeaveFromEvent(string userId, EventViewModel model);
    }
}
