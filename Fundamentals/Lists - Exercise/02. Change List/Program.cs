using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] action = command.Split();
                string cmd = action[0];

                if (cmd == "Delete")
                {
                    int element = int.Parse(action[1]);
                    myList.RemoveAll(el => el == element);
                }
                else if (cmd == "Insert")
                {
                    int element = int.Parse(action[1]);
                    int index = int.Parse(action[2]);

                    myList.Insert(index, element);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
