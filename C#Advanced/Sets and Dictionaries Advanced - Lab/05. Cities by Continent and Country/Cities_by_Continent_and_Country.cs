using System;
using System.Collections.Generic;

class Cities_by_Continent_and_Country
{
    static void Main()
    {
        var cities = new Dictionary<string, Dictionary<string, List<string>>>();

        int countToAdd = int.Parse(Console.ReadLine());

        for (int i = 0; i < countToAdd; i++)
        {
            string[] spliter = Console.ReadLine().Split();

            string continent = spliter[0];
            string country = spliter[1];
            string city = spliter[2];

            AddCity(cities, continent, country, city);
        }

        PrintContinents(cities);
    }

    static void PrintContinents(Dictionary<string, Dictionary<string, List<string>>> cities)
    {
        foreach (var continent in cities)
        {
            Console.WriteLine($"{continent.Key}:");

            foreach (var country in continent.Value)
            {
                Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
            }
        }

    }

    static void AddCity(Dictionary<string, Dictionary<string, List<string>>> cities, string continent, string country, string city)
    {
        if (!cities.ContainsKey(continent))
        {
            cities.Add(continent, new Dictionary<string, List<string>>());
        }
        if (!cities[continent].ContainsKey(country))
        {
            cities[continent].Add(country, new List<string>());
        }

        cities[continent][country].Add(city);
    }
}
