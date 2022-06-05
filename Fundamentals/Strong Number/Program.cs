using System;

namespace Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int strongNumber = int.Parse(Console.ReadLine());
            int strongNumberCopy = strongNumber;
            int sum = 0;

            while (strongNumber >0)
            {
                int factorial = 1;
                int curentNumber = strongNumber % 10;
                strongNumber /= 10;

                for (int i = 2; i <= curentNumber; i++)
                {
                    factorial *= i;
                }
                sum += factorial;
            }
            Console.WriteLine(sum == strongNumberCopy ? "yes" : "no");
        }
    }
}
