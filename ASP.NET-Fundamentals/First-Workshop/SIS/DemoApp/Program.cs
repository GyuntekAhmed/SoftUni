using System.Text;
using SIS.HTTP;
using SIS.HTTP.Response;

namespace DemoApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var routeTable = new List<Route>
            {
                new Route(HttpMethodType.Get, "/", Index),
                new Route(HttpMethodType.Get, "/users/login", Login),
                new Route(HttpMethodType.Post, "/users/login", DoLogin),
                new Route(HttpMethodType.Post, "/contact", Contact),
                new Route(HttpMethodType.Post, "/favicon.ico", Favicon),
            };

            HttpServer httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse Favicon(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        public static HttpResponse Contact(HttpRequest request)
        {
            return new HtmlResponse("<h1>contact</h1>");
        }

        public static HttpResponse Index(HttpRequest request)
        {
            return new HtmlResponse("<h1>home page</h1>");
        }

        public static HttpResponse Login(HttpRequest request)
        {
            return new HtmlResponse("<h1>login page</h1>");
        }

        public static HttpResponse DoLogin(HttpRequest request)
        {
            return new HtmlResponse("<h1>login page form</h1>");
        }
    }
}