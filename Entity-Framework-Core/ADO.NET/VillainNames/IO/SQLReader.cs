namespace VillainNames.IO
{
    public class SQLReader : IReader
    {
        public SQLReader(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }

        public string Read()
        {
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            string fullPath = Path.Combine(currentDirectoryPath, $"/../Queries/${FileName}.sql");

            string query = File.ReadAllText(fullPath);

            return query;
        }
    }
}
