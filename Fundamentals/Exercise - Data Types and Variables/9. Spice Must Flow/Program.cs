using System;

namespace _9._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int CONSUMED_BY_WORKER = 26;
            const int MINIMUM_SPICES_TO_GATHER = 100;
            const int DAILY_DECREES_OF_MIND_YELD = 10;

            int countOfSpices =int.Parse(Console.ReadLine());
            int totalConsumed = 0;
            int daysCounter = 0;

            while (countOfSpices >= MINIMUM_SPICES_TO_GATHER)
            {
                totalConsumed += countOfSpices - CONSUMED_BY_WORKER;
                countOfSpices -= DAILY_DECREES_OF_MIND_YELD;
                daysCounter++;

                if (countOfSpices < MINIMUM_SPICES_TO_GATHER)
                {
                    totalConsumed -= CONSUMED_BY_WORKER;
                }
            }

            Console.WriteLine(daysCounter);
            Console.WriteLine(totalConsumed);
        }
    }
}
