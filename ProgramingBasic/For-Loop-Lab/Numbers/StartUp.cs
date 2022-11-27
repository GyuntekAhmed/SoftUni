using System;

namespace Numbers
{
    internal class StartUp
    {
        static void Main()
        {
            int numbersNTo1 = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numbersNTo1; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
