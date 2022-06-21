using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] action = command.Split();

                if (action[0] == "Add")
                {
                    int number = int.Parse(action[1]);
                    numbers.Add(number);
                }
                else if (action[0] == "Insert")
                {
                    int number = int.Parse(action[1]);
                    int index = int.Parse(action[2]);

                    if (index > numbers.Count - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, number);
                }
                else if (action[0] == "Remove")
                {
                    int index = int.Parse(action[1]);

                    if (index > numbers.Count - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(index);
                }
                else if (action[0] == "Shift")
                {
                    int count = int.Parse(action[2]);

                    if (action[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }
                    else if (action[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Insert(0, numbers[numbers.Count - 1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
