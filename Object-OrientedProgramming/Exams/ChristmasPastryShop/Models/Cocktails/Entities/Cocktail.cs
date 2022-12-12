namespace ChristmasPastryShop.Models.Cocktails.Entities
{
    using System;
    using ChristmasPastryShop.Utilities.Messages;
    using Contracts;

    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }
        public string Name
        {
            get { return name;}
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }

        public string Size
        {
            get { return size;}
            private set
            {
                size = value;
            }
        }

        public double Price
        {
            get { return price;}
            private set
            {
                if (size == "Large")
                {
                    price = value;
                }
                else if (size == "Middle")
                {
                    price = ((double)2 / 3) * value;
                }
                else if (size == "Small")
                {
                    price = ((double)1 / 3) * value;
                }
            }
        }

        public override string ToString()
        => $"{Name} ({Size}) - {Price:f2} lv";

    }
}
