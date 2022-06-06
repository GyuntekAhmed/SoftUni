using System;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] wagons = new int[numberOfWagons];

            int sum = 0;

            for (int indexOfWagons = 0; indexOfWagons < wagons.Length; indexOfWagons++)
            {
                wagons[indexOfWagons] = int.Parse(Console.ReadLine());
                sum += wagons[indexOfWagons];
            }

            for (int i = 0; i < wagons.Length; i++)
            {
                Console.Write($"{wagons[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
