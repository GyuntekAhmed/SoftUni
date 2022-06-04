using System;

namespace _7._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int capacity = 255;
            int lines = int.Parse(Console.ReadLine());
            int litersInTank = 0;

            for (int i = 1; i <= lines; i++)
            {
                int quantitiesOfWater = int.Parse(Console.ReadLine());
                litersInTank += quantitiesOfWater;

                if (litersInTank > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    litersInTank -= quantitiesOfWater;
                    continue;
                }
            }

            Console.WriteLine(litersInTank);
        }
    }
}
