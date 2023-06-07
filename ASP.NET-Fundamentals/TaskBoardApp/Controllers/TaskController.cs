using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardDbContext data;

        public TaskController(TaskBoardDbContext context)
        {
            data = context;
        }

        public async Task<IActionResult> Create()
        {
            TaskFormModel model = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!GetBoards().Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected   Board does not exist.");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                model.Boards = GetBoards();
                return View(model);
            }

            Task task = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
                OwnerId = currentUserId,
            };

            await data.Tasks.AddAsync(task);
            await data.SaveChangesAsync();

            var boards = data.Boards;

            return RedirectToAction("All", "Board");
        }

        private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private IEnumerable<TaskBoardModel> GetBoards()
            => data
            .Boards
            .Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name
            });
    }
}
