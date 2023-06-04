namespace Forum.Data.Seeding
{
    using Models;

    class PostSeeder
    {
        internal Post[] GeneratePost()
        {
            ICollection<Post> posts = new HashSet<Post>();

            Post currentPost;

            currentPost = new Post()
            {
                Title = "My first post",
                Content = "Dot.Net is better"
            };

            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My second post",
                Content = "Dot.Net.Core same"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My third post",
                Content = "Html is not programing language...."
            };
            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
