using SIS.HTTP;
using SIS.HTTP.Response;

namespace DemoApp
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            var routeTable = new List<Route>
            {
                new Route(HttpMethodType.Get, "/", Index),
                new Route(HttpMethodType.Post, "/Tweets/Create", CreateTweet),
                new Route(HttpMethodType.Post, "/favicon.ico", Favicon),
            };

            HttpServer httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse CreateTweet(HttpRequest request)
        {
            var db = new ApplicationDbContext();
            db.Tweets.Add(new Tweet
            {
                CreatedOn = DateTime.UtcNow,
                Creator = request.FormData["creator"],
                Content = request.FormData["tweetName"]
            });

            return new HtmlResponse("Thank you for your tweet!!!");
        }

        private static HttpResponse Favicon(HttpRequest request)
        {
            return new HtmlResponse("<h1Favicon</h1>");
        }

        public static HttpResponse Index(HttpRequest request)
        {
            var username = request.SessionData.ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";
            return new HtmlResponse(
                $"<form action='/Tweets/Create' method='post'><input name='creator' /><br />" +
                $"<textarea name='tweetName'></textarea><br /><input type='submit'/></form>");
        }
    }
}