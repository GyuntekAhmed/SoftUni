﻿namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            ProcessLines(inputFilePath);
        }

        public static void ProcessLines(string inputFilePath)
        {
            using(StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = -1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    counter++;

                    if (counter % 2 == 0)
                    {
                        line = Replace(line);
                        line = Reverse(line);
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                }
            }
        }

        public static string Reverse(string line)
        {
            return string.Join(" ", line.Split().Reverse());
        }

        public static string Replace(string line)
        {
            return line.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@");
        }
    }
}
