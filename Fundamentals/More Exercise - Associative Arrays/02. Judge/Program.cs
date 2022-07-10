using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestNameAndPoint = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> individualStatic = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "no more time")
                {
                    break;
                }
                else
                {
                    string[] input = command.Split(" -> ");
                    string userName = input[0];
                    string contest = input[1];
                    int points = int.Parse(input[2]);
                    bool itMustSum = false;

                    if (!contestNameAndPoint.ContainsKey(contest))
                    {
                        contestNameAndPoint[contest] = new Dictionary<string, int>();
                        contestNameAndPoint[contest][userName] = points;
                        itMustSum = true;
                    }
                    else
                    {
                        if (!contestNameAndPoint[contest].ContainsKey(userName))
                        {
                            contestNameAndPoint[contest][userName] = points;
                            itMustSum = true;
                        }
                        else
                        {
                            int currentPoints = contestNameAndPoint[contest][userName];
                            if (currentPoints < points)
                            {
                                contestNameAndPoint[contest][userName] = points;
                                points -= currentPoints;
                                itMustSum = true;
                            }
                        }
                    }
                    if (!individualStatic.ContainsKey(userName))
                    {
                        individualStatic[userName] = 0;
                    }
                    if (itMustSum)
                    {
                        individualStatic[userName] += points;
                    }
                }
            }
            foreach (var kvp in contestNameAndPoint)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");
                int counter = 1;
                foreach (var item in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{counter}. {item.Key} <::> {item.Value}");
                    counter++;
                }
            }

            Console.WriteLine("Individual standings:");
            int counterForUsers = 1;

            foreach (var kvp in individualStatic.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counterForUsers}. {kvp.Key} -> {kvp.Value}");
                counterForUsers++;
            }
        }
    }
}
