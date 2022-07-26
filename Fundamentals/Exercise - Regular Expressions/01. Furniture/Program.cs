using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
          string patern = @">>(?<name>[A-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            List<string> furnitureName = new List<string>();

            double spendMoney = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }

                MatchCollection matches = Regex.Matches(input, patern);

                foreach (Match match in matches)
                {
                    string name = match.Groups["name"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    string qntyStr = match.Groups["quantity"].Value;
                    int.TryParse(qntyStr, out int quantity);

                    spendMoney += quantity * price;
                    furnitureName.Add(name);
                }

            }
            Console.WriteLine("Bought furniture:");

            foreach (var item in furnitureName)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}
