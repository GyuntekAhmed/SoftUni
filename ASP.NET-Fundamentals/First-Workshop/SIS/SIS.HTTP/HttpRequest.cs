using System.Text;

namespace SIS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string httpRequestAsString)
        {
            this.Headers = new List<Header>();

            var lines = httpRequestAsString
                .Split(new string[] { HttpConstants.NewLine }
                , StringSplitOptions.None);
            var httpInfoHeader = lines[0];
            var infoHeaderParts = httpInfoHeader.Split(' ');

            if (infoHeaderParts.Length != 3)
            {
                throw new HttpServerException("Invalid HTTP header line.");
            }

            var httpMethod = infoHeaderParts[0];
            //Enum.TryParse(httpMethod, out HttpMethodType methodType);
            //this.Method = methodType
            this.Method = httpMethod switch
            {
                "Post" => HttpMethodType.Post,
                "Get" => HttpMethodType.Get,
                "Put" => HttpMethodType.Put,
                "Delete" => HttpMethodType.Delete,
                _ => HttpMethodType.Unknown,
            };

            this.Path = infoHeaderParts[1];
            var httpVersion = infoHeaderParts[2];

            //Enum.TryParse(httpVersion, out HttpVersionType versionType);
            //this.Version = versionType;
            this.Version = httpVersion switch
            {
                "HTTP/1.0" => HttpVersionType.Version10,
                "HTTP/1.1" => HttpVersionType.Version11,
                "HTTP/2.0" => HttpVersionType.Version20,
                "HTTP/3.0" => HttpVersionType.Version30,
                _ => HttpVersionType.Version20
            };

            bool isInHeader = true;
            StringBuilder bodyBuilder = new StringBuilder();

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeader = false;
                    continue;
                }
                if (isInHeader)
                {
                    var headerParts = line
                            .Split(
                            new string[] { ": " }
                            , 2
                            , StringSplitOptions.None);

                    if (headerParts.Length != 2)
                    {
                        throw new HttpServerException($"Invalid header: {line}");
                    }

                    var header = new Header(headerParts[0], headerParts[1]);
                    this.Headers.Add(header);
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }
        }

        public HttpMethodType Method { get; set; }

        public string? Path { get; set; }

        public HttpVersionType Version { get; set; }

        public IList<Header> Headers { get; set; }

        public string? Body { get; set; }
    }
}
