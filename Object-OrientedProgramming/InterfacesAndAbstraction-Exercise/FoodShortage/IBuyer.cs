namespace FoodShortage
{
    public interface IBuyer
    {
        public int Food { get; }
        public string Name { get; }
        int BuyFood();
    }
}
