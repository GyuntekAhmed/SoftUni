namespace SIS.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string? Name { get; set; }

        public string? Value { get; set; }
    }
}
