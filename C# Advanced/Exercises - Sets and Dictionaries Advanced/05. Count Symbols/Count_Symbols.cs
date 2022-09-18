using System;
using System.Collections.Generic;

class Count_Symbols
{
    static void Main()
    {
        SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];

            if (symbols.ContainsKey(currentChar))
            {
                symbols[currentChar]++;
            }
            else
            {
                symbols.Add(currentChar, 1);
            }
        }

        foreach (var item in symbols)
        {
            Console.WriteLine($"{item.Key}: {item.Value} time/s");
        }
    }
}
