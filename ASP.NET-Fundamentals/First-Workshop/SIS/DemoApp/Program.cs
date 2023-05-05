using SIS.HTTP;
using SIS.HTTP.Response;
using System.Text;

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
            db.SaveChanges();

            return new RedirectResponse("/");
        }

        private static HttpResponse Favicon(HttpRequest request)
        {
            return new HtmlResponse("<h1Favicon</h1>");
        }

        public static HttpResponse Index(HttpRequest request)
        {
            var username = request.SessionData.ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";

            var db = new ApplicationDbContext();
            var tweets = db.Tweets.Select(x => new
            {
                x.CreatedOn,
                x.Creator,
                x.Content
            }).ToList();

            StringBuilder html = new StringBuilder();
            html.Append("<table><tr><th>Date</th><th>Creator</th><th>Content</th></tr>");
            foreach (var tweet in tweets)
            {
                html.Append($"<tr><td>{tweet.CreatedOn}</td><td>{tweet.Creator}</td><td>{tweet.Content}</td></tr>");
            }
            html.Append("</table>");
            html.Append(
                $"<form action='/Tweets/Create' method='post'><input name='creator' /><br />" +
                $"<textarea name='tweetName'></textarea><br /><input type='submit'/></form>");

            return new HtmlResponse(html.ToString());
        }
    }
}