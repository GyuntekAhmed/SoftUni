namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private double money;

        private List<Product> products;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products => products;

        public double Money
        {
            get { return money; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");

                }

                money = value;
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

        public bool AddProduct(Product product)
        {
            if (Money - product.Cost < 0)
            {
                return false;
            }

            products.Add(product);
            Money -= product.Cost;
            return true;
        }
    }
}
