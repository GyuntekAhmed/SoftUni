using System;
using System.Text.RegularExpressions;

class SoftUni_Bar_Income
{
    static void Main()
    {
        string patern = @"%(?<customerName>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[\d]+.?[\d+]+)\$";

        double totalIncome = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of shift")
            {
                break;
            }

            Regex regex = new Regex(patern);

            bool isValid = regex.IsMatch(input);
            if (isValid)
            {
                string customer = regex.Match(input).Groups["customerName"].Value;
                string product = regex.Match(input).Groups["product"].Value;
                int count = int.Parse(regex.Match(input).Groups["count"].Value);
                double price = double.Parse(regex.Match(input).Groups["price"].Value);
                totalIncome += price * count;

                Console.WriteLine($"{customer}: {product} - {price * count:f2}");
            }
        }

        Console.WriteLine($"Total income: {totalIncome:f2}");
    }
}
