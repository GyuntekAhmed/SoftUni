namespace SIS.HTTP
{
    using System.Net;
    using System.Net.Sockets;
    using System.Text;


    public class HttpServer : IHttpServer
    {
        private readonly TcpListener tcpListener;
        public HttpServer(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);

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
            byte[] requestBytes = new byte[1000000]; // TODO: Use buffer
            int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
            HttpRequest request = new HttpRequest(requestAsString);
            byte[] fileContent =
                Encoding.UTF8.GetBytes
                ("<form method='post'><input name='username' /><input type='submit' /></form><h1>Hello, Word from Gyuni!!!</h1>");
            string headers = "HTTP/1.0 200 OK" +
                              HttpConstants.NewLine +
                              "Server: SoftUniServer/1.0" + HttpConstants.NewLine +
                              "Content-Type: text/html" + HttpConstants.NewLine +
                              "Content-Lenght: " + fileContent.Length + HttpConstants.NewLine +
                              HttpConstants.NewLine;

            byte[] headersBytes = Encoding.UTF8.GetBytes(headers);
            await networkStream.WriteAsync(headersBytes, 0, headersBytes.Length);
            await networkStream.WriteAsync(fileContent, 0, fileContent.Length);
            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));
        }
    }
}
