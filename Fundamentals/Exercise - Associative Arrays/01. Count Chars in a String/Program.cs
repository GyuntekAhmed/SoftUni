using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var ch in text)
            {
                if (!occurrences.ContainsKey(ch))
                {
                    occurrences.Add(ch, 0);
                }
                occurrences[ch]++;
            }

            foreach (var item in occurrences.Where(c => c.Key != ' '))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
