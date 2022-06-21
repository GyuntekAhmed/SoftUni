using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> PartyList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var comand = Console.ReadLine().Split();
                string currentName = comand[0];

                if (PartyList.Contains(currentName) && comand[2] == "going!")
                {
                    Console.WriteLine($"{currentName} is already in the list!");
                }
                else if (PartyList.Contains(currentName) && comand[2] == "not")
                {
                    PartyList.Remove(currentName);
                }
                else if (!PartyList.Contains(currentName) && comand[2] == "not")
                {
                    Console.WriteLine($"{currentName} is not in the list!");
                }
                else
                {
                    PartyList.Add(currentName);
                }
            }

            foreach (string currentName in PartyList)
            {
                Console.WriteLine(currentName);
            }
        }
    }
}
