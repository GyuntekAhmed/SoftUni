namespace Forum.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Forum.ViewModels.Post;
    using Services.Interfaces;

    public class PostController : Controller
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<PostListViewModel> allPosts =
                await this.postService.ListAllAsync();

            return View(allPosts);
        }
    }
}
