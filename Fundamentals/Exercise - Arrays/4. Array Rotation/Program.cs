using System;
using System.Linq;

namespace _4._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int tempEl = array[0];
                for (int operations = 0; operations < array.Length - 1; operations++)
                {
                    array[operations] = array[operations + 1];
                }

                array[array.Length - 1] = tempEl;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
