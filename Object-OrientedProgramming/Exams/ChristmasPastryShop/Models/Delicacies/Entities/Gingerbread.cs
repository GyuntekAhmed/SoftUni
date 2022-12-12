namespace ChristmasPastryShop.Models.Delicacies.Entities
{
    public class Gingerbread : Delicacy
    {
        private const double price = 4.00;

        public Gingerbread(string delicacyName) : base(delicacyName, price)
        {
        }
    }
}
