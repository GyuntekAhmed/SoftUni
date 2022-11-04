namespace FoodShortage
{
    public class Citizens : IId, IBuyer
    {
        private int food = 0;
        public Citizens( string name, int age, string id, string birthdates)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdates = birthdates;
            Food = food;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdates { get; set; }

        public int Food { get; set; }

        public int BuyFood()
        {
            return Food += 10;
        }
    }
}
