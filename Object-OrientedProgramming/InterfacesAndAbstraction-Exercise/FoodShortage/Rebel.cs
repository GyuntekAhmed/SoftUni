namespace FoodShortage
{
    public class Rebel : IId, IBuyer
    {
        private int food = 0;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = food;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Group { get; set; }

        public int Food { get; set; }

        public int BuyFood()
        {

            return Food += 5;
        }
    }
}
