namespace Homies.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using Models.Event;
    using System.Security.Claims;

    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.GetAllEventsAsync();

            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            var model = await eventService.GetJoinedEventsAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var newEvent = await eventService.GetEventById(id);

            var model = await eventService.GetJoinedEventsAsync(GetUserId());

            if (model.Any(m => m.Id ==id))
            {
                return RedirectToAction(nameof(All));
            }

            await eventService.JoinToEvent(GetUserId(), newEvent);

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var evnt = await eventService.GetEventById(id);

            await eventService.LeaveFromEvent(GetUserId(), evnt);

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel()
            {
                Types = await eventService.GetAllTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            var types = await eventService.GetAllTypesAsync();

            if (!ModelState.IsValid)
            {
                model.Types = await eventService.GetAllTypesAsync();

                return View(model);
            }

            if (!types.Any(t => t.Id == model.TypeId))
            {
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist!");
            }

            model.OrganaizerId = GetUserId();

            await eventService.CreateTaskAsync(model);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id)
        {
            var model = eventService.GetEventDetails(id);

            return View(model);
        }

        [HttpGet]
#pragma warning disable CS1998
        public async Task<IActionResult> Edit(int id)
#pragma warning restore CS1998
        {
            var model = eventService.GetEventFormModel(id);

            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != model.OrganaizerId)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormViewModel model)
        {
            if (!eventService.GetAllTypesAsync().Result.Any(b => b.Id == model.TypeId))
            {
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Types = eventService.GetAllTypesAsync().Result;

                return View(model);
            }

            await eventService.EditEventAsync(id, model);

            return RedirectToAction(nameof(All));
        }
    }
}
