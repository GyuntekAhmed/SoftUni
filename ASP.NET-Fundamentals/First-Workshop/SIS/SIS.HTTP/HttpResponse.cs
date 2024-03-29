﻿using System.Text;

namespace SIS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(HttpResponseCode statusCode, byte[] body)
            : this()
        {
            this.StatusCode = statusCode;
            this.Body = body;

            if (body?.Length > 0)
            {
                this.Headers.Add(new Header("Content-Length", body.Length.ToString()));
            }
        }

        internal HttpResponse()
        {
            this.Version = HttpVersionType.Version20;
            this.Headers = new List<Header>();
            this.Cookies = new List<ResponseCookie>();
        }

        public HttpVersionType Version { get; set; }

        public HttpResponseCode StatusCode { get; set; }

        public IList<Header> Headers { get; set; }

        public IList<ResponseCookie> Cookies { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            StringBuilder responseAsString = new StringBuilder();

            var httpVersionAsString = this.Version switch
            {
                HttpVersionType.Version10 => "HTTP/1.0",
                HttpVersionType.Version11 => "HTTP/1.1",
                HttpVersionType.Version20 => "HTTP/2.0",
                HttpVersionType.Version30 => "HTTP/3.0",
                _ => "HTTP/2.0"
            };

            responseAsString.Append($"{httpVersionAsString} {(int)this.StatusCode} {this.StatusCode}" + HttpConstants.NewLine);

            foreach (var header in Headers)
            {
                responseAsString.Append(header.ToString() + HttpConstants.NewLine);
            }

            foreach (var cookie in this.Cookies)
            {
                responseAsString.Append("Set-Cookie: " + cookie.ToString() + HttpConstants.NewLine);
            }

            responseAsString.Append(HttpConstants.NewLine);

            return responseAsString.ToString();
        }
    }
}
