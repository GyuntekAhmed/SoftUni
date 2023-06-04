namespace Forum.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Interfaces;
    using ViewModels.Post;

    public class PostService : IPostService
    {
        private readonly ForumDbContext dbContext;

        public PostService(ForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
        {
            IEnumerable<PostListViewModel> allPosts = await dbContext
                .Posts
                .Select(p => new PostListViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToArrayAsync();

            return allPosts;
        }
    }
}
