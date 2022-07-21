using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\+359( |-)2\1\d{3}\1\d{4}\b";

            string input = Console.ReadLine();

            string[] matches = Regex.Matches(input, patern).Select(x => x.Value).ToArray();

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
