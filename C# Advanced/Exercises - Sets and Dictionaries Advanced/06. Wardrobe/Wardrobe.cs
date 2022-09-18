using System;
using System.Collections.Generic;

class Wardrobe
{
    static void Main()
    {
        int numClothes = int.Parse(Console.ReadLine());

        Dictionary<string, Dictionary<string, int>> colorsWardrobe
            = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < numClothes; i++)
        {
            string[] input = Console.ReadLine()
                  .Split(" -> ");
            string color = input[0];
            string[] clothes = input[1].Split(",");

            if (!colorsWardrobe.ContainsKey(color))
            {
                colorsWardrobe[color] = new Dictionary<string, int>();
            }

            var colorCollection = colorsWardrobe[color];

            for (int j = 0; j < clothes.Length; j++)
            {
                if (!colorCollection.ContainsKey(clothes[j]))
                {
                    colorCollection[clothes[j]] = 0;
                }
                colorCollection[clothes[j]]++;
            }
        }

        string[] itemNeeded = Console.ReadLine().Split();

        string colorNeeded = itemNeeded[0];
        string pieceNeeded = itemNeeded[1];

        foreach (var color in colorsWardrobe)
        {
            Console.WriteLine($"{color.Key} clothes:");

            foreach (var clothes in color.Value)
            {
                Console.WriteLine(color.Key == colorNeeded && clothes.Key == pieceNeeded
                    ? $"* {clothes.Key} - {clothes.Value} (found!)"
                    : $"* {clothes.Key} - {clothes.Value}");
            }
        }
    }
}
