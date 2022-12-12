namespace ShoppingSpree
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            string[] people = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            string[] products = Console.ReadLine()
                .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> peopleKvp =
                new Dictionary<string, Person>();
            Dictionary<string, Product> productKvp =
                new Dictionary<string, Product>();

            try
            {
                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    double money = double.Parse(people[i + 1]);

                    Person person = new Person(name, money);
                    peopleKvp.Add(name, person);
                }

                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    double cost = double.Parse(products[i + 1]);

                    Product product = new Product(name, cost);
                    productKvp.Add(name, product);
                }

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string[] tokens = command.Split();

                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person person = peopleKvp[personName];
                    Product product = productKvp[productName];

                    bool isAdd = person.AddProduct(product);

                    if (!isAdd)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }

                foreach (var peoples in peopleKvp)
                {
                    string info = peoples.Value.Products.Count > 0
                        ? string.Join(", ", peoples.Value.Products.Select(x => x.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{peoples.Key} - {info}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
