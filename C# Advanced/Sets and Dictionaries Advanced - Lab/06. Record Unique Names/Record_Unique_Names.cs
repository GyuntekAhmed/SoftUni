using System;
using System.Collections.Generic;

class Record_Unique_Names
{
    static void Main()
    {
        HashSet<string> names = new HashSet<string>();

        int countToAdd = int.Parse(Console.ReadLine());

        for (int i = 0; i < countToAdd; i++)
        {
            string name = Console.ReadLine();

            names.Add(name);
        }

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
