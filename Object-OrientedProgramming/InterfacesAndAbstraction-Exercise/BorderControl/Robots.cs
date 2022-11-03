namespace BorderControl
{
    public class Robots : IId
    {
        public Robots(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Id { get; set; }
        public string Model { get; set; }
    }
}
