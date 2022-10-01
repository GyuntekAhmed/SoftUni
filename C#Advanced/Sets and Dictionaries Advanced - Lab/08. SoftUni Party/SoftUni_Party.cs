using System;
using System.Collections.Generic;

class SoftUni_Party
{
    static void Main()
    {
        HashSet<string> set = new HashSet<string>();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "PARTY")
            {
                break;
            }

            set.Add(command);
        }

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            if (set.Contains(input))
            {
                set.Remove(input);
            }
        }

        Console.WriteLine(set.Count);

        foreach (string item in set)
        {
            char[] ch = item.ToCharArray();

            if (char.IsDigit(ch[0]))
            {
                Console.WriteLine(item);
            }
        }

        foreach (string item in set)
        {
            char[] ch = item.ToCharArray();

            if (char.IsLetter(ch[0]))
            {
                Console.WriteLine(item);
            }
        }
    }
}
