using System;

namespace _10._Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power =int.Parse(Console.ReadLine());
            int distance =int.Parse(Console.ReadLine());
            int exFactor =int.Parse(Console.ReadLine());
            int startingPower = power;
            int countOfPokedTarget = 0;

            while (power>=distance)
            {
                power -= distance;
                countOfPokedTarget++;

                if (startingPower * 0.5 == power && exFactor > 0)
                {
                    power /= exFactor;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(countOfPokedTarget);
        }
    }
}
