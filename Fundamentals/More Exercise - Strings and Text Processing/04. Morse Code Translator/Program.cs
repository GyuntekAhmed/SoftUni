using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] morseCodes = {
            ".-", "−...", "-.-.", "-..", ".", "..-..", "..-.", "--.", "....",
            "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-",
            ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
        };

            char[] englishCodes = {
            'A', 'B', 'C', 'D', 'E', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
            'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

            string[] morseWords = Console.ReadLine().Split('|');
            List<string> englishWords = new List<string>();

            foreach (string word in morseWords)
            {
                StringBuilder englishWord = new StringBuilder();
                string[] morseSymbols = word.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string symbol in morseSymbols)
                {
                    for (int i = 0; i < morseCodes.Length; i++)
                    {
                        if (morseCodes[i] == symbol)
                        {
                            englishWord.Append(englishCodes[i]);
                            break;
                        }
                    }
                }
                englishWords.Add(englishWord.ToString());
            }
            Console.WriteLine(String.Join(" ", englishWords));
        }
    }
}
