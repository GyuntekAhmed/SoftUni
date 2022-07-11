using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(wordToRemove))
            {
                //int startIndexToRemove = text.IndexOf(wordToRemove);
                //text = text.Remove(startIndexToRemove, wordToRemove.Length);

                text = text.Replace(wordToRemove, "");
            }

            Console.WriteLine(text);
        }
    }
}
