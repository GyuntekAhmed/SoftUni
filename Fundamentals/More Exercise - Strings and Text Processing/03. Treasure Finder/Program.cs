using System;
using System.Text;
using System.Linq;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string type = string.Empty;
            string coordinates = string.Empty;

            while (true)
            {
                string text = Console.ReadLine();
                if (text == "find")
                {
                    break;
                }

                int maxLenght = Math.Max(numbers.Length, text.Length);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < maxLenght; i++)
                {
                    sb.Append((char)(text[i] - numbers[i % numbers.Length]));
                }

                int startIndexType = sb.ToString().IndexOf('&') + 1;
                int endIndexType = sb.ToString().IndexOf('&', startIndexType + 1);
                int typeLenght = endIndexType - startIndexType;
                type = sb.ToString().Substring(startIndexType, typeLenght);

                int startIndexCoordinates = sb.ToString().IndexOf('<') + 1;
                int endIndexCoordinates = sb.ToString().IndexOf('>');
                int coordinatesLenght = endIndexCoordinates - startIndexCoordinates;
                coordinates = sb.ToString().Substring(startIndexCoordinates, coordinatesLenght);

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
