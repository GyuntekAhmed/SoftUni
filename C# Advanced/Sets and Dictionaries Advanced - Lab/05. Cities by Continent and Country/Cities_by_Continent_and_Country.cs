using System;
using System.Collections.Generic;

class Cities_by_Continent_and_Country
{
    static void Main()
    {
        var Countries = new Dictionary<string, Dictionary<string, List<string>>>();

        int countToAdd = int.Parse(Console.ReadLine());

        for (int i = 0; i < countToAdd; i++)
        {
            string[] spliter = Console.ReadLine().Split();

            string continent = spliter[0];
            string country = spliter[1];
            string city = spliter[2];

            if (!Countries.ContainsKey(continent))
            {
                Countries.Add(continent, new Dictionary<string, List<string>>());
            }
            if (!Countries[continent].ContainsKey(country))
            {
                Countries[continent].Add(country, new List<string>());
            }

            Countries[continent][country].Add(city);
        }

        foreach (var continent in Countries)
        {
            Console.WriteLine($"{continent.Key}:");

            foreach (var country in continent.Value)
            {
                Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
            }
        }
    }
}
