using System;

class Trade_Commissions
{
    static void Main()
    {
        string city = Console.ReadLine();
        double sels = double.Parse(Console.ReadLine());

        bool validCity = city == "Sofia" || city == "Plovdiv" || city == "Varna";
        bool validSels = sels >= 0;

        if (!validCity || !validSels)
        {
            Console.WriteLine("error");
        }

        double results = 0;

        if (city == "Sofia")
        {
            if (sels >= 0 && sels <= 500)
            {
                results = sels * 0.05;
            }
            else if (sels > 500 && sels <= 1000)
            {
                results = sels * 0.07;
            }
            else if (sels > 1000 && sels <= 10000)
            {
                results = sels * 0.08;
            }
            else if (sels > 10000)
            {
                results = sels * 0.12;
            }
        }
        else if (city == "Varna")
        {
            if (sels >= 0 && sels <= 500)
            {
                results = sels * 0.045;
            }
            else if (sels > 500 && sels <= 1000)
            {
                results = sels * 0.075;
            }
            else if (sels > 1000 && sels <= 10000)
            {
                results = sels * 0.10;
            }
            else if (sels > 10000)
            {
                results = sels * 0.13;
            }
        }
        if (city == "Plovdiv")
        {
            if (sels >= 0 && sels <= 500)
            {
                results = sels * 0.055;
            }
            else if (sels > 500 && sels <= 1000)
            {
                results = sels * 0.08;
            }
            else if (sels > 1000 && sels <= 10000)
            {
                results = sels * 0.12;
            }
            else if (sels > 10000)
            {
                results = sels * 0.145;
            }
        }

        if (results != 0)
        {
            Console.WriteLine($"{results:f2}");
        }
    }
}
