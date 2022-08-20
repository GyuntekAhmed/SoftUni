using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            //foreach (int number in numbers)
            //{
            //    stack.Push(number);
            //}
            while (true)
            {
                string[] command = Console.ReadLine()
                    .ToLower()
                    .Split();

                string tokens = command[0];
                if (tokens == "end")
                {
                    break;
                }

                switch (tokens)
                {
                    case "add":
                        int firstNumber = int.Parse(command[1]);
                        int secondNumber = int.Parse(command[2]);
                        stack.Push(firstNumber);
                        stack.Push(secondNumber);
                        break;
                    case "remove":
                        int count = int.Parse(command[1]);
                        if (stack.Count < count)
                        {
                            break;
                        }
                        for (int i = 0; i < count; i++)
                        {

                            stack.Pop();
                        }
                        break;
                }
            }
            var sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
