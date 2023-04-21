namespace HttpClientDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.amazon.com/";

            HttpClient client = new HttpClient();
            var html = await client.GetStringAsync(url);

            Console.WriteLine(html);
        }
    }
}