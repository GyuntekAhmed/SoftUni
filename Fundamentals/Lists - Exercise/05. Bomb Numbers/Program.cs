using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            int[] specialNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = specialNums[0];
            int power = specialNums[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int target = numbers[i];
                if (target == bomb)
                {
                    Bomb(numbers, power, i);
                }
            }

            Console.WriteLine(numbers.Sum());
        }

        private static void Bomb(List<int> numbers, int power, int index)
        {
            int start = Math.Max(0, index - power);
            int end = Math.Min(numbers.Count - 1, index + power);

            for (int i = start; i <= end; i++)
            {
                numbers[i] = 0;
            }
        }
    }
}
