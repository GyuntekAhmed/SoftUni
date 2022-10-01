using System;

class Small_Shop
{
    static void Main()
    {
        string product = Console.ReadLine();
        string town = Console.ReadLine();


        double quantity = double.Parse(Console.ReadLine());

        double result = 0;



        if (town == "Sofia")
        {
            if (product == "coffee")
            {
                result = quantity * 0.50;
            }
            else if (product == "water")
            {
                result = quantity * 0.80;
            }
            else if (product == "beer")
            {
                result = quantity * 1.20;
            }
            else if (product == "sweets")
            {
                result = quantity * 1.45;
            }
            else
            {
                result = quantity * 1.60;
            }
        }
        else if (town == "Plovdiv")
        {
            if (product == "coffee")
            {
                result = quantity * 0.40;
            }
            else if (product == "water")
            {
                result = quantity * 0.70;
            }
            else if (product == "beer")
            {
                result = quantity * 1.15;
            }
            else if (product == "sweets")
            {
                result = quantity * 1.30;
            }
            else
            {
                result = quantity * 1.50;
            }

        }
        else
        {
            if (product == "coffee")
            {
                result = quantity * 0.45;
            }
            else if (product == "water")
            {
                result = quantity * 0.70;
            }
            else if (product == "beer")
            {
                result = quantity * 1.10;
            }
            else if (product == "sweets")
            {
                result = quantity * 1.35;
            }
            else
            {
                result = quantity * 1.55;
            }

        }
        Console.WriteLine(result);
    }
}
