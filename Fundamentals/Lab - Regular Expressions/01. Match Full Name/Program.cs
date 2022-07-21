using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\b([A-Z][a-z]{1,}) ([A-Z][a-z]{1,})\b";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, patern);

            foreach (Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
