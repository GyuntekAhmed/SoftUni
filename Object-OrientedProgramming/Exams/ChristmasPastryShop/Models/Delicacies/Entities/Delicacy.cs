namespace ChristmasPastryShop.Models.Delicacies.Entities
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        protected Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
            Price = price;
        }

        public double Price
        {
            get { return price; }
            private set{ price = value; }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }

        public override string ToString()
            => $"{Name} - {Price:F2} lv";
    }
}
