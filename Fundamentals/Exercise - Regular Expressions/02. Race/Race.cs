using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Race
{
    static void Main()
    {
        Regex namePatern = new Regex(@"(?<name>[A-Za-z])");
        string digitsPatern = @"(?<digits>\d+)";

        int sumOfDigits = 0;

        Dictionary<string, int> participants = new Dictionary<string, int>();
        List<string> names = Console.ReadLine()
            .Split(", ")
            .ToList();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of race")
            {
                break;
            }

            MatchCollection matchedNames = namePatern.Matches(input);
            MatchCollection matchedDigits = Regex.Matches(input, digitsPatern);

            string currentName = string.Join("", matchedNames);
            string currentDigits = string.Join("", matchedDigits);
            sumOfDigits = 0;

            for (int i = 0; i < currentDigits.Length; i++)
            {
                sumOfDigits += int.Parse(currentDigits[i].ToString());
            }

            if (names.Contains(currentName))
            {
                if (!participants.ContainsKey(currentName))
                {
                    participants.Add(currentName, sumOfDigits);
                }
                else
                {
                    participants[currentName] += sumOfDigits;
                }
            }
        }

        var winers = participants.OrderByDescending(x => x.Value).Take(3);

        var firstWiner = winers.Take(1);
        var secondWiner = winers.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
        var thirdSWiner = winers.OrderBy(x => x.Value).Take(1);

        foreach (var firstName in firstWiner)
        {
            Console.WriteLine($"1st place: {firstName.Key}");
        }
        foreach (var secondName in secondWiner)
        {
            Console.WriteLine($"2nd place: {secondName.Key}");
        }
        foreach (var thirdName in thirdSWiner)
        {
            Console.WriteLine($"3rd place: {thirdName.Key}");
        }

    }
}
