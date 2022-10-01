using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var shops = new SortedDictionary<string, Dictionary<string, double>>();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "Revision")
            {
                PrintProducts(shops);
                break;
            }
            string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string shopName = tokens[0];
            string product = tokens[1];
            double price = double.Parse(tokens[2]);

            AddProduct(shops, shopName, product, price);
        }

    }

     static void AddProduct(SortedDictionary<string, Dictionary<string, double>> shops, string shopName, string product, double price)
    {
            if (!shops.ContainsKey(shopName))
            {
                shops.Add(shopName, new Dictionary<string, double>());
            }
            
            shops[shopName].Add(product, price);
    }

    static void PrintProducts(SortedDictionary<string, Dictionary<string, double>> shops)
    {
        foreach (var shop in shops)
        {
            Console.WriteLine($"{shop.Key}->");

            foreach (var item in shop.Value)
            {
                Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
            }
        }
    }
}
