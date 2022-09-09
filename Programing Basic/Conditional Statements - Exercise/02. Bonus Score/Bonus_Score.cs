using System;

class Bonus_Score
{
    static void Main()
    {
        int numbers = int.Parse(Console.ReadLine());
        double bonus = 0.0;

        if (numbers <= 100)
        {
            bonus = 5;
        }
        else if (numbers > 100 && numbers < 1000)
        {
            bonus = numbers * 0.2;
        }
        else if (numbers >= 1000)
        {
            bonus = numbers * 0.10;
        }
        if (numbers % 2 == 0)
        {
            bonus = bonus + 1;
        }
        else if (numbers % 10 == 5)
        {
            bonus = bonus + 2;
        }

        Console.WriteLine(bonus);
        Console.WriteLine(numbers + bonus);
    }
}
