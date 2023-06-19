namespace Homies.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using Type = Data.Models.Type;
    using Contracts;
    using Data;
    using Models.Event;
    using Data.Models;
    using Models.Type;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateTaskAsync(EventFormViewModel model)
        {
            var newEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = model.OrganaizerId
            };

            await dbContext.Events.AddAsync(newEvent);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditEventAsync(int id, EventFormViewModel model)
        {
            var newEvent = await dbContext.Events.FindAsync(id);

            newEvent!.Name = model.Name; 
            newEvent.Description = model.Description;
            newEvent.Start = model.Start;
            newEvent.End = model.End;
            newEvent.TypeId = model.TypeId;

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync()
        {
            return await dbContext.Events
                .Select(e => new EventAllViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Organaizer = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .ToArrayAsync();
        }

        public async Task<EventViewModel> GetEventById(int id)
        {
            return await dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Type = e.Type.Name
                })
                .FirstAsync();
        }

        public EventDetailsViewModel GetEventDetails(int id)
        {
            return dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    CreatedOn = e.CreatedOn,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .First();
        }

        public EventFormViewModel GetEventFormModel(int id)
        {
            return  dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new EventFormViewModel()
                {
                    Name = e.Name,
                    Description = e.Description,
                    OrganaizerId = e.OrganiserId,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.TypeId,
                    Types = dbContext.Types
                        .Select(t => new TypeViewModel
                        {
                            Id = t.Id,
                            Name = t.Name
                        }).ToList()
                }).First();
        }

        public async Task<List<JoinedEventsViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await dbContext.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(e => new JoinedEventsViewModel()
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    Start = e.Event.Start,
                    Type = e.Event.Type.Name
                })
                .ToListAsync();
        }

        public async Task JoinToEvent(string userId, EventViewModel model)
        {
            if (!await dbContext.EventsParticipants.AnyAsync(e => e.HelperId == userId && e.EventId == model.Id))
            {
                await dbContext.EventsParticipants.AddAsync(new EventParticipant
                {
                    HelperId = userId,
                    EventId = model.Id
                });

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task LeaveFromEvent(string userId, EventViewModel model)
        {
            var eventParticipant = await dbContext.EventsParticipants
                .FirstOrDefaultAsync(e => e.HelperId == userId && e.EventId == model.Id);

            if (eventParticipant != null)
            {
                dbContext.EventsParticipants.Remove(eventParticipant);

                await dbContext.SaveChangesAsync();
            }
        }

        async Task<List<TypeViewModel>> IEventService.GetAllTypesAsync()
        {
            return await dbContext.Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}
