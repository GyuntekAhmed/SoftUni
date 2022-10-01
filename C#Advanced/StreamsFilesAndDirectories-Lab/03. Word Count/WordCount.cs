using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Word_Count
{
    class WordCount
    {
        static void Main()
        {

            string wordPath = File.ReadAllText(@"..\..\..\Files\words.txt");
            string[] words = wordPath.Split();
            //using var writer = new StreamWriter(@"..\..\..\Files\output.txt");
            //string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath, words);

        }

        public static void CalculateWordCounts(string wordPath, string textPath, string outputPath, string[] words)
        {
            var dictionary = new SortedDictionary<string, int>();

            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter(@"..\..\..\Files\output.txt"))
                {


                    string currentSentence = reader.ReadLine();

                    while (currentSentence != null)
                    {
                        foreach (var word in words)
                        {
                            if (currentSentence.ToLower().Contains(word))
                            {

                                if (!dictionary.ContainsKey(word))
                                {
                                    dictionary.Add(word, 0);
                                    dictionary[word]++;
                                }
                                else
                                {
                                    dictionary[word]++;
                                }
                            }
                        }

                        currentSentence = reader.ReadLine();
                    }

                    foreach (var word in dictionary.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}