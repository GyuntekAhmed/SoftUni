﻿namespace SIS.HTTP
{
    using System.Net;
    using System.Net.Sockets;
    using System.Text;


    public class HttpServer : IHttpServer
    {
        private readonly TcpListener tcpListener;
        private readonly IList<Route> routeTable;
        private readonly IDictionary<string, IDictionary<string, string>> sessions;

        public HttpServer(int port, IList<Route> routeTable)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);
            this.routeTable = routeTable;
            this.sessions = new Dictionary<string, IDictionary<string, string>>();
        }

        public async Task StartAsync()
        {
            this.tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() => ProcessClientAsync(tcpClient));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
        }

        public async Task ResetAsync()
        {
            this.Stop();
            await this.StartAsync();
        }


        public void Stop()
        {
            this.tcpListener.Stop();
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using NetworkStream networkStream = tcpClient.GetStream();

            try
            {
                byte[] requestBytes = new byte[1000000]; // TODO: Use buffer
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                HttpRequest request = new HttpRequest(requestAsString);
                var sessionCookie = request.Cookies.FirstOrDefault(x => x.Name == HttpConstants.SessionIdCookieName);

                if (sessionCookie != null && this.sessions.ContainsKey(sessionCookie.Value))
                {
                    request.SessionData = this.sessions[sessionCookie.Value];
                }

                Console.WriteLine($"{request.Method} {request.Path}");

                HttpResponse response;
                var route = this.routeTable.FirstOrDefault(x => x.HttpMethod == request.Method && x.Path == request.Path);
                if (route == null)
                {
                    response = new HttpResponse(HttpResponseCode.NotFound, new byte[0]);
                    response.StatusCode = HttpResponseCode.NotFound;
                }
                else
                {
                    response = route.Action(request);
                }

                response.Headers.Add(new Header("Server", "SoftUniServer/2.0"));
                
                if (sessionCookie == null || !this.sessions.ContainsKey(sessionCookie.Value))
                {
                    var newSessionId = Guid.NewGuid().ToString();
                    this.sessions.Add(newSessionId, new Dictionary<string, string>());
                    response.Cookies.Add(
                        new ResponseCookie(HttpConstants.SessionIdCookieName, newSessionId)
                            { HttpOnly = true, MaxAge = 30*3600 });
                }
                

                byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());
                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await networkStream.WriteAsync(response.Body, 0, response.Body.Length);
            }
            catch (Exception ex)
            {

                var errorResponse = new HttpResponse(
                    HttpResponseCode.InternalServerError,
                    Encoding.UTF8.GetBytes(ex.ToString()));
                errorResponse.Headers.Add(new Header("Content-Type", "text/plain"));

                byte[] responseBytes = Encoding.UTF8.GetBytes(errorResponse.ToString());
                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await networkStream.WriteAsync(errorResponse.Body, 0, errorResponse.Body.Length);
            }

        }
    }
}
