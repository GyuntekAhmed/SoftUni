using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            int countOfComands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfComands; i++)
            {
                string[] comands = Console.ReadLine().Split();
                string userName = comands[1];

                if (comands[0] == "register")
                {
                    string licenseNumber = comands[2];

                    if (!users.ContainsKey(userName))
                    {
                        users.Add(userName, licenseNumber);
                        Console.WriteLine($"{userName} registered {licenseNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licenseNumber}");
                    }
                }
                else
                {
                    if (users.ContainsKey(userName))
                    {
                        users.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
