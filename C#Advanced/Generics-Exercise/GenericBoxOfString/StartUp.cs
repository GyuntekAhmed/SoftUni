using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            //var list = new List<int>();

            //for (int i = 0; i < numberOfLines; i++)
            //{
            //    var input = Console.ReadLine();

            //    list.Add(int.Parse(input));
            //}
            //var box = new Box<int>(list);

            //var indexes = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();
            //box.Swap(list, indexes[0], indexes[1]);

            //Console.WriteLine(box);

            var list = new List<double>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());
            var count = box.CountOfGreaterElements(list, elementToCompare);

            Console.WriteLine(count);
        }
    }
}
