namespace ChristmasPastryShop.Models.Delicacies.Entities
{
    public class Stolen : Delicacy
    {
        private const double price = 3.50;

        public Stolen(string delicacyName) : base(delicacyName, price)
        {
        }
    }
}
