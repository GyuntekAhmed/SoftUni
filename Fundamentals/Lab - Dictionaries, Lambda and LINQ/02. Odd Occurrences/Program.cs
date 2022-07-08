using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(word => word.ToLower()).ToArray();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!counts.ContainsKey(word))
                {
                    counts.Add(word, 0);
                }

                counts[word]++;
            }

            string[] oddCountWords = counts.Where(w => w.Value % 2 != 0).Select(w => w.Key).ToArray();

            Console.WriteLine(String.Join(" ", oddCountWords));
        }
    }
}
