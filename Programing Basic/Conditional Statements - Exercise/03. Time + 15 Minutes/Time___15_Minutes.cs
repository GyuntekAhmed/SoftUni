using System;

class Time___15_Minutes
{
    static void Main(string[] args)
    {
        int hours = int.Parse(Console.ReadLine());
        double minutes = double.Parse(Console.ReadLine());
        double results = minutes + 15;
        if (results >= 60)
        {
            hours += 1;
            results -= 60;
        }
        if (hours >= 24)
        {
            hours -= 24;
        }
        if (results < 10)
        {

            Console.WriteLine($"{hours}:{0}{results}");
        }
        else
        {

            Console.WriteLine($"{hours}:{results}");
        }
    }
}
