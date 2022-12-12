namespace ShoppingSpree
{
    using System;

    public class Product
    {
        private string name;
        private double cost;

        public Product(string productName, double cost)
        {
            Cost = cost;
            Name = productName;
        }

        public double Cost
        {
            get { return cost; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                cost = value;
            }
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

    }
}
